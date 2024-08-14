using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(DataLoader))]
    [HarmonyPatch(nameof(DataLoader.OnGameEnded))]
    class WorldEventClearPatcher
    {
        public static void Postfix(DataLoader __instance)
        {
            WorldEventUtil.ClearWorldEventData();
        }
    }
}
