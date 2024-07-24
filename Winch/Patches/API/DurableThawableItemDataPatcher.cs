using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using static Antlr4.Runtime.Atn.SemanticContext;

namespace Winch.Patches.API
{
    /// <summary>
    /// DREDGE devs sure do love to not check item data types.
    /// They do this a lot. Especially with DeployableItemData. Instead they check damageMode == DamageMode.DURABILITY.
    /// So lets fix that while we add the durable items.
    /// </summary>
    [HarmonyPatch]
    internal static class DurableThawableItemDataPatcher
    {
        [HarmonyPrefix]
        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(typeof(SpatialItemInstance), nameof(SpatialItemInstance.ChangeDurability))]
        public static bool SpatialItemInstance_ChangeDurability_Prefix(SpatialItemInstance __instance, float changeAmount)
        {
            var itemData = __instance.GetItemData<SpatialItemData>();
            if (itemData.damageMode == DamageMode.DURABILITY)
            {
                __instance.durability += changeAmount;
                if (itemData is DurableItemData durable && durable.IsDurable())
                {
                    __instance.durability = Mathf.Clamp(__instance.durability, 0f, durable.MaxDurabilityDays);
                }
                else if (itemData is DeployableItemData deployable)
                {
                    __instance.durability = Mathf.Clamp(__instance.durability, 0f, deployable.MaxDurabilityDays);
                }
            }
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(typeof(SpatialItemInstance), nameof(SpatialItemInstance.GetMissingDurabilityAmount))]
        public static bool SpatialItemInstance_GetMissingDurabilityAmount_Prefix(SpatialItemInstance __instance, ref float __result)
        {
            __result = 0;
            var itemData = __instance.GetItemData<SpatialItemData>();
            if (itemData.damageMode == DamageMode.DURABILITY)
            {
                if (itemData is DurableItemData durable && durable.IsDurable())
                {
                    __result = durable.MaxDurabilityDays - __instance.durability;
                }
                else if (itemData is DeployableItemData deployable)
                {
                    __result = deployable.MaxDurabilityDays - __instance.durability;
                }
            }
            return false;
        }

        /// <summary>
        /// See <see cref="LatePatcher.Initialize"/> for details on why this doesn't have attributes
        /// </summary>
        public static IEnumerable<CodeInstruction> ItemManager_GetItemValue_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var matcher = new CodeMatcher(instructions, generator).MatchForward(true,
                    new CodeMatch(OpCodes.Ldloc_0),
                    new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(SpatialItemData), nameof(SpatialItemData.damageMode))),
                    new CodeMatch(OpCodes.Ldc_I4_1),
                    new CodeMatch(OpCodes.Bne_Un)
                );
            var end = matcher.Instruction.operand;
            return matcher.Advance(1).Insert(
                    new CodeInstruction(OpCodes.Ldloc_0),
                    new CodeInstruction(OpCodes.Isinst, typeof(DeployableItemData)),
                    new CodeInstruction(OpCodes.Ldnull),
                    new CodeInstruction(OpCodes.Beq, end)
                ).CreateLabel(out Label check).Insert(
                    new CodeInstruction(OpCodes.Ldloc_0),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.IsDurable), new System.Type[] { typeof(SpatialItemData) })),
                    new CodeInstruction(OpCodes.Brfalse, check),
                    new CodeInstruction(OpCodes.Ldarg_1),
                    new CodeInstruction(OpCodes.Ldloc_0),
                    new CodeInstruction(OpCodes.Ldloc_3),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(DurableThawableItemDataPatcher), nameof(DurableThawableItemDataPatcher.GetDurableItemValue))),
                    new CodeInstruction(OpCodes.Stloc_3),
                    new CodeInstruction(OpCodes.Br, end)
                ).InstructionEnumeration();
        }

        public static decimal GetDurableItemValue(SpatialItemInstance instance, SpatialItemData itemData, decimal itemValue)
        {
            var durableItemData = (DurableItemData)itemData;
            return itemValue * ((decimal)Mathf.Clamp(instance.durability / durableItemData.MaxDurabilityDays, 0.1f, 1f));
        }

        /// <summary>
        /// See <see cref="LatePatcher.Initialize"/> for details on why this doesn't have attributes
        /// </summary>
        public static IEnumerable<CodeInstruction> GridManager_AddDamageToInventory_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var matcher = new CodeMatcher(instructions, generator).Start()
                .MatchForward(false,
                    new CodeMatch(OpCodes.Ldloc_S),
                    new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(GridCellData), nameof(GridCellData.spatialItemInstance))),
                    new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(SpatialItemInstance), nameof(SpatialItemInstance.durability)))
                );
            var instance = matcher.Instruction.operand;

            matcher.Start()
                .MatchForward(false,
                    new CodeMatch(OpCodes.Ldloc_S),
                    new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(SpatialItemData), nameof(SpatialItemData.damageMode))),
                    new CodeMatch(OpCodes.Ldc_I4_1),
                    new CodeMatch(OpCodes.Bne_Un)
                );
            var itemData = matcher.Instruction.operand;
            var end = matcher.Advance(3).Instruction.operand;
            matcher.Advance(1)
                .Insert(
                    new CodeInstruction(OpCodes.Ldloc_S, itemData),
                    new CodeInstruction(OpCodes.Isinst, typeof(DeployableItemData)),
                    new CodeInstruction(OpCodes.Ldnull),
                    new CodeInstruction(OpCodes.Beq, end)
                ).CreateLabel(out Label deployable)
                .Insert(
                    new CodeInstruction(OpCodes.Ldloc_S, itemData),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.IsDurable), new System.Type[] { typeof(SpatialItemData) })),
                    new CodeInstruction(OpCodes.Brfalse, deployable),
                    new CodeInstruction(OpCodes.Ldloc_S, instance),
                    new CodeInstruction(OpCodes.Ldloc_S, itemData),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(DurableThawableItemDataPatcher), nameof(DurableThawableItemDataPatcher.OnDurableDamageSustained))),
                    new CodeInstruction(OpCodes.Br, end)
                );
            return matcher.InstructionEnumeration();
        }

        public static void OnDurableDamageSustained(GridCellData gridCellData, SpatialItemData itemData)
        {
            var instance = gridCellData.spatialItemInstance;
            var durableItemData = (DurableItemData)itemData;
            instance.ChangeDurability(-durableItemData.MaxDurabilityDays * GameManager.Instance.GameConfigData.DeployableDamagePerHitProportional);
            if (instance.durability <= 0)
            {
                GameEvents.Instance.TriggerItemDestroyed(itemData, false);
                GameManager.Instance.SaveData.Inventory.RemoveObjectFromGridData(instance, true);
                GameManager.Instance.UI.ShowNotificationWithItemName(NotificationType.ITEM_REMOVED, "notification.damage-sustained-durability-lost", itemData.itemNameKey, DredgeColorTypeEnum.NEGATIVE);
            }
            else
                GameManager.Instance.UI.ShowNotificationWithItemName(NotificationType.DURABILITY_LOST, "notification.damage-sustained-durability-lost", itemData.itemNameKey, DredgeColorTypeEnum.NEGATIVE);
        }

        [HarmonyPatch]
        public static class ItemManager_CreateItem
        {
            public static MethodBase TargetMethod()
            {
                return AccessTools.Method(typeof(ItemManager), nameof(ItemManager.CreateItem), new System.Type[] { typeof(ItemData) }).MakeGenericMethod(typeof(ItemInstance));
            }

            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
            {
                return new CodeMatcher(instructions, generator).MatchForward(false,
                        new CodeMatch(OpCodes.Ldloc_1),
                        new CodeMatch(OpCodes.Isinst, typeof(DurableItemData))
                    ).CreateLabel(out Label durable)
                    .Start().MatchForward(true,
                        new CodeMatch(OpCodes.Ldloc_1),
                        new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(SpatialItemData), nameof(SpatialItemData.damageMode))),
                        new CodeMatch(OpCodes.Ldc_I4_1),
                        new CodeMatch(OpCodes.Bne_Un)
                    ).Advance(1)
                    .Insert(
                        new CodeInstruction(OpCodes.Ldloc_1),
                        new CodeInstruction(OpCodes.Isinst, typeof(DeployableItemData)),
                        new CodeInstruction(OpCodes.Ldnull),
                        new CodeInstruction(OpCodes.Beq, durable)
                    ).InstructionEnumeration();
            }
        }

        [HarmonyPrefix]
        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(typeof(SpatialItemInstance), nameof(SpatialItemInstance.RepairToFullDurability))]
        public static bool SpatialItemInstance_RepairToFullDurability_Prefix(SpatialItemInstance __instance)
        {
            var itemData = __instance.GetItemData<SpatialItemData>();
            if (itemData.damageMode == DamageMode.DURABILITY)
            {
                float maxDurabilityDays = 0;
                if (itemData is DurableItemData durable && durable.IsDurable())
                {
                    maxDurabilityDays = durable.MaxDurabilityDays;
                }
                else if (itemData is DeployableItemData deployable)
                {
                    maxDurabilityDays = deployable.MaxDurabilityDays;
                }
                if (maxDurabilityDays > 0 && __instance.durability < maxDurabilityDays)
                {
                    __instance.durability = maxDurabilityDays;
                    if (__instance.OnDurabilityRepaired != null) __instance.OnDurabilityRepaired();
                }
            }
            return false;
        }

        /// <summary>
        /// See <see cref="LatePatcher.Initialize"/> for details on why this doesn't have attributes
        /// </summary>
        public static bool TooltipSectionDurabilityDetails_RefreshUI_Prefix(TooltipSectionDurabilityDetails __instance)
        {
            __instance.isLayedOut = false;
            if (__instance.tooltipMode == TooltipUI.TooltipMode.MYSTERY)
            {
                __instance.durabilityContainer.SetActive(false);
            }
            else
            {
                FormatStringForDurability(__instance);
                __instance.durabilityBar.fillAmount = __instance.currentDurability / __instance.durableItemData.MaxDurabilityDays;
                __instance.durabilityContainer.SetActive(true);
            }
            __instance.isLayedOut = true;
            return false;
        }

        public static void FormatStringForDurability(TooltipSectionDurabilityDetails details)
        {
            if (details.durableItemData.displayDurabilityAsPercentage)
            {
                details.localizedDurabilityLabel.StringReference = details.durabilityAsPercentLabelString;
                details.localizedDurabilityTextField.enabled = false;
                int num = Mathf.RoundToInt(details.currentDurability / details.durableItemData.MaxDurabilityDays * 100f);
                details.durabilityTextField.text = string.Format("{0} %", num);
            }
            else
            {
                details.localizedDurabilityLabel.StringReference = details.durabilityAsTimeLabelString;
                var currentDurabilityDays = details.currentDurability;
                int days = Mathf.RoundToInt(currentDurabilityDays);
                int hours = Mathf.RoundToInt(currentDurabilityDays * 24f);
                int timeLeft = currentDurabilityDays <= 0 ? 0 : Mathf.Max(days < 1 ? hours : days, 1);
                LocalizedString localizedString = days < 1 ? GameManager.Instance.LanguageManager.localizedHourString : GameManager.Instance.LanguageManager.localizedDayString;
                LocalizationSettings.StringDatabase.GetLocalizedStringAsync(localizedString.TableEntryReference, null, FallbackBehavior.UseProjectSettings, new object[] { timeLeft }).Completed += delegate (AsyncOperationHandle<string> op)
                {
                    if (op.Status == AsyncOperationStatus.Succeeded)
                    {
                        details.localizedDurabilityTextField.enabled = false;
                        details.localizedDurabilityTextField.StringReference.SetReference(LanguageManager.STRING_TABLE, "tooltip.deployable.durability-value");
                        details.localizedDurabilityTextField.StringReference.Arguments = new object[] { op.Result };
                        details.localizedDurabilityTextField.RefreshString();
                        details.localizedDurabilityTextField.enabled = true;
                    }
                };
                details.localizedDurabilityTextField.enabled = true;
            }
        }

        /// <summary>
        /// See <see cref="LatePatcher.Initialize"/> for details on why this doesn't have attributes
        /// </summary>
        public static bool FreshnessCoroutine_AdjustFreshnessForGrid_Prefix(SerializableGrid grid, float proportionOfDayJustElapsed)
        {
            var instances = grid.spatialItems.Where(WinchExtensions.IsThawable);
            int cooledCells = instances.GetNumberOfCells();
            float coolingChange;
            float fishChange;
            if (cooledCells == 0)
            {
                fishChange = proportionOfDayJustElapsed * GameManager.Instance.GameConfigData.FreshnessLossPerDay;
                coolingChange = 0;
                WinchCore.Log.Debug($"[FreshnessCoroutine] AdjustFreshnessForGrid({grid.GridConfiguration}, {proportionOfDayJustElapsed}) fishChange: {fishChange}");
            }
            else
            {
                float propOfMaxReduction = Mathf.InverseLerp(0f, GameManager.Instance.GameConfigData.CellsForMaxFreshnessLossReduction, cooledCells);
                float reductionVal = GameManager.Instance.GameConfigData.FreshnessLossReductionCurve.Evaluate(propOfMaxReduction) * GameManager.Instance.GameConfigData.MaxFreshnessLossReduction;
                float actualVal = 1 - reductionVal;
                coolingChange = proportionOfDayJustElapsed * actualVal;
                fishChange = coolingChange * GameManager.Instance.GameConfigData.FreshnessLossPerDay;
                WinchCore.Log.Debug($"[FreshnessCoroutine] AdjustFreshnessForGrid({grid.GridConfiguration}, {proportionOfDayJustElapsed}) cooledCells: {cooledCells} | propOfMaxReduction: {propOfMaxReduction} | reductionVal: {reductionVal} | actualVal: {actualVal} | coolingChange: {coolingChange} | fishChange: {fishChange}");
            }
            instances.ForEach(i => i.durability -= coolingChange);
            instances.Where(WinchExtensions.IsBroken).ForEach(i => grid.RemoveObjectFromGridData(i, true));
            grid.GetAllItemsOfType<FishItemInstance>(ItemType.GENERAL, ItemSubtype.FISH).ForEach((FishItemInstance fi) =>
            {
                fi.freshness = Mathf.Max(fi.freshness - fishChange, 0);
                if (fi.freshness <= 0) GameManager.Instance.ItemManager.ReplaceFishWithRot(fi, grid, false);
            });
            return false;
        }
    }
}
