using HarmonyLib;
using Winch.Core;

namespace Winch.Patches
{
    internal static class BuildInfoFeaturePatcher
    {
        public static bool Prefix() {
            WinchCore.Log.Debug("Disallowed Feature Enable Commands to be added to Terminal.");
            return false;
        }
    }
}
