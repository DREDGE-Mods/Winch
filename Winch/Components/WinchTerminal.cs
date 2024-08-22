using CommandTerminal;
using System;
using UnityEngine;
using Winch.Config;
using Winch.Core;
using Winch.Util;

namespace Winch.Components
{
    [RequireComponent(typeof(Terminal))]
    internal class WinchTerminal : MonoBehaviour
    {
        public bool Enabled => WinchConfig.GetProperty("EnableDeveloperConsole", false);

        private Terminal terminal;

        public void Start()
        {
            terminal = GetComponent<Terminal>();
        }

        public void Update()
        {
            terminal.enabled = Enabled;
        }

        public void OnEnable()
        {
            WinchCore.Log.Debug("Registering commands.");
            try
            {
                Terminal.Shell.RegisterCommands(WinchCore.WinchAssembly);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to apply late winch patches: {ex}");
            }

            foreach(ModAssembly modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
            {
                ModAssemblyLoader.ForceModContext(modAssembly);
                try
                {
                    if (modAssembly.LoadedAssembly != null)
                    {
                        Terminal.Shell.RegisterCommands(modAssembly.LoadedAssembly);
                    }
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error($"Failed to register terminal commands for {modAssembly.BasePath}: {ex}");
                }
                ModAssemblyLoader.ClearModContext();
            }
            WinchCore.Log.Debug("Command registering complete.");
        }
    }
}
