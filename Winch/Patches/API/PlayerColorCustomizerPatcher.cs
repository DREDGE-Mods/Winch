using System;
using CommandTerminal;
using HarmonyLib;
using UnityEngine;
using Winch.Core;
using Winch.Data.Boat;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(PlayerColorCustomizer))]
internal static class PlayerColorCustomizerPatcher
{
    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(nameof(PlayerColorCustomizer.RefreshBoatColors))]
    public static bool RefreshBoatColors_Prefix(PlayerColorCustomizer __instance)
    {
        var roofColor = SaveUtil.ActiveSaveData.TryGetBoatRoofColor(out string moddedRoofColor) && BoatUtil.TryGetBoatPaintData(moddedRoofColor, out BoatPaintData roofPaintData) ? roofPaintData.color : __instance.roofColors[GameManager.Instance.SaveData.RoofColorIndex];
        __instance.meshRenderers.ForEach(meshRenderer =>
        {
            meshRenderer.materials[0].SetColor("_Roof_Color", roofColor);
        });
        __instance.buntingMeshRenderers.ForEach(meshRenderer =>
        {
            meshRenderer.materials[0].SetColor("_Roof_Color", roofColor);
        });


        var hullColor = SaveUtil.ActiveSaveData.TryGetBoatHullColor(out string moddedHullColor) && BoatUtil.TryGetBoatPaintData(moddedHullColor, out BoatPaintData hullPaintData) ? hullPaintData.color : __instance.hullColors[GameManager.Instance.SaveData.HullColorIndex];
        __instance.meshRenderers.ForEach(meshRenderer =>
        {
            meshRenderer.materials[0].SetColor("_Hull_Color", hullColor);
        });
        __instance.buntingMeshRenderers.ForEach(meshRenderer =>
        {
            meshRenderer.materials[0].SetColor("_Hull_Color", hullColor);
        });
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(nameof(PlayerColorCustomizer.RefreshBoatFlag))]
    public static bool RefreshBoatFlag_Prefix(PlayerColorCustomizer __instance)
    {
        if (SaveUtil.ActiveSaveData.TryGetBoatFlagStyle(out string moddedStyle) && BoatUtil.TryGetBoatFlagData(moddedStyle, out BoatFlagData boatFlagData))
        {
            __instance.flagObjects.ForEach(WinchExtensions.Activate);
            var flagMaterial = boatFlagData.FlagMaterial;
            __instance.flagMeshRenderers.ForEach(flagMeshRenderer => flagMeshRenderer.material = flagMaterial);
            return false;
        }
        return true;
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(DredgeDialogueRunner), nameof(DredgeDialogueRunner.DebugChangeBoatColor))]
    public static bool DebugChangeBoatColor_Prefix(CommandArg[] args)
    {
        BoatUtil.ChangeBoatColor((BoatArea)args[0].Int, args[1].String);
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(DredgeDialogueRunner), nameof(DredgeDialogueRunner.DebugChangeBoatFlag))]
    public static bool DebugChangeBoatFlag_Prefix(CommandArg[] args)
    {
        BoatUtil.ChangeBoatFlag(args[1].String);
        return false;
    }
}
