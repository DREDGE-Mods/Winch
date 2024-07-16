using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(ItemManager))]
    [HarmonyPatch(nameof(ItemManager.OnGameEnded))]
    class ItemClearPatcher
    {
        public static void Postfix(ItemManager __instance)
        {
            ItemUtil.ClearItemData();
        }
    }
}
