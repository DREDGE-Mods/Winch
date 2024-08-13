using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Winch.Config;

namespace Winch.Core
{
    /// <summary>
    /// Paths used by Winch
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// The path to the Winch DLL.
        /// </summary>
        public static string WinchPath { get; private set; }

        /// <summary>
        /// The path to the folder of the Winch DLL.
        /// </summary>
        public static string WinchRootPath { get; private set; }

        /// <summary>
        /// The path to the Managed folder that contains the main managed assemblies.
        /// </summary>
        public static string ManagedPath { get; private set; }

        /// <summary>
        /// The path to the game data folder of the currently running Unity game.
        /// </summary>
        public static string GameDataPath { get; private set; }

        /// <summary>
        /// The path of the currently executing program Winch is encapsulated in.
        /// </summary>
        public static string ExecutablePath { get; private set; }

        /// <summary>
        /// The directory that the currently executing process resides in.
        /// </summary>
        public static string GameRootPath { get; private set; }

        /// <summary>
        /// The path to the mods folder which resides in the game root folder.
        /// </summary>
        public static string ModsPath { get; private set; }

        /// <summary>
        /// The name of the currently executing process.
        /// </summary>
        public static string ProcessName { get; private set; }

        /// <summary>
        /// List of directories from where Mono will search assemblies before assembly resolving is invoked.
        /// </summary>
        public static string[] DllSearchPaths { get; private set; }

        static Paths()
        {
            string executablePath = EnvVars.DOORSTOP_PROCESS_PATH;
            string winchPath = Path.GetFullPath(EnvVars.DOORSTOP_INVOKE_DLL_PATH);
            string managedPath = EnvVars.DOORSTOP_MANAGED_FOLDER_DIR;
            bool gameDataRelativeToManaged = true;
            string[] dllSearchPath = EnvVars.DOORSTOP_DLL_SEARCH_DIRS;


            WinchPath = winchPath;

            WinchRootPath = Path.GetDirectoryName(winchPath);

            ExecutablePath = executablePath;

            ProcessName = Path.GetFileNameWithoutExtension(executablePath);

            GameRootPath = Path.GetDirectoryName(executablePath);

            GameDataPath = managedPath != null && gameDataRelativeToManaged
                               ? Path.GetDirectoryName(managedPath)
                               : Path.Combine(GameRootPath, $"{ProcessName}_Data");

            ManagedPath = managedPath ?? Path.Combine(GameDataPath, "Managed");

            ModsPath = Path.Combine(WinchRootPath, "Mods");

            DllSearchPaths = (dllSearchPath ?? new string[0]).Concat(new[] { ManagedPath }).Distinct().ToArray();

            UnityInfo.Initialize(ExecutablePath, GameDataPath);
        }
    }
}
