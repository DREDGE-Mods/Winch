using HarmonyLib;
using System.CodeDom.Compiler;
using System.Threading;
using UnityEngine.Localization.Settings;
using Winch.Core;

namespace Winch.Patches
{

    /// <summary>
    /// Was on Wait for game managers or whatever before but that gives this error:
    /// </summary>
    /*
    Failed to initialize mods UnityEngine.UnityException: Internal_CreateGameObject can only be called from the main thread.
    Constructors and field initializers will be executed from the loading thread when loading a scene.
    Don't use this function in the constructor or field initializers, instead move initialization code to the Awake or Start function.
    at(wrapper managed-to-native) UnityEngine.GameObject.Internal_CreateGameObject(UnityEngine.GameObject, string)
    at UnityEngine.GameObject..ctor()[0x00008] in <fbf5779b092846b08cf20985bc90dcd0>:0 
    at Winch.Core.Initializer.InitializeAssetLoader() [0x00000] in C:\GitHub\Winch\Winch\Core\Initializer.cs:41 
    at Winch.Core.Initializer.Initialize() [0x0000f] in C:\GitHub\Winch\Winch\Core\Initializer.cs:21 
    */
    internal static class GameLoadPatcher
    {
        public static void Postfix()
        {
            WinchCore.Log.Info("Game loaded, initializing Winch...");
            Initializer.Initialize();
            WinchCore.Log.Info("Winch initialized successfully.");
        }
    }
}
