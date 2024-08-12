using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Winch.Config;
using Winch.Util;

namespace Winch.Core
{
    class ModAssembly
    {
        public readonly string BasePath;
        public Dictionary<string, object> Metadata;
        public Assembly? LoadedAssembly;

        public string AssemblyLocation => LoadedAssembly != null ? Path.GetDirectoryName(LoadedAssembly.Location) : string.Empty;
        public string AssemblyName => LoadedAssembly != null ? LoadedAssembly.GetName().Name : string.Empty;
        public string GUID => Metadata.ContainsKey("ModGUID") ? Metadata["ModGUID"].ToString() : throw new MissingFieldException("No 'ModGUID' field found in Mod Metadata.");
        public string AssemblyRelativePath => Metadata.ContainsKey("ModAssembly") ? Metadata["ModAssembly"].ToString() : throw new MissingFieldException("Property 'ModAssembly' not found in mod_meta.json");
        public string Name => Metadata.ContainsKey("Name") ? Metadata["Name"].ToString().SplitPascalCase() : string.Empty;
        public string CleanedUpName => Name.Replace("Dredge ", "").Replace("DREDGE ", "").Trim();
        public string Author => Metadata.ContainsKey("Author") ? Metadata["Author"].ToString() : string.Empty;
        public string Version => Metadata.ContainsKey("Version") ? Metadata["Version"].ToString() : throw new MissingFieldException("No 'Version' field found in Mod Metadata.");
        public string MinWinchVersion => Metadata.ContainsKey("MinWinchVersion") ? Metadata["MinWinchVersion"].ToString() : string.Empty;
        public string[] Dependencies => Metadata.ContainsKey("Dependencies") ? (((JArray)Metadata["Dependencies"]).ToObject<string[]>() ?? Array.Empty<string>()) : Array.Empty<string>();
        public string Preload => Metadata.ContainsKey("Preload") ? Metadata["Preload"].ToString() : string.Empty;
        public string Entrypoint => Metadata.ContainsKey("Entrypoint") ? Metadata["Entrypoint"].ToString() : string.Empty;
        public bool ApplyPatches => Metadata.ContainsKey("ApplyPatches") && (bool)Metadata["ApplyPatches"];
        public ModConfig? Config => ModConfig.TryGetConfig(GUID, out var config) ? config : null;

        private ModAssembly(string basePath) {
            BasePath = basePath;

            string metaPath = Path.Combine(basePath, "mod_meta.json");
            if (!File.Exists(metaPath))
                throw new FileNotFoundException("Missing mod_meta.json file.");

            string metaText = File.ReadAllText(metaPath);
            Metadata = JsonConvert.DeserializeObject<Dictionary<string, object>>(metaText) ?? throw new InvalidOperationException("Unable to parse mod_meta.json file.");
        }

        internal static ModAssembly FromPath(string path)
        {
            return new ModAssembly(path);
        }

        
        internal void LoadAssembly()
        {
            string assemblyRelativePath = AssemblyRelativePath;
            string assemblyPath = Path.Combine(BasePath, assemblyRelativePath);
            if(!File.Exists(assemblyPath))
                throw new FileNotFoundException($"Could not find mod assembly '{assemblyPath}'");

            CheckCompatibility();

            LoadedAssembly = Assembly.LoadFrom(assemblyPath);

            WinchCore.Log.Debug($"Loaded Assembly '{LoadedAssembly.GetName().Name}'.");

			if (Metadata.ContainsKey("Preload"))
			{
				ProcessPreload();
			}
        }

        internal void ExecuteAssembly()
        {
            if (LoadedAssembly == null)
                throw new NullReferenceException("Cannot execute assembly as LoadedAssembly is null");

            WinchCore.Log.Debug($"Initializing ModAssembly {LoadedAssembly.GetName().Name}...");

            if (Metadata.ContainsKey("Dependencies"))
                ProcessDependencies();

            if (Metadata.ContainsKey("Entrypoint"))
                ProcessEntrypoint();
        }

        internal void CheckCompatibility()
        {
            if (!VersionUtil.ValidateVersion(Version))
                throw new FormatException("Mod Version has invalid format.");

            if (GUID.IsNullOrWhitespace())
                throw new MissingFieldException("No 'ModGUID' field found in Mod Metadata.");

            string minVer = MinWinchVersion;
            if (minVer.IsNullOrWhitespace())
                WinchCore.Log.Warn($"No MinWinchVersion defined. Mod will load anyway, but version conflicts may occur!");
            else
            {
                string winchVer = VersionUtil.GetVersion();

                if (!VersionUtil.ValidateVersion(minVer))
                    throw new FormatException("MinWinchVersion not in correct format.");

                if (!VersionUtil.IsSameOrNewer(winchVer, minVer))
                    throw new Exception("Mod requires a version of Winch higher than the one installed.");
            }
        }



        private void ProcessDependencies()
        {
            string[] deps = Dependencies;
            foreach (string dep in deps)
            {
                WinchCore.Log.Debug($"Processing dependency {dep}");
                string depName = dep.Contains("@") ? dep.Split('@')[0] : dep;
                string? depVersion = dep.Contains("@") ? dep.Split('@')[1] : null;
                ModAssemblyLoader.ExecuteModAssembly(depName, depVersion);
            }
        }

        private void ProcessEntrypoint()
        {
            string entrypointSetting = Entrypoint;
            if (!entrypointSetting.Contains("/"))
                throw new ArgumentException("Malformed Entrypoint in mod_meta.json");

            string entrypointTypeName = entrypointSetting.Split('/')[0];
            string entrypointMethodName = entrypointSetting.Split('/')[1];

            Type entrypointType = LoadedAssembly?.GetType(entrypointTypeName) ?? 
                                  throw new EntryPointNotFoundException($"Could not find type {entrypointTypeName} in Mod Assembly");
            MethodInfo entrypoint = entrypointType.GetMethod(entrypointMethodName) ?? 
                                    throw new EntryPointNotFoundException($"Could not find method {entrypointTypeName} in type {entrypointTypeName} in Mod Assembly");

            WinchCore.Log.Debug($"Invoking entrypoint {entrypointType}.{entrypointMethodName}...");
            entrypoint.Invoke(null, new object[0]);
        }

		private void ProcessPreload()
		{
			string preloadSetting = Preload;
			if (!preloadSetting.Contains("/"))
				throw new ArgumentException("Malformed Preload in mod_meta.json");

			string preloadTypeName = preloadSetting.Split('/')[0];
			string preloadMethodName = preloadSetting.Split('/')[1];

			Type preloaderType = LoadedAssembly?.GetType(preloadTypeName) ??
								  throw new EntryPointNotFoundException($"Could not find type {preloadTypeName} in Mod Assembly");
			MethodInfo preloader = preloaderType.GetMethod(preloadMethodName) ??
									throw new EntryPointNotFoundException($"Could not find method {preloadTypeName} in type {preloadTypeName} in Mod Assembly");

			WinchCore.Log.Debug($"Invoking preloader {preloaderType}.{preloadMethodName}...");
			preloader.Invoke(null, new object[0]);
		}

		public override string ToString() => GUID;
	}
}
