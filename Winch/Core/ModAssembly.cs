using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            if (!Metadata.ContainsKey("ModAssembly"))
                throw new MissingFieldException("Property 'ModAssembly' not found in mod_meta.json");

            string assemblyName = Metadata["ModAssembly"].ToString();
            string assemblyPath = Path.Combine(BasePath, assemblyName);
            if(!File.Exists(assemblyPath))
                throw new FileNotFoundException($"Could not find mod assembly '{assemblyPath}'");

            CheckCompatibility();

            string modConfig = Path.Combine("Config", Path.GetFileName(BasePath));
            WinchCore.Log.Debug($"Checking path: {modConfig}");
            if (!Directory.Exists(modConfig))
                Directory.CreateDirectory(modConfig);

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

            if (Metadata.ContainsKey("DefaultConfig"))
                ProcessDefaultConfig();

            if (Metadata.ContainsKey("Dependencies"))
                ProcessDependencies();

            if (Metadata.ContainsKey("Entrypoint"))
                ProcessEntrypoint();
        }

        internal void CheckCompatibility()
        {

            if (!Metadata.ContainsKey("Version"))
                throw new MissingFieldException("No 'Version' field found in Mod Metadata.");
            else if (!VersionUtil.ValidateVersion(Metadata["Version"].ToString()))
                throw new FormatException("Mod Version has invalid format.");

            if (!Metadata.ContainsKey("ModGUID"))
                throw new MissingFieldException("No 'ModGUID' field found in Mod Metadata.");

            if (!Metadata.ContainsKey("MinWinchVersion"))
                WinchCore.Log.Warn($"No MinWinchVersion defined. Mod will load anyway, but version conflicts may occur!");
            else
            {
                string minVer = Metadata["MinWinchVersion"].ToString();
                string winchVer = VersionUtil.GetVersion();

                if (!VersionUtil.ValidateVersion(minVer))
                    throw new FormatException("MinWinchVersion not in correct format.");

                if (!VersionUtil.IsSameOrNewer(winchVer, minVer))
                    throw new Exception("Mod requires a version of Winch higher than the one installed.");
            }
        }



        private void ProcessDependencies()
        {
            string[] deps = ((JArray)Metadata["Dependencies"]).ToObject<string[]>() ?? Array.Empty<string>();
            foreach (string dep in deps)
            {
                WinchCore.Log.Debug($"Processing dependency {dep}");
                string depName = dep.Contains("@") ? dep.Split('@')[0] : dep;
                string? depVersion = dep.Contains("@") ? dep.Split('@')[1] : null;
                ModAssemblyLoader.ExecuteModAssembly(depName, depVersion);
            }
        }

        private void ProcessDefaultConfig()
        {
            string defaultConfig = JsonConvert.SerializeObject(Metadata["DefaultConfig"], Formatting.Indented);
            string modName = Path.GetFileName(BasePath);
            ModConfig.RegisterDefaultConfig(modName, defaultConfig);
        }

        private void ProcessEntrypoint()
        {
            string entrypointSetting = Metadata["Entrypoint"].ToString();
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
			string preloadSetting = Metadata["Preload"].ToString();
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
    }
}
