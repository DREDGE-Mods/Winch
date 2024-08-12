using CommandTerminal;
using UnityEngine;
using Winch.Config;

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
    }
}
