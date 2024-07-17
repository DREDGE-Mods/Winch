using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    class SpeakerDataLoadPatcher
    {
        public static void Postfix(DredgeDialogueView __instance)
        {
            CharacterUtil.AddModdedSpeakerData(__instance);
            CharacterUtil.PopulateSpeakerData(__instance);
        }
    }
}