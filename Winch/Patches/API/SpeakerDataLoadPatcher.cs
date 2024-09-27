using HarmonyLib;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DredgeDialogueView), nameof(DredgeDialogueView.Awake))]
internal static class SpeakerDataLoadPatcher
{
    public static void Prefix(DredgeDialogueView __instance)
    {
        var speakerDataLookupTable = __instance.speakerDataLookup.lookupTable;
        CharacterUtil.AddModdedSpeakerData(speakerDataLookupTable);
        DredgeEvent.AddressableEvents.SpeakersLoaded.Trigger(__instance, speakerDataLookupTable, true);
    }

    public static void Postfix(DredgeDialogueView __instance)
    {
        var speakerDataLookupTable = __instance.speakerDataLookup.lookupTable;
        DredgeEvent.AddressableEvents.SpeakersLoaded.Trigger(__instance, speakerDataLookupTable, false);
        CharacterUtil.PopulateSpeakerData(speakerDataLookupTable);
    }
}
