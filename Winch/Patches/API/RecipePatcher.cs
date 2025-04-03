using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using Winch.Components;
using Winch.Data.Recipe;
using Winch.Util;
using static TooltipUI;
using Label = System.Reflection.Emit.Label;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class RecipePatcher
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ItemProductPanel), nameof(ItemProductPanel.Show))]
    public static void ItemProductPanel_Show_Postfix(ItemProductPanel __instance)
    {
        // Resize golden outline based on grid config size.
        var gridConfig = __instance.questGridConfig.gridConfiguration;
        var width = gridConfig.columns / 4f;
        var height = gridConfig.rows / 4f;
        var goldenSquareOutline = (RectTransform)(__instance.gridUI.transform.Find("BackgroundImage"));
        goldenSquareOutline.localScale = new Vector3(width, height, 1);

        // Change y position of header based on grid config height.
        var diff = Mathf.Max(0, gridConfig.rows - 4f);
        var header = (RectTransform)(__instance.container.transform.Find("ItemProductHeaderText"));
        header.SetAnchoredPosY(250f + ((50 / 3f) * diff));

    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(ConstructableDestinationUI), nameof(ConstructableDestinationUI.OnRecipeGridPanelExitEvent))]
    public static IEnumerable<CodeInstruction> ConstructableDestinationUI_OnRecipeGridPanelExitEvent_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(ConstructableDestinationUI), nameof(ConstructableDestinationUI.currentTier))),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(BaseDestinationTier), nameof(BaseDestinationTier.tierId))),
            new CodeMatch(OpCodes.Ldc_I4_1),
            new CodeMatch(OpCodes.Ldc_I4_0)
        ).InsertAndAdvance(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(ConstructableDestinationUI), nameof(ConstructableDestinationUI.currentTier))),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(BaseDestinationTier), nameof(BaseDestinationTier.tierId))),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(ConstructableBuildingUtil), nameof(ConstructableBuildingUtil.IsTierImmediate)))
        ).RemoveInstruction();

        return matcher.InstructionEnumeration();
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ConstructableDestinationUI), nameof(ConstructableDestinationUI.OnBuildingTabChanged))]
    public static void ConstructableDestinationUI_OnBuildingTabChanged_Postfix(ConstructableDestinationUI __instance, int tabIndex)
    {
        if (__instance.currentViewState == ConstructableDestinationUI.ConstructionViewState.BUILDING_CONSTRUCTION_COMPLETE)
        {
            // Fix soft lock that happens when there is no dialogue
            if (string.IsNullOrEmpty(__instance.dialogueNodeName) || !GameManager.Instance.DialogueRunner.NodeExists(__instance.dialogueNodeName))
            {
                __instance.FireInNUpdates(
                    __instance.currentTier.viewAfterConstruction == ConstructableDestinationUI.ConstructionViewState.NONE
                        ? __instance.OnLeavePressComplete
                        : __instance.OnPostConstructionDialogueComplete,
                        100); // Needs to be a lot of frames later for some reason
            }
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(TooltipSectionHeader), nameof(TooltipSectionHeader.Init), new System.Type[1] { typeof(TextTooltipRequester) })]
    public static void TooltipSectionHeader_Init_Prefix(TooltipSectionHeader __instance, TextTooltipRequester textTooltipRequester)
    {
        __instance.isLayedOut = false;
        if (__instance.iconImage != null)
        {
            // for whatever reason, the icon field exists but is never used
            var icon = textTooltipRequester.Icon;
            if (icon == null)
            {
                __instance.iconImage.enabled = false;
            }
            else
            {
                __instance.iconImage.sprite = icon;
                __instance.iconImage.enabled = true;
            }
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(TooltipSectionHeader), nameof(TooltipSectionHeader.Init), new System.Type[1] { typeof(UpgradeData) })]
    public static void TooltipSectionHeader_Init_Prefix(TooltipSectionHeader __instance, UpgradeData upgradeData)
    {
        // reset color because they forgot to do that here
        __instance.isLayedOut = false;
        __instance.headerTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.NEUTRAL);
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(TooltipSectionHeader), nameof(TooltipSectionHeader.RefreshString))]
    public static void TooltipSectionHeader_RefreshString_Prefix(TooltipSectionHeader __instance)
    {
        // reset color because they forgot to do that here
        __instance.headerTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.NEUTRAL);
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(TooltipUpgradeCostIcon), nameof(TooltipUpgradeCostIcon.Init))]
    public static void TooltipUpgradeCostIcon_Init_Prefix(ref ItemData itemData)
    {
        // null check just in case
        if (itemData == null) itemData = ItemUtil.GetItemData("dmg");
    }

    #region Modded Recipes
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ConstructableDestinationUI), nameof(ConstructableDestinationUI.OnRecipeGridPanelExitEvent))]
    public static void ConstructableDestinationUI_OnRecipeGridPanelExitEvent_Postfix(ConstructableDestinationUI __instance, RecipeData recipeData)
    {
        if (recipeData == null) return;

        if (recipeData is SlotRecipeData slotRecipeData)
        {
            GameManager.Instance.UpgradeManager.AddUpgrade(slotRecipeData.slotUpgradeData, free: false);
            __instance.OnBuildingTabChanged(__instance.buildingTabbedPanel.CurrentIndex);
        }
        if (recipeData is ModdedRecipeData moddedRecipeData)
        {
            moddedRecipeData.OnRecipeCompleted();
            __instance.OnBuildingTabChanged(__instance.buildingTabbedPanel.CurrentIndex);
        }
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(ConstructableItemUI), nameof(ConstructableItemUI.Init))]
    public static IEnumerable<CodeInstruction> ConstructableItemUI_Init_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(UpgradeData), nameof(UpgradeData.tier))),
            new CodeMatch(OpCodes.Box, typeof(int)),
            new CodeMatch(OpCodes.Stelem_Ref),
            new CodeMatch(OpCodes.Stloc_0),
            new CodeMatch(OpCodes.Ldarg_1)
        ).CreateLabel(out Label end).Start();

        matcher.MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_1),
            new CodeMatch(OpCodes.Isinst, typeof(HullRecipeData)),
            new CodeMatch(OpCodes.Brfalse)
        ).CreateLabel(out Label hull);

        matcher.Insert(
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(SlotRecipeData)),
            new CodeInstruction(OpCodes.Brfalse, hull),
            new CodeInstruction(OpCodes.Ldc_I4_1),
            new CodeInstruction(OpCodes.Newarr, typeof(object)),
            new CodeInstruction(OpCodes.Dup),
            new CodeInstruction(OpCodes.Ldc_I4_0),
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(SlotRecipeData)),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(SlotRecipeData), nameof(SlotRecipeData.slotUpgradeData))),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(UpgradeData), nameof(UpgradeData.GetNewCellCount))),
            new CodeInstruction(OpCodes.Box, typeof(int)),
            new CodeInstruction(OpCodes.Stelem_Ref),
            new CodeInstruction(OpCodes.Stloc_0),
            new CodeInstruction(OpCodes.Br_S, end)
        );

        return matcher.InstructionEnumeration();
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(RecipeEntry), nameof(RecipeEntry.Awake))]
    public static void RecipeEntry_Awake_Prefix(RecipeEntry __instance)
    {
        __instance.spatialItemTooltipRequester.GetOrAddComponent<ModdedRecipeTooltipRequester>().enabled = false;
        var upgrade = __instance.upgradeTooltipRequester;
        var upgradeRecipe = upgrade.GetOrAddComponent<UpgradeRecipeTooltipRequester>();
        upgradeRecipe.enabled = false;
        __instance.upgradeTooltipRequester = upgradeRecipe;
        upgrade.DestroyImmediate();
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(RecipeEntry), nameof(RecipeEntry.OnRecipeEntryClicked))]
    public static bool RecipeEntry_OnRecipeEntryClicked_Prefix(RecipeEntry __instance)
    {
        if (__instance.recipeData is HullRecipeData hullRecipeData && GameManager.Instance.SaveData.GetIsUpgradeOwned(hullRecipeData.hullUpgradeData))
        {
            GameManager.Instance.UI.ShowNotificationWithItemName(NotificationType.ERROR, "notification.already-researched-ability", hullRecipeData.GetItemNameKey(), GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.EMPHASIS), hullRecipeData.hullUpgradeData.tier);
            return false;
        }
        if (__instance.recipeData is SlotRecipeData slotRecipeData && GameManager.Instance.SaveData.GetIsUpgradeOwned(slotRecipeData.slotUpgradeData))
        {
            GameManager.Instance.UI.ShowNotificationWithItemName(NotificationType.ERROR, "notification.already-researched-ability", slotRecipeData.GetItemNameKey(), GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.EMPHASIS), slotRecipeData.slotUpgradeData.GetNewCellCount());
            return false;
        }
        if (__instance.recipeData is ModdedRecipeData moddedRecipeData && moddedRecipeData.IsOneTimeAndAlreadyOwned())
        {
            GameManager.Instance.UI.ShowNotificationWithItemName(NotificationType.ERROR, "notification.already-researched-ability", moddedRecipeData.GetItemNameKey(), GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.EMPHASIS));
            return false;
        }
        return true;
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(BannerUI), nameof(BannerUI.ShowUpgrade))]
    public static IEnumerable<CodeInstruction> BannerUI_ShowUpgrade_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.Start().MatchEndForward(
            new CodeMatch(OpCodes.Ldarg_1),
            new CodeMatch(OpCodes.Isinst, typeof(HullUpgradeData)),
            new CodeMatch(OpCodes.Brfalse),
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(BannerUI), nameof(BannerUI.image)))
        ).Advance(1);
        var hullStart = matcher.Pos;
        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Ldarg_1),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(UpgradeData), nameof(UpgradeData.tier))),
            new CodeMatch(OpCodes.Ldc_I4_2),
            new CodeMatch(OpCodes.Sub)
        ).Advance(1);
        var hullEnd = matcher.Pos;
        matcher.Start().RemoveInstructionsWithOffsets(hullStart, hullEnd).Advance(hullStart).Insert(
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(HullUpgradeData)),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(HullUpgradeData), nameof(HullUpgradeData.hullSprite)))
        );

        return matcher.InstructionEnumeration();
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(TooltipUI), nameof(TooltipUI.OnUITooltipRequested))]
    public static IEnumerable<CodeInstruction> TooltipUI_OnUITooltipRequested_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_1),
            new CodeMatch(OpCodes.Isinst, typeof(UpgradeTooltipRequester)),
            new CodeMatch(OpCodes.Brfalse)
        ).CreateLabel(out Label notUpgradeRecipe);

        matcher.Insert(
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(UpgradeRecipeTooltipRequester)),
            new CodeInstruction(OpCodes.Brfalse_S, notUpgradeRecipe),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(UpgradeRecipeTooltipRequester)),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.ConstructUpgradeTooltip),
                new System.Type[2] { typeof(TooltipUI), typeof(UpgradeRecipeTooltipRequester) })),
            new CodeInstruction(OpCodes.Ret)
        ).CreateLabel(out Label toUpgradeRecipe);

        matcher.MatchEndBackwards(
            new CodeMatch(OpCodes.Ldarg_1),
            new CodeMatch(OpCodes.Isinst),
            new CodeMatch(OpCodes.Brfalse)
        ).Operand = toUpgradeRecipe;

        return matcher.InstructionEnumeration();
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(TooltipUI), nameof(TooltipUI.ConstructTextTooltip))]
    public static bool TooltipUI_ConstructTextTooltip_Prefix(TooltipUI __instance, TextTooltipRequester tooltipRequester, TooltipMode tooltipMode)
    {
        __instance.PrepareForTooltipShow();
        if (tooltipRequester.Icon != null)
        {
            __instance.activeTooltipSections.Add(__instance.itemHeaderWithIcon);
            __instance.itemHeaderWithIcon.Init(tooltipRequester);
        }
        else
        {
            __instance.activeTooltipSections.Add(__instance.itemHeaderWithoutIcon);
            __instance.itemHeaderWithoutIcon.Init(tooltipRequester);
        }
        if (tooltipRequester is ModdedRecipeTooltipRequester moddedRecipeTooltipRequester)
        {
            var recipeData = moddedRecipeTooltipRequester.RecipeData;
            if (recipeData != null)
            {
                if (!recipeData.IsOneTimeAndAlreadyOwned())
                {
                    __instance.activeTooltipSections.Add(__instance.upgradeCost);
                    __instance.upgradeCost.Init(recipeData);
                    __instance.activeTooltipSections.Add(__instance.controlPrompts);
                    __instance.controlPrompts.Init();
                }
            }
        }
        __instance.activeTooltipSections.Add(__instance.description);
        __instance.description.Init(tooltipRequester);
        if (__instance.layoutCoroutine != null)
        {
            __instance.StopCoroutine(__instance.layoutCoroutine);
        }
        __instance.layoutCoroutine = __instance.StartCoroutine(__instance.DoUpdateLayoutGroups());
        return false;
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(RecipeEntry), nameof(RecipeEntry.RefreshUI), new System.Type[0])]
    public static IEnumerable<CodeInstruction> RecipeEntry_RefreshUI_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameManager), nameof(GameManager.Instance))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(GameManager), nameof(GameManager.SaveData))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(SaveData), nameof(SaveData.HullTier)))
        );
        var hullStart = matcher.Pos;
        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Clt),
            new CodeMatch(OpCodes.Ldc_I4_0),
            new CodeMatch(OpCodes.Ceq)
        );
        var hullEnd = matcher.Pos;
        matcher.Start().RemoveInstructionsWithOffsets(hullStart, hullEnd).Advance(hullStart).Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(GameManager), nameof(GameManager.Instance))),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(GameManager), nameof(GameManager.SaveData))),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Isinst, typeof(HullRecipeData)),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(HullRecipeData), nameof(HullRecipeData.hullUpgradeData))),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(SaveData), nameof(SaveData.GetIsUpgradeOwned)))
        );

        matcher.Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.alreadyOwnedIcon))),
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.isOneTimeAndAlreadyOwned)))
        ).CreateLabel(out Label end);

        matcher.Start().MatchEndForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldc_I4_0),
            new CodeMatch(OpCodes.Stfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.isOneTimeAndAlreadyOwned))),
            new CodeMatch(OpCodes.Ldarg_0)
        ).CreateLabel(out Label ability);

        matcher.Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Ldnull),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(UnityEngine.Object), "op_Inequality")),
            new CodeInstruction(OpCodes.Brfalse_S, ability),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Isinst, typeof(ModdedRecipeData)),
            new CodeInstruction(OpCodes.Brfalse_S, ability),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Isinst, typeof(ModdedRecipeData)),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(ModdedRecipeData), nameof(ModdedRecipeData.IsOneTimeAndAlreadyOwned))),
            new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.isOneTimeAndAlreadyOwned))),
            new CodeInstruction(OpCodes.Br_S, end)
        ).CreateLabel(out Label modded);

        matcher.Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Ldnull),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(UnityEngine.Object), "op_Inequality")),
            new CodeInstruction(OpCodes.Brfalse_S, modded),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Isinst, typeof(SlotRecipeData)),
            new CodeInstruction(OpCodes.Brfalse_S, modded),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.recipeData))),
            new CodeInstruction(OpCodes.Isinst, typeof(SlotRecipeData)),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(SlotRecipeData), nameof(SlotRecipeData.IsOneTimeAndAlreadyOwned))),
            new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.isOneTimeAndAlreadyOwned))),
            new CodeInstruction(OpCodes.Br_S, end)
        );

        return matcher.InstructionEnumeration();
    }

    internal static void DisableAllRecipeTooltipRequesters(RecipeEntry entry)
    {
        var moddedRecipeTooltipRequester = entry.spatialItemTooltipRequester.GetComponent<ModdedRecipeTooltipRequester>();
        moddedRecipeTooltipRequester.enabled = false;
        entry.spatialItemTooltipRequester.enabled = false;
        entry.upgradeTooltipRequester.enabled = false;
        entry.abilityTooltipRequester.enabled = false;
    }

    internal static void DisableModdedRecipeTooltipRequester(RecipeEntry entry)
    {
        var moddedRecipeTooltipRequester = entry.spatialItemTooltipRequester.GetComponent<ModdedRecipeTooltipRequester>();
        moddedRecipeTooltipRequester.enabled = false;
    }

    internal static void EnableModdedRecipeTooltipRequester(RecipeEntry entry, ModdedRecipeData recipeData)
    {
        var moddedRecipeTooltipRequester = entry.spatialItemTooltipRequester.GetComponent<ModdedRecipeTooltipRequester>();
        entry.spatialItemTooltipRequester.enabled = false;
        entry.upgradeTooltipRequester.enabled = false;
        entry.abilityTooltipRequester.enabled = false;
        moddedRecipeTooltipRequester.enabled = true;
        moddedRecipeTooltipRequester.RecipeData = recipeData;
    }

    internal static void EnableSlotRecipeTooltipRequester(RecipeEntry entry, SlotRecipeData recipeData)
    {
        entry.spatialItemTooltipRequester.enabled = false;
        entry.abilityTooltipRequester.enabled = false;
        var upgradeRecipe = entry.upgradeTooltipRequester as UpgradeRecipeTooltipRequester;
        upgradeRecipe.recipeData = recipeData;
        upgradeRecipe.upgradeData = recipeData.slotUpgradeData;
        upgradeRecipe.enabled = true;
        DisableModdedRecipeTooltipRequester(entry);
    }

    internal static void EnableHullRecipeTooltipRequester(RecipeEntry entry, HullRecipeData recipeData)
    {
        entry.spatialItemTooltipRequester.enabled = false;
        entry.abilityTooltipRequester.enabled = false;
        var upgradeRecipe = entry.upgradeTooltipRequester as UpgradeRecipeTooltipRequester;
        upgradeRecipe.recipeData = recipeData;
        upgradeRecipe.upgradeData = recipeData.hullUpgradeData;
        upgradeRecipe.enabled = true;
        DisableModdedRecipeTooltipRequester(entry);
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(RecipeEntry), nameof(RecipeEntry.Init), new System.Type[1] { typeof(RecipeData) })]
    public static IEnumerable<CodeInstruction> RecipeEntry_Init_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        var notHullUpgrade = generator.DefineLabel();
        var notSlotUpgrade = generator.DefineLabel();
        var notModded = generator.DefineLabel();
        matcher.Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.spatialItemTooltipRequester))),
            new CodeMatch(OpCodes.Ldc_I4_1)
        ).Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RecipePatcher), nameof(DisableModdedRecipeTooltipRequester)))
        );
        matcher.MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.abilityTooltipRequester))),
            new CodeMatch(OpCodes.Ldc_I4_1)
        ).Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RecipePatcher), nameof(DisableModdedRecipeTooltipRequester)))
        );
        matcher.MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(RecipeEntry), nameof(RecipeEntry.canvasGroup)))
        );
        var notAbility = matcher.Labels.LastOrDefault();
        matcher.Labels = matcher.Labels.Take(1).ToList();
        matcher.CreateLabel(out Label end).InsertAndAdvance(
            new CodeInstruction(OpCodes.Br_S, end),
            new CodeInstruction(OpCodes.Ldarg_1)
        ).Advance(-1);
        matcher.Labels = new List<Label> { notAbility };
        matcher.Advance(1).InsertAndAdvance(
            new CodeInstruction(OpCodes.Isinst, typeof(SlotRecipeData)),
            new CodeInstruction(OpCodes.Brfalse_S, notSlotUpgrade),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(SlotRecipeData)),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RecipePatcher), nameof(EnableSlotRecipeTooltipRequester)))
        );
        matcher.InsertAndAdvance(
            new CodeInstruction(OpCodes.Br_S, end),
            new CodeInstruction(OpCodes.Ldarg_1)
        ).Advance(-1);
        matcher.Labels = new List<Label> { notSlotUpgrade };
        matcher.Advance(1).InsertAndAdvance(
            new CodeInstruction(OpCodes.Isinst, typeof(HullRecipeData)),
            new CodeInstruction(OpCodes.Brfalse_S, notHullUpgrade),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(HullRecipeData)),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RecipePatcher), nameof(EnableHullRecipeTooltipRequester)))
        );
        matcher.InsertAndAdvance(
            new CodeInstruction(OpCodes.Br_S, end),
            new CodeInstruction(OpCodes.Ldarg_1)
        ).Advance(-1);
        matcher.Labels = new List<Label> { notHullUpgrade };
        matcher.Advance(1).InsertAndAdvance(
            new CodeInstruction(OpCodes.Isinst, typeof(ModdedRecipeData)),
            new CodeInstruction(OpCodes.Brfalse_S, notModded),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Isinst, typeof(ModdedRecipeData)),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RecipePatcher), nameof(EnableModdedRecipeTooltipRequester))),
            new CodeInstruction(OpCodes.Br_S, end),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RecipePatcher), nameof(DisableAllRecipeTooltipRequesters)))
        ).Advance(-2).AddLabels(new Label[1] { notModded });

        return matcher.InstructionEnumeration();
    }
    #endregion
}
