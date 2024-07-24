using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    /// <summary>
    /// See <see cref="LatePatcher.Initialize"/> for details on why this doesn't have attributes
    /// </summary>
    internal static class SpeakerDataLoadPatcher
    {
        public static void Postfix(DredgeDialogueView __instance)
        {
            CharacterUtil.AddModdedSpeakerData(__instance);
            CharacterUtil.PopulateSpeakerData(__instance);
        }
    }
}