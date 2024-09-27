using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(SpeakerButton), nameof(SpeakerButton.Init))]
internal static class SpeakerButtonInitPatcher
{
    public static bool Prefix(SpeakerButton __instance, SpeakerData speakerData, string yarnRootNode, bool highlightThis)
    {
        __instance.speakerData = speakerData;
        __instance.yarnRootNode = yarnRootNode;
        __instance.questAttentionCallout.SetActive(highlightThis);
        Sprite smallPortraitSprite = speakerData.smallPortraitSprite;
        if (speakerData.portraitOverrideConditions.Count > 0)
        {
            // Allow smallPortraitSprite for manual states
            PortraitOverride portraitOverride = speakerData.portraitOverrideConditions.Find((PortraitOverride po) => po.useManualState ? (GameManager.Instance.SaveData.GetIntVariable(po.stateName) == po.stateValue) : po.nodesVisited.All((string n) => GameManager.Instance.DialogueRunner.GetHasVisitedNode(n)));
            if (portraitOverride.smallPortraitSprite != null)
            {
                smallPortraitSprite = portraitOverride.smallPortraitSprite;
            }
        }
        __instance.speakerPortraitImage.sprite = smallPortraitSprite;
        __instance.localizedSpeakerNameField.StringReference.SetReference(LanguageManager.CHARACTER_TABLE, speakerData.speakerNameKey);
        return false;
    }
}