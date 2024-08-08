using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
	[HarmonyPatch]
	internal static class SpeakerDataLoadPatcher
	{
		[HarmonyPostfix]
		[HarmonyPatch(typeof(DredgeDialogueView), nameof(DredgeDialogueView.Awake))]
		public static void Postfix(DredgeDialogueView __instance)
        {
            CharacterUtil.AddModdedSpeakerData(__instance);
            CharacterUtil.PopulateSpeakerData(__instance);
        }
    }
}