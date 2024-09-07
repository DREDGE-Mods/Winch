using Coffee.UIExtensions;
using CommandTerminal;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using UnityAsyncAwaitUtil;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Winch.Components;
using Winch.Config;
using Winch.Core;
using Winch.Data;
using Winch.Data.Abilities;
using Winch.Data.Character;
using Winch.Data.Item;
using Winch.Data.POI;
using Winch.Data.WorldEvent;
using Winch.Patches.API;
using Winch.Util;
using static ActiveAbilityInfoPanel;
using static TrawlNetAbility;

public static class WinchExtensions
{
    #region DREDGE
    /// <summary>
    /// Check if the object is modded
    /// </summary>
    /// <returns>Whether this object is modded or not</returns>
    public static bool IsModded(this ItemData item) => ItemUtil.ModdedItemDataDict.ContainsKey(item.id) || !ItemUtil.VanillaItemIDList.Contains(item.id);
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this ItemInstance item) => ItemUtil.ModdedItemDataDict.ContainsKey(item.id) || !ItemUtil.VanillaItemIDList.Contains(item.id);
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this SerializedCrabPotPOIData crabPotPOI) => ItemUtil.ModdedItemDataDict.ContainsKey(crabPotPOI.deployableItemId) || !ItemUtil.VanillaItemIDList.Contains(crabPotPOI.deployableItemId);
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this GridConfiguration gridConfiguration) => GridConfigUtil.ModdedGridConfigDict.ContainsKey(gridConfiguration.name) || !GridConfigUtil.VanillaGridConfigIDList.Contains(gridConfiguration.name);
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this SpeakerData speakerData) => speakerData is AdvancedSpeakerData;
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this Ability ability) => ability is ModdedAbility || ability.AbilityData.IsModded();
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this AbilityData ability) => ability is ModdedAbilityData;
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this WorldEvent worldEvent) => worldEvent is ModdedWorldEvent || worldEvent.worldEventData.IsModded();
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this WorldEventData worldEvent) => worldEvent is ModdedWorldEventData || !WorldEventUtil.VanillaWorldEventIDList.Contains(worldEvent.name);

    /// <summary>
    /// Check if the object is vanilla
    /// </summary>
    /// <returns>Whether this object is vanilla or not</returns>
    public static bool IsVanilla(this ItemData item) => !item.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this ItemInstance item) => !item.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this SerializedCrabPotPOIData crabPotPOI) => !crabPotPOI.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this GridConfiguration gridConfiguration) => !gridConfiguration.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this SpeakerData speakerData) => !speakerData.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this Ability ability) => !ability.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this AbilityData ability) => !ability.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this WorldEvent worldEvent) => !worldEvent.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this WorldEventData worldEvent) => !worldEvent.IsModded();

    /// <summary>
    /// Check if the associated item data exists
    /// </summary>
    /// <returns>Whether the associated item data exists or not</returns>
    public static bool DoesItemDataExist(this ItemInstance item) => ItemUtil.ModdedItemDataDict.ContainsKey(item.id) || ItemUtil.VanillaItemIDList.Contains(item.id);
    /// <inheritdoc cref="DoesItemDataExist(ItemInstance)"/>
    public static bool DoesItemDataExist(this SerializedCrabPotPOIData crabPotPOI) => ItemUtil.ModdedItemDataDict.ContainsKey(crabPotPOI.deployableItemId) || ItemUtil.VanillaItemIDList.Contains(crabPotPOI.deployableItemId);

    /// <summary>
    /// Opposite of <see cref="DoesItemDataExist(ItemInstance)"/>
    /// </summary>
    public static bool DoesItemDataNotExist(this ItemInstance item) => !item.DoesItemDataExist();
    /// <summary>
    /// Opposite of <see cref="DoesItemDataExist(SerializedCrabPotPOIData)"/>
    /// </summary>
    public static bool DoesItemDataNotExist(this SerializedCrabPotPOIData crabPotPOI) => !crabPotPOI.DoesItemDataExist();

    /// <summary>
    /// Converts a spatial item instances to a spatial item data.
    /// </summary>
    public static SpatialItemData ToItemData(this SpatialItemInstance instance) => instance.GetItemData<SpatialItemData>();
    /// <summary>
    /// Converts a collection of spatial item instances to a collection of their spatial item datas.
    /// </summary>
    public static IEnumerable<SpatialItemData> ToItemData(this IEnumerable<SpatialItemInstance> instances) => instances.Select(ToItemData);

    /// <summary>
    /// Gets the number of cells this item data takes up.
    /// </summary>
    public static int GetNumberOfCells(this SpatialItemData itemData) => itemData.dimensions.Count;
    /// <summary>
    /// Gets the number of cells this item data takes up.
    /// </summary>
    public static int GetNumberOfCells(this SpatialItemInstance instance) => instance.ToItemData().GetNumberOfCells();
    /// <summary>
    /// Gets the number of cells these item datas take up.
    /// </summary>
    public static int GetNumberOfCells(this IEnumerable<SpatialItemData> itemDatas) => itemDatas.Aggregate(0, (int acc, SpatialItemData itemData) => acc + itemData.GetNumberOfCells());
    /// <summary>
    /// Gets the number of cells these item instances take up.
    /// </summary>
    public static int GetNumberOfCells(this IEnumerable<SpatialItemInstance> instances) => instances.ToItemData().GetNumberOfCells();

    /// <summary>
    /// Check whether this item's durability is 0
    /// </summary>
    public static bool IsBroken(this SpatialItemInstance instance) => instance.durability <= 0f;
    /// <summary>
    /// Check whether this is a <see cref="DurableItemData"/> and not thawable
    /// </summary>
    public static bool IsDurable(this SpatialItemData itemData) => itemData is DurableItemData && !itemData.IsThawable();
    /// <summary>
    /// Check whether this item data is a <see cref="DurableItemData"/> and not thawable
    /// </summary>
    public static bool IsDurable(this SpatialItemInstance instance) => instance.ToItemData().IsDurable();
    /// <summary>
    /// Check whether this item thawable (slows down rotting of fish in your inventory)
    /// </summary>
    public static bool IsThawable(this SpatialItemData itemData) => (itemData is DurableItemData && itemData.id.StartsWith("ice-block")) || itemData is ThawableItemData;
    /// <summary>
    /// Check whether this item thawable (slows down rotting of fish in your inventory)
    /// </summary>
    public static bool IsThawable(this SpatialItemInstance instance) => instance.ToItemData().IsThawable();

    /// <summary>
    /// Restocks the item point of interest to 1 (cannot go any higher)
    /// </summary>
    public static void AddStock(this ItemPOI itemPoi)
    {
        if (itemPoi.Stock == 0)
        {
            itemPoi.Harvestable.AddStock(1, false);
            itemPoi.OnStockUpdated();
        }
    }

    /// <summary>
    /// Retrieves the color currently selected for this enum by the player in their settings.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The player set color</returns>
    public static Color GetColor(this DredgeColorTypeEnum colorType) => GameManager.Instance.LanguageManager.GetColor(colorType);
    /// <summary>
    /// Retrieves the html color code currently selected for this enum by the player in their settings.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The player set color code</returns>
    public static string GetColorCode(this DredgeColorTypeEnum colorType) => GameManager.Instance.LanguageManager.GetColorCode(colorType);
    /// <summary>
    /// Returns the original default color for this enum from before any player customization.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The original color</returns>
    public static Color GetDefaultColor(this DredgeColorTypeEnum colorType) => GameManager.Instance.GameConfigData.Colors[(int)colorType];
    /// <summary>
    /// Returns the original default html color code for this enum from before any player customization.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The original color code</returns>
    public static string GetDefaultColorCode(this DredgeColorTypeEnum colorType) => ColorUtility.ToHtmlStringRGB(GetDefaultColor(colorType));

    public static void AddColorType(this LanguageManager languageManager, DredgeColorTypeEnum colorType)
    {
        languageManager.colors.SafeAdd(colorType.GetDefaultColor());
        languageManager.colorCodes.SafeAdd(colorType.GetDefaultColorCode());
    }

    public static void ShowNotificationWithColor(this UIController UI, NotificationType notificationType, string key, string colorCode, object[] arguments)
    {
        LocalizationSettings.StringDatabase.GetLocalizedStringAsync(LanguageManager.STRING_TABLE, key, null, FallbackBehavior.UseProjectSettings, arguments).Completed += delegate (AsyncOperationHandle<string> op)
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                GameEvents.Instance.TriggerNotification(notificationType, string.Concat(new string[] { "<color=#", colorCode, ">", op.Result, "</color>" }));
            }
        };
    }

    public static void ShowMoneyNotification(this UIController UI, decimal value)
    {
        if (value < 0)
        {
            UI.ShowNotification(NotificationType.MONEY_LOST, "notification.funds-removed", new object[]
            {
                string.Concat(new string[]
                {
                    "<color=#",
                    GameManager.Instance.LanguageManager.GetColorCode(DredgeColorTypeEnum.NEGATIVE),
                    ">-$",
                    (-value).ToString("n2", LocalizationSettings.SelectedLocale.Formatter),
                    "</color>"
                })
            });
        }
        else
        {
            UI.ShowNotification(NotificationType.MONEY_GAINED, "notification.funds-added", new object[]
            {
                string.Concat(new string[]
                {
                    "<color=#",
                    GameManager.Instance.LanguageManager.GetColorCode(DredgeColorTypeEnum.POSITIVE),
                    ">$",
                    value.ToString("n2", LocalizationSettings.SelectedLocale.Formatter),
                    "</color>"
                })
            });
        }
    }

    public static void ShowNotificationWithItemName(this UIController UI, NotificationType notificationType, string notificationKey, LocalizedString itemNameKey, DredgeColorTypeEnum itemNameColor)
    {
        LocalizationSettings.StringDatabase.GetLocalizedStringAsync(itemNameKey.TableReference, itemNameKey.TableEntryReference, null, FallbackBehavior.UseProjectSettings, Array.Empty<object>()).Completed += delegate (AsyncOperationHandle<string> op)
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                GameManager.Instance.UI.ShowNotification(notificationType, notificationKey, new object[] { string.Concat(new string[]
                {
                    "<color=#",
                    GameManager.Instance.LanguageManager.GetColorCode(itemNameColor),
                    ">",
                    op.Result,
                    "</color>"
                }) });
            }
        };
    }

    public static Vector2 GetCurrentMapPivot(this MapWindow mapWindow)
    {
        return mapWindow.mapContents.pivot;
    }

    public static Vector2 GetMapPivotFromWorldPosition(this MapWindow mapWindow, Vector2 position)
    {
        Vector2 worldPositionAsMapPosition = mapWindow.GetMapPositionFromWorldPosition(position.x, position.y);
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromMapPosition(worldPositionAsMapPosition.x, worldPositionAsMapPosition.y);
        return mapPivotFromMapPosition;
    }

    public static Vector2 GetMapPivotFromWorldPosition(this MapWindow mapWindow, Vector3 position)
    {
        Vector2 worldPositionAsMapPosition = mapWindow.GetMapPositionFromWorldPosition(position.x, position.z);
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromMapPosition(worldPositionAsMapPosition.x, worldPositionAsMapPosition.y);
        return mapPivotFromMapPosition;
    }

    public static void CenterMapOnWorldPosition(this MapWindow mapWindow, Vector2 position)
    {
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromWorldPosition(position);
        mapWindow.MoveMapTo(mapPivotFromMapPosition.x, mapPivotFromMapPosition.y);
    }

    public static void CenterMapOnWorldPosition(this MapWindow mapWindow, Vector3 position)
    {
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromWorldPosition(position);
        mapWindow.MoveMapTo(mapPivotFromMapPosition.x, mapPivotFromMapPosition.y);
    }

    public static TrawlMode GetTrawlModeFromItemData(this DeployableItemData data)
    {
        if (data is TrawlNetItemData netData)
            return netData.trawlMode;
        else if (data.id == "tir-net1")
            return TrawlMode.TRAWL_OOZE;
        else if (data.id == "tir-net2")
            return TrawlMode.TRAWL_MATERIAL;
        else if (data.itemSubtype == ItemSubtype.NET)
            return TrawlMode.TRAWL;
        else
            return TrawlMode.NONE;
    }

    public static NetType GetNetTypeFromItemData(this DeployableItemData data)
    {
        if (data is TrawlNetItemData netData)
            return netData.netType;
        else if (data.id == "tir-net1")
            return NetType.SIPHON;
        else if (data.id == "tir-net2")
            return NetType.MATERIAL;
        else
            return NetType.REGULAR;
    }

    public static PotType GetPotTypeFromItemData(this DeployableItemData data)
    {
        if (data is CrabPotItemData potData)
            return potData.potType;
        else if (data.id == "tir-pot1")
            return PotType.MATERIAL;
        else
            return PotType.CRAB;
    }

    public static BaitType GetBaitTypeFromItemData(this SpatialItemData data)
    {
        if (data is BaitItemData baitData)
            return baitData.baitType;
        else if (data.id == "bait-crab")
            return BaitType.CRAB;
        else if (data.id == "bait-exotic")
            return BaitType.EXOTIC;
        else if (data.id == "bait-ab")
            return BaitType.ABERRATED;
        else
            return BaitType.FISH;
    }

    public static bool IsFish(this BaitType baitType)
    {
        switch (baitType)
        {
            case BaitType.FISH:
            case BaitType.ABERRATED:
            case BaitType.EXOTIC:
            case BaitType.CRAB:
            default:
                return true;
            case BaitType.MATERIAL:
                return false;
        }
    }

    public static bool IsFishInCurrentWorldPhases(this SaveData saveData, FishItemData fish)
    {
        return saveData.WorldPhase >= fish.MinWorldPhaseRequired && saveData.TIRWorldPhase >= fish.TIRPhase;
    }

    public static bool HasCaughtNonAberrationParent(this SaveData saveData, FishItemData aberrationFish)
    {
        return saveData.GetCaughtCountById(aberrationFish.NonAberrationParent.id) > 0;
    }

    public static bool GetHasEquipmentForHarvestableItem(this PlayerStats playerStats, HarvestableItemData harvestableItemData)
    {
        return playerStats.GetHasEquipmentForHarvestType(harvestableItemData.harvestableType, harvestableItemData.requiresAdvancedEquipment);
    }

    public static bool IsItemHarvestable(this PlayerZoneDetector playerZoneDetector, HarvestableItemData harvestableItemData)
    {
        return harvestableItemData.zonesFoundIn == ZoneEnum.ALL || harvestableItemData.zonesFoundIn.HasFlag(playerZoneDetector.GetCurrentZone());
    }

    public static IEnumerable<T> FilterWithEntitlements<T>(this IEnumerable<T> items) where T : ItemData => items.Where(item => item.entitlementsRequired == null || item.entitlementsRequired.Count == 0 || (item.entitlementsRequired.Count == 1 && item.entitlementsRequired.FirstOrDefault() == Entitlement.NONE) || item.entitlementsRequired.All(GameManager.Instance.EntitlementManager.GetHasEntitlement));
    public static List<FishItemData> GetFishItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.FISH).OfType<FishItemData>().FilterWithEntitlements().ToList();
    public static List<EngineItemData> GetEngineItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.ENGINE).OfType<EngineItemData>().FilterWithEntitlements().ToList();
    public static List<RodItemData> GetRodItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.ROD).OfType<RodItemData>().FilterWithEntitlements().ToList();
    public static List<SpatialItemData> GetGeneralItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.GENERAL).FilterWithEntitlements().ToList();
    public static List<RelicItemData> GetRelicItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.ENGINE).OfType<RelicItemData>().FilterWithEntitlements().ToList();
    public static List<HarvestableItemData> GetTrinketItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.TRINKET).OfType<HarvestableItemData>().FilterWithEntitlements().ToList();
    public static List<HarvestableItemData> GetMaterialItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.MATERIAL).OfType<HarvestableItemData>().FilterWithEntitlements().ToList();
    public static List<LightItemData> GetLightItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.LIGHT).OfType<LightItemData>().FilterWithEntitlements().ToList();
    public static List<DeployableItemData> GetPotItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.POT).OfType<DeployableItemData>().FilterWithEntitlements().ToList();
    public static List<DeployableItemData> GetNetItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.NET).OfType<DeployableItemData>().FilterWithEntitlements().ToList();
    public static List<DredgeItemData> GetDredgeItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.DREDGE).OfType<DredgeItemData>().FilterWithEntitlements().ToList();
    public static List<GadgetItemData> GetGadgetItems(this ItemManager itemManager) => itemManager.GetSpatialItemDataBySubtype(ItemSubtype.GADGET).OfType<GadgetItemData>().FilterWithEntitlements().ToList();

    public static List<FishItemData> GetBaitRegularFish(this ItemManager itemManager)
    {
        return itemManager.GetFishItems().Where(fish => !fish.IsAberration && !fish.LocationHiddenUntilCaught && fish.CanAppearInBaitBalls && fish.canBeCaughtByRod && GameManager.Instance.Player.PlayerZoneDetector.IsItemHarvestable(fish) && GameManager.Instance.SaveData.IsFishInCurrentWorldPhases(fish) && GameManager.Instance.PlayerStats.GetHasEquipmentForHarvestableItem(fish)).Shuffle().ToList();
    }

    public static List<FishItemData> GetBaitExoticFish(this ItemManager itemManager)
    {
        return itemManager.GetFishItems().Where(fish => fish.LocationHiddenUntilCaught && fish.CanAppearInBaitBalls && fish.canBeCaughtByRod && !fish.IsAberration && GameManager.Instance.Player.PlayerZoneDetector.IsItemHarvestable(fish) && GameManager.Instance.SaveData.IsFishInCurrentWorldPhases(fish) && GameManager.Instance.PlayerStats.GetHasEquipmentForHarvestableItem(fish)).Shuffle().ToList();
    }

    public static List<FishItemData> GetBaitAberratedFish(this ItemManager itemManager)
    {
        if (!GameManager.Instance.SaveData.CanCatchAberrations) return new List<FishItemData>();

        return itemManager.GetFishItems().Where(fish => fish.IsAberration && !fish.LocationHiddenUntilCaught && fish.NonAberrationParent != null && fish.NonAberrationParent.CanAppearInBaitBalls && fish.canBeCaughtByRod && GameManager.Instance.Player.PlayerZoneDetector.IsItemHarvestable(fish) && GameManager.Instance.SaveData.IsFishInCurrentWorldPhases(fish) && GameManager.Instance.PlayerStats.GetHasEquipmentForHarvestableItem(fish) && GameManager.Instance.SaveData.HasCaughtNonAberrationParent(fish)).Shuffle().ToList();
    }

    public static List<FishItemData> GetBaitCrabs(this ItemManager itemManager)
    {
        return itemManager.GetFishItems().Where(fish => fish.canBeCaughtByPot && !fish.IsAberration && fish.CanAppearInBaitBalls && GameManager.Instance.Player.PlayerZoneDetector.IsItemHarvestable(fish) && GameManager.Instance.SaveData.IsFishInCurrentWorldPhases(fish) && GameManager.Instance.PlayerStats.GetHasEquipmentForHarvestableItem(fish)).Shuffle().ToList();
    }

    public static List<HarvestableItemData> GetBaitMaterials(this ItemManager itemManager)
    {
        return itemManager.GetMaterialItems().Concat(itemManager.GetTrinketItems()).Where(harvestable => (harvestable.canBeCaughtByNet || harvestable.canBeCaughtByPot) && GameManager.Instance.Player.PlayerZoneDetector.IsItemHarvestable(harvestable) && GameManager.Instance.PlayerStats.GetHasEquipmentForHarvestableItem(harvestable)).Shuffle().ToList();
    }

    public static List<HarvestableItemData> GetBaitRange<T>(this List<T> items) where T : HarvestableItemData => items.GetRange(0, Mathf.Min(items.Count, GameManager.Instance.GameConfigData.NumFishSpeciesInBaitBall)).CastToList<HarvestableItemData>();

    public static List<HarvestableItemData> GetRangedBaitRegularFish(this ItemManager itemManager)
    {
        return itemManager.GetBaitRegularFish().GetBaitRange();
    }

    public static List<HarvestableItemData> GetRangedBaitExoticFish(this ItemManager itemManager)
    {
        return itemManager.GetBaitExoticFish().GetBaitRange();
    }

    public static List<HarvestableItemData> GetRangedBaitAberratedFish(this ItemManager itemManager)
    {
        return itemManager.GetBaitAberratedFish().GetBaitRange();
    }

    public static List<HarvestableItemData> GetRangedBaitCrabs(this ItemManager itemManager)
    {
        return itemManager.GetBaitCrabs().GetBaitRange();
    }

    public static List<HarvestableItemData> GetRangedBaitMaterials(this ItemManager itemManager)
    {
        return itemManager.GetBaitMaterials().GetBaitRange();
    }

    public static bool DeployBaitModified(this BaitAbility baitAbility, SpatialItemInstance baitInstance)
    {
        SpatialItemData spatialItemData = baitInstance.GetItemData<SpatialItemData>();
        BaitType baitType = spatialItemData.GetBaitTypeFromItemData();
        BaitPOIDataModel baitPOIDataModel = baitType.IsFish() ? new BaitPOIDataModel() : new MaterialBaitPOIDataModel();
        baitPOIDataModel.doesRestock = false;
        bool deepForm = baitType == BaitType.ABERRATED && GameManager.Instance.QuestManager.IsQuestCompleted(baitAbility.deepFormItemData.QuestCompleteRequired.name) && baitAbility.deepFormItemData.zonesFoundIn.HasFlag(GameManager.Instance.Player.PlayerZoneDetector.GetCurrentZone()) && UnityEngine.Random.value <= baitAbility.deepFormItemData.BaitChanceOverride;
        List<HarvestableItemData> items = deepForm ? new List<HarvestableItemData> { baitAbility.deepFormItemData } : spatialItemData.GetBaitItemsFromItemData();
        if (items.Count == 0)
        {
            GameManager.Instance.UI.ShowNotification(NotificationType.ERROR, "notification.bait-failed");
            return false;
        }
        int num = (baitType == BaitType.EXOTIC || deepForm) ? 1 : UnityEngine.Random.Range(GameManager.Instance.GameConfigData.NumFishInBaitBallMin, GameManager.Instance.GameConfigData.NumFishInBaitBallMax);
        if (deepForm) items = new List<HarvestableItemData> { baitAbility.deepFormItemData };
        Stack<HarvestableItemData> stack = new Stack<HarvestableItemData>();
        for (int i = 0; i < num; i++)
        {
            stack.Push(items[i % items.Count]);
        }
        baitPOIDataModel.itemStock = stack;
        baitPOIDataModel.startStock = stack.Count;
        baitPOIDataModel.maxStock = baitPOIDataModel.startStock;
        baitPOIDataModel.usesTimeSpecificStock = false;
        GameObject obj = GameObject.Instantiate(position: new Vector3(GameManager.Instance.Player.BoatModelProxy.DeployPosition.position.x, 0f, GameManager.Instance.Player.BoatModelProxy.DeployPosition.position.z), original: baitAbility.GetPlacedHarvestPOIPrefabFromBaitType(baitType), rotation: Quaternion.identity, parent: GameSceneInitializer.Instance.HarvestPoiContainer.transform);
        obj.transform.eulerAngles = new Vector3(0f, GameManager.Instance.Player.BoatModelProxy.DeployPosition.eulerAngles.y, 0f);
        if (obj.TryGetComponent<HarvestPOI>(out HarvestPOI harvestPOI))
        {
            harvestPOI.Harvestable = baitPOIDataModel;
            harvestPOI.HarvestPOIData = baitPOIDataModel;
            if (harvestPOI.TryGetComponent<Cullable>(out Cullable cullable))
            {
                GameManager.Instance.CullingBrain.AddCullable(cullable);
            }
        }
        if (items.Count >= 3 && stack.Count >= 3)
        {
            GameManager.Instance.AchievementManager.SetAchievementState(DredgeAchievementId.ABILITY_BAIT, newState: true);
        }
        if (baitType == BaitType.CRAB)
        {
            GameManager.Instance.Player.Harvester.CurrentHarvestPOI = harvestPOI;
            GameManager.Instance.Player.Harvester.IsCrabBaitMode = true;
            GameManager.Instance.Player.Harvester.enabled = true;
            GameEvents.Instance.OnHarvestModeToggled += baitAbility.OnHarvestModeToggled;
        }
        GameManager.Instance.SaveData.Inventory.RemoveObjectFromGridData(baitInstance, notify: true);
        GameEvents.Instance.TriggerItemInventoryChanged(baitAbility.currentlySelectedItem);
        return true;
    }

    public static List<HarvestableItemData> GetBaitItemsFromItemData(this SpatialItemData baitData)
    {
        if (baitData == null) return new List<HarvestableItemData>();
        var baitType = baitData.GetBaitTypeFromItemData();
        if (baitType == BaitType.FISH)
            return GameManager.Instance.ItemManager.GetRangedBaitRegularFish();
        else if (baitType == BaitType.EXOTIC)
            return GameManager.Instance.ItemManager.GetRangedBaitExoticFish();
        else if (baitType == BaitType.ABERRATED && GameManager.Instance.SaveData.CanCatchAberrations)
            return GameManager.Instance.ItemManager.GetRangedBaitAberratedFish();
        else if (baitType == BaitType.CRAB)
            return GameManager.Instance.ItemManager.GetRangedBaitCrabs();
        else if (baitType == BaitType.MATERIAL)
            return GameManager.Instance.ItemManager.GetRangedBaitMaterials();
        else
            return new List<HarvestableItemData>();
    }

    public static AbilityMode GetAbilityModeFromItemData(this SpatialItemData data)
    {
        if (data is IAbilityItemData abilityItemData)
            return abilityItemData.AbilityMode;
        else if (data.id == "tir-pot1")
            return AbilityMode.POT_MATERIAL;
        else if (data.itemSubtype == ItemSubtype.POT)
            return AbilityMode.POT;
        else if (data.id == "tir-net1")
            return AbilityMode.TRAWL_OOZE;
        else if (data.id == "tir-net2")
            return AbilityMode.TRAWL_MATERIAL;
        else if (data.itemSubtype == ItemSubtype.NET)
            return AbilityMode.TRAWL;
        else if (data.id == "bait-crab")
            return AbilityMode.BAIT_CRAB;
        else if (data.id == "bait-exotic")
            return AbilityMode.BAIT_EXOTIC;
        else if (data.id == "bait-ab")
            return AbilityMode.BAIT_ABERRATED;
        else if (data.id == "bait")
            return AbilityMode.BAIT;
        else
            return AbilityMode.NONE;
    }

    public static void UpdateCatchableSpecies(this ActiveAbilityInfoPanel activeAbilityInfoPanel, AbilityMode abilityMode)
    {
        if (abilityMode == AbilityMode.TRAWL_OOZE)
        {
            activeAbilityInfoPanel.oozeCanisterAnimator.SetBool("IsActive", GameManager.Instance.OozePatchManager.GetIsCurrentlyGatheringOoze());
            if (GameManager.Instance.OozePatchManager.isOozeNearToPlayer)
            {
                activeAbilityInfoPanel.localizedQualityString.StringReference = activeAbilityInfoPanel.oozeQualityStringKey;
                activeAbilityInfoPanel.qualityTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.CRITICAL);
            }
            else
            {
                activeAbilityInfoPanel.localizedQualityString.StringReference = activeAbilityInfoPanel.poorQualityStringKey;
                activeAbilityInfoPanel.qualityTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.NEUTRAL);
            }
            return;
        }
        List<string> itemIds = new List<string>();
        int possibleItems = 0;
        if (activeAbilityInfoPanel.enableLogs)
        {
            activeAbilityInfoPanel.debugStr = "Depth: " + activeAbilityInfoPanel.depthTextField.text + " | ";
        }
        if (abilityMode == AbilityMode.POT_MATERIAL || abilityMode == AbilityMode.TRAWL_MATERIAL || abilityMode == AbilityModeExtra.BAIT_MATERIAL)
        {
            possibleItems = 2;
        }
        else if (abilityMode == AbilityMode.POT)
        {
            itemIds = GameManager.Instance.Player.HarvestZoneDetector.GetHarvestableItemIds(activeAbilityInfoPanel.CheckCanBeCaughtByThisPot, GameManager.Instance.Player.PlayerDepthMonitor.CurrentDepth, isDay: true);
            possibleItems = itemIds.Count;
            if (activeAbilityInfoPanel.enableLogs)
            {
                if (activeAbilityInfoPanel.currentlySelectedItemData != null)
                {
                    activeAbilityInfoPanel.debugStr += "pot: " + activeAbilityInfoPanel.currentlySelectedItemData.id + " | ";
                }
                else
                {
                    activeAbilityInfoPanel.debugStr += "pot: NONE | ";
                }
            }
        }
        else if (abilityMode == AbilityMode.TRAWL)
        {
            itemIds = GameManager.Instance.Player.HarvestZoneDetector.GetHarvestableItemIds(activeAbilityInfoPanel.CheckCanBeCaughtByThisNet, GameManager.Instance.Player.PlayerDepthMonitor.CurrentDepth, GameManager.Instance.Time.IsDaytime);
            possibleItems = itemIds.Count;
            if (activeAbilityInfoPanel.enableLogs)
            {
                if (activeAbilityInfoPanel.currentlySelectedItemData != null)
                {
                    activeAbilityInfoPanel.debugStr += "net: " + activeAbilityInfoPanel.currentlySelectedItemData.id + " | ";
                }
                else
                {
                    activeAbilityInfoPanel.debugStr += "net: NONE | ";
                }
            }
        }
        else if (abilityMode == AbilityMode.BAIT || abilityMode == AbilityMode.BAIT_ABERRATED || abilityMode == AbilityMode.BAIT_EXOTIC || abilityMode == AbilityMode.BAIT_CRAB)
        {
            itemIds = (from s in activeAbilityInfoPanel.currentlySelectedItemData.GetBaitItemsFromItemData()
                    select s.id).ToList();
            possibleItems = itemIds.Count;
            if (activeAbilityInfoPanel.enableLogs)
            {
                if (activeAbilityInfoPanel.currentlySelectedItemData != null)
                {
                    activeAbilityInfoPanel.debugStr += "bait: " + activeAbilityInfoPanel.currentlySelectedItemData.id + " | ";
                }
                else
                {
                    activeAbilityInfoPanel.debugStr += "bait: NONE | ";
                }
            }
        }
        if (activeAbilityInfoPanel.enableLogs)
        {
            activeAbilityInfoPanel.debugStr += string.Join(", ", itemIds);
            Debug.Log(activeAbilityInfoPanel.debugStr);
        }
        if (possibleItems > 1)
        {
            activeAbilityInfoPanel.localizedQualityString.StringReference = activeAbilityInfoPanel.goodQualityStringKey;
            activeAbilityInfoPanel.qualityTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.POSITIVE);
        }
        else if (possibleItems == 1)
        {
            activeAbilityInfoPanel.localizedQualityString.StringReference = activeAbilityInfoPanel.okQualityStringKey;
            activeAbilityInfoPanel.qualityTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.NEUTRAL);
        }
        else
        {
            activeAbilityInfoPanel.localizedQualityString.StringReference = activeAbilityInfoPanel.poorQualityStringKey;
            activeAbilityInfoPanel.qualityTextField.color = GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.NEGATIVE);
        }
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromPotType(this GameSceneInitializer gameSceneInitializer, PotType type)
    {
        switch (type)
        {
            case PotType.MATERIAL:
                return gameSceneInitializer.placedMaterialPOIPrefab;
            case PotType.CRAB:
            default:
                return gameSceneInitializer.placedPOIPrefab;
        }
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromPotItemData(this GameSceneInitializer gameSceneInitializer, DeployableItemData data)
    {
        return gameSceneInitializer.GetPlacedHarvestPOIPrefabFromPotType(data.GetPotTypeFromItemData());
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromPotItemData(this GameSceneInitializer gameSceneInitializer, string id)
    {
        return gameSceneInitializer.GetPlacedHarvestPOIPrefabFromPotItemData(GameManager.Instance.ItemManager.GetItemDataById<DeployableItemData>(id));
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromBaitType(this BaitAbility baitAbility, BaitType type)
    {
        switch (type)
        {
            case BaitType.FISH:
            case BaitType.ABERRATED:
            case BaitType.EXOTIC:
            case BaitType.CRAB:
            default:
                return baitAbility.baitPOIPrefab;
            case BaitType.MATERIAL:
                return BaitPatcher.MaterialHarvestPOI;
        }
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromBaitItemData(this BaitAbility baitAbility, SpatialItemData data)
    {
        return baitAbility.GetPlacedHarvestPOIPrefabFromBaitType(data.GetBaitTypeFromItemData());
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromBaitItemData(this BaitAbility baitAbility, string id)
    {
        return baitAbility.GetPlacedHarvestPOIPrefabFromBaitItemData(GameManager.Instance.ItemManager.GetItemDataById<SpatialItemData>(id));
    }

    public static Sprite GetSpriteForAbilityMode(this ActiveAbilityInfoPanel activeAbilityInfoPanel, AbilityMode mode)
    {
        switch (mode)
        {
            case AbilityMode.POT:
                return activeAbilityInfoPanel.potQualityIcon;
            case AbilityMode.POT_MATERIAL:
                return activeAbilityInfoPanel.materialQualityIcon;
            case AbilityMode.BAIT:
                return activeAbilityInfoPanel.baitRegularQualityIcon;
            case AbilityMode.BAIT_ABERRATED:
                return activeAbilityInfoPanel.baitAberratedQualityIcon;
            case AbilityMode.BAIT_EXOTIC:
                return activeAbilityInfoPanel.baitExoticQualityIcon;
            case AbilityMode.BAIT_CRAB:
                return activeAbilityInfoPanel.baitCrabQualityIcon;
            case AbilityModeExtra.BAIT_MATERIAL:
                return TextureUtil.GetSprite("BaitMaterialIcon");
            case AbilityMode.TRAWL:
                return activeAbilityInfoPanel.trawlQualityIcon;
            case AbilityMode.TRAWL_OOZE:
                return activeAbilityInfoPanel.oozeQualityIcon;
            case AbilityMode.TRAWL_MATERIAL:
                return activeAbilityInfoPanel.materialQualityIcon;
            default:
                return TextureUtil.GetSprite(string.Join(string.Empty, mode.GetName().Split('_').Select(word => word.ToLowerInvariant().ToTitleCase())) + "QualityIcon");
        }
    }

    public static Sprite GetSpriteForTrawlMode(this ItemCounterUI itemCounter, TrawlMode mode)
    {
        switch (mode)
        {
            case TrawlMode.NONE:
            case TrawlMode.TRAWL:
                return itemCounter.fishIcon;
            case TrawlMode.TRAWL_MATERIAL:
                return itemCounter.materialIcon;
            case TrawlMode.TRAWL_OOZE:
                return itemCounter.oozeIcon;
            default:
                return TextureUtil.GetSprite(string.Join(string.Empty, mode.GetName().Split('_').Select(word => word.ToLowerInvariant().ToTitleCase())) + "CounterIcon");
        }
    }

    public static Sprite GetSpriteForNetItem(this ItemCounterUI itemCounter, DeployableItemData data)
    {
        if (data is TrawlNetItemData trawlData && trawlData.CounterIcon != null)
            return trawlData.CounterIcon;

        return itemCounter.GetSpriteForTrawlMode(data.GetTrawlModeFromItemData());
    }

    public static List<HarvestableItemData> GetHarvestableItems(this TrawlNetAbility trawlNetAbility)
    {
        float currentDepth = GameManager.Instance.WaveController.SampleWaterDepthAtPlayerPosition();
        return GameManager.Instance.Player.HarvestZoneDetector.GetHarvestableItemIds(trawlNetAbility.CheckCanBeCaughtByThisNet, currentDepth, GameManager.Instance.Time.IsDaytime).Select(id => GameManager.Instance.ItemManager.GetItemDataById<HarvestableItemData>(id)).ToList();
    }

    public static void PlaceTrawlItemAtGridPos(this TrawlNetAbility trawlNetAbility, HarvestableItemData harvestableItemData, Vector3Int gridPos)
    {
        if (harvestableItemData is FishItemData fishItemData)
        {
            FishSizeGenerationMode sizeGenerationMode = FishSizeGenerationMode.NO_BIG_TROPHY;
            float aberrationBonusMultiplier = 1f;
            if (!fishItemData.canBeCaughtByPot && !fishItemData.canBeCaughtByRod)
            {
                sizeGenerationMode = FishSizeGenerationMode.ANY;
                aberrationBonusMultiplier = 2f;
            }
            FishItemInstance fishItemInstance = GameManager.Instance.ItemManager.CreateFishItem(fishItemData.id, FishAberrationGenerationMode.RANDOM_CHANCE, false, sizeGenerationMode, aberrationBonusMultiplier);
            GameManager.Instance.SaveData.TrawlNet.AddObjectToGridData(fishItemInstance, gridPos, true, null);
            GameManager.Instance.ItemManager.SetItemSeen(fishItemInstance);
            GameEvents.Instance.TriggerFishCaught();
            GameManager.Instance.VibrationManager.Vibrate(trawlNetAbility.fishAddedVibrationData, VibrationRegion.WholeBody, true).Run();
        }
        else
        {
            SpatialItemInstance spatialItemInstance = GameManager.Instance.ItemManager.CreateItem<SpatialItemInstance>(harvestableItemData);
            GameManager.Instance.SaveData.TrawlNet.AddObjectToGridData(spatialItemInstance, gridPos, true, null);
            GameManager.Instance.ItemManager.SetItemSeen(spatialItemInstance);
            GameManager.Instance.VibrationManager.Vibrate(trawlNetAbility.materialAddedVibrationData, VibrationRegion.WholeBody, true).Run();
        }
    }

    public static int GetNumItemById(this ItemManager itemManager, string id)
    {
        ItemData itemDataById = itemManager.GetItemDataById<ItemData>(id);
        if (GameManager.Instance.SaveData.Inventory == null)
        {
            return 0;
        }
        if (itemDataById == null)
        {
            Debug.LogError("[ItemManager] GetNumItemInInventoryById(" + id + ") could not find ItemData with that id.");
            return 0;
        }
        if (itemDataById is SpatialItemData)
        {
            return GameManager.Instance.SaveData.Inventory.spatialItems.FindAll((SpatialItemInstance i) => i.id == id).Count;
        }
        if (itemDataById is NonSpatialItemData)
        {
            return GameManager.Instance.SaveData.ownedNonSpatialItems.FindAll((NonSpatialItemInstance i) => i.id == id).Count;
        }
        return 0;
    }

    public static void RemoveItemById(this ItemManager itemManager, string id, int removeCount = 1)
    {
        ItemData itemDataById = itemManager.GetItemDataById<ItemData>(id);
        if (itemDataById == null)
        {
            Debug.LogError("[ItemManager] RemoveItemById(" + id + ") could not find ItemData with that id.");
            return;
        }
        if (removeCount == -1)
        {
            removeCount = itemManager.GetNumItemById(id);
        }
        if (itemDataById is SpatialItemData)
        {
            GameManager.Instance.SaveData.Inventory.spatialItems.Where((SpatialItemInstance i) => i.id == id).Take(removeCount).ToList()
                .ForEach(delegate (SpatialItemInstance i)
                {
                    GameManager.Instance.SaveData.Inventory.RemoveObjectFromGridData(i, notify: true);
                });
        }
        else if (itemDataById is NonSpatialItemData)
        {
            GameManager.Instance.SaveData.ownedNonSpatialItems.Where((NonSpatialItemInstance i) => i.id == id).Take(removeCount).ToList()
                .ForEach(delegate (NonSpatialItemInstance i)
                {
                    GameManager.Instance.SaveData.ownedNonSpatialItems.Remove(i);
                });
        }
        GameManager.Instance.UI.ShowNotificationWithItemName(NotificationType.ITEM_HANDED_IN, "notification.item-removed", itemDataById.itemNameKey, GameManager.Instance.LanguageManager.GetColor(DredgeColorTypeEnum.NEUTRAL));
    }

    public static int GetFilledCells(this SerializableGrid serializableGrid) => serializableGrid.GetFilledCells(ItemSubtype.ALL);
    public static float GetFillProportional(this SerializableGrid serializableGrid) => (float)serializableGrid.GetFilledCells() / (float)serializableGrid.GetCountNonHiddenCells();

    public static bool TryGetParalinguisticsFromNameKey(this IDictionary<string, SpeakerData> lookupTable, ParalinguisticsNameKey nameKey, out Dictionary<ParalinguisticType, List<AssetReference>> paralinguistics)
    {
        var stringNameKey = nameKey.ToString();
        switch (nameKey)
        {
            case ParalinguisticsNameKey.NONE:
                break;
            case ParalinguisticsNameKey.COLLECTOR_REVEALED:
                if (lookupTable.TryGetValue("COLLECTOR_NAME_KEY", out SpeakerData collectorData))
                {
                    paralinguistics = collectorData.paralinguisticOverrideConditions.First().config.paralinguistics;
                    return true;
                }
                break;
            case ParalinguisticsNameKey.HOODED_FIGURE:
                stringNameKey += "_1";
                goto default;
            case ParalinguisticsNameKey.SOUL:
                stringNameKey += "_MIDDLE";
                goto default;
            default:
                if (lookupTable.TryGetValue(stringNameKey + "_NAME_KEY", out SpeakerData data))
                {
                    paralinguistics = data.paralinguistics;
                    return true;
                }
                break;
        }
        paralinguistics = null;
        return false;
    }

    public static void DeactivateButtonEffects(this BasicButtonWrapper buttonWrapper)
    {
        buttonWrapper.transitionEffect.duration = 0;
        buttonWrapper.DoTransitionIn();
        buttonWrapper.GetComponent<UITransitionEffect>().enabled = false;
        buttonWrapper.GetComponent<Mask>().enabled = false;
    }

    private static readonly BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    public static void RegisterCommands(this CommandShell shell, Assembly assembly)
    {
        Dictionary<string, CommandInfo> rejectedCommands = new Dictionary<string, CommandInfo>();
        Type[] types = assembly.GetTypes();
        foreach (var type in types)
        {
            MethodInfo[] methods = type.GetMethods(bindingAttr);
            foreach (var method in methods)
            {
                RegisterCommandAttribute registerCommandAttribute = method.GetCustomAttribute<RegisterCommandAttribute>();
                if (registerCommandAttribute != null)
                {
                    goto add;
                }
                if (method.Name.StartsWith("FRONTCOMMAND", StringComparison.CurrentCultureIgnoreCase))
                {
                    registerCommandAttribute = new RegisterCommandAttribute(null);
                    goto add;
                }
            increment:
                continue;
            add:
                ParameterInfo[] parameters = method.GetParameters();
                string text = shell.InferFrontCommandName(method.Name);
                if (registerCommandAttribute.Name == null)
                {
                    text = shell.InferCommandName((text == null) ? method.Name : text);
                }
                else
                {
                    text = registerCommandAttribute.Name;
                }
                if (parameters.Length != 1 || parameters[0].ParameterType != typeof(CommandArg[]))
                {
                    rejectedCommands.Add(text.ToUpper(), shell.CommandFromParamInfo(parameters, registerCommandAttribute.Help));
                    goto increment;
                }
                Action<CommandArg[]> proc = (Action<CommandArg[]>)Delegate.CreateDelegate(typeof(Action<CommandArg[]>), method);
                shell.AddCommand(text, proc, registerCommandAttribute.MinArgCount, registerCommandAttribute.MaxArgCount, registerCommandAttribute.Help);
                goto increment;
            }
        }
        shell.HandleRejectedCommands(rejectedCommands);
    }

    public static bool Unregister(this CommandAutocomplete autocomplete, string word)
    {
        return autocomplete.known_words.Remove(word.ToLower());
    }

    public static JToken ToJToken(this object? value) => value != null ? (value is JToken jtoken ? jtoken : JToken.FromObject(value, JSONConfig.jsonSerializer)) : JValue.CreateNull();

    public static bool IsNullOrEmpty(this JToken token)
    {
        return (token == null) ||
               (token.Type == JTokenType.Array && !token.HasValues) ||
               (token.Type == JTokenType.Object && !token.HasValues) ||
               (token.Type == JTokenType.String && string.IsNullOrEmpty(token.ToString())) ||
               (token.Type == JTokenType.Null) ||
               (token.Type == JTokenType.Undefined);
    }

    public static bool IsNullOrWhiteSpace(this JToken token)
    {
        return (token == null) ||
               (token.Type == JTokenType.Array && !token.HasValues) ||
               (token.Type == JTokenType.Object && !token.HasValues) ||
               (token.Type == JTokenType.String && string.IsNullOrWhiteSpace(token.ToString())) ||
               (token.Type == JTokenType.Null) ||
               (token.Type == JTokenType.Undefined);
    }

    /// <summary>
    /// Copy of <see cref="AchievementData.Print"/> except it actually returns the string instead of logging it.
    /// </summary>
    public static string ToPrintedString(this AchievementData achievement)
    {
        string printStr = $"{achievement.id}: ";
        if (achievement.evaluationConditions.Count > 0)
        {
            achievement.evaluationConditions.ForEach(delegate (AchievementCondition c)
            {
                printStr = printStr + c.Print() + " ";
            });
        }
        else
        {
            printStr += "This achievement is triggered manually.";
        }
        return printStr;
    }

    /// <summary>
    /// Checks if both crab pot POI datas have identical serializable data excluding <see cref="SerializedCrabPotPOIData.grid"/>
    /// </summary>
    public static bool Identical(this SerializedCrabPotPOIData a, SerializedCrabPotPOIData b)
    {
        return a.deployableItemId == b.deployableItemId && a.x == b.x && a.z == b.z
                    && a.lastUpdate == b.lastUpdate && a.timeUntilNextCatchRoll == b.timeUntilNextCatchRoll
                    && a.durability == b.durability && a.hadDurabilityRemaining == b.hadDurabilityRemaining;
    }

    /// <summary>
    /// Makes an uninitialized crab pot POI data with identical serializable data excluding <see cref="SerializedCrabPotPOIData.grid"/>
    /// </summary>
    public static SerializedCrabPotPOIData MakeIdentical(this SerializedCrabPotPOIData crabPotPOI)
    {
        var partialCrabPot = (SerializedCrabPotPOIData)FormatterServices.GetUninitializedObject(typeof(SerializedCrabPotPOIData));
        partialCrabPot.deployableItemId = crabPotPOI.deployableItemId;
        partialCrabPot.x = crabPotPOI.x;
        partialCrabPot.z = crabPotPOI.z;
        partialCrabPot.lastUpdate = crabPotPOI.lastUpdate;
        partialCrabPot.timeUntilNextCatchRoll = crabPotPOI.timeUntilNextCatchRoll;
        partialCrabPot.durability = crabPotPOI.durability;
        partialCrabPot.hadDurabilityRemaining = crabPotPOI.hadDurabilityRemaining;
        partialCrabPot.grid = new SerializableGrid();
        return partialCrabPot;
    }

    public static IEnumerator CheckIsSaveAllowedToBeLoaded(this TitleController titleController, int slotNum, SaveData s, Selectable selectable, Action<bool> callback)
    {
        WinchCore.Log.Debug("[TitleController] CheckIsSaveAllowedToBeLoaded()");
        bool result = true;
        if (s == null)
        {
            result = false;
            string localizationKey = "popup.corrupt-save-identified";
            yield return titleController.ShowLoadFailedWithIssueDialog(selectable, localizationKey);
        }
        else if (((s.GetSaveUsesEntitlement(Entitlement.DLC_1) && !GameManager.Instance.EntitlementManager.GetHasEntitlement(Entitlement.DLC_1)) || (s.GetSaveUsesEntitlement(Entitlement.DLC_2) && !GameManager.Instance.EntitlementManager.GetHasEntitlement(Entitlement.DLC_2))))
        {
            result = false;
            string localizationKey = "popup.incompatible-dlc";
            yield return titleController.ShowLoadFailedWithIssueDialog(selectable, localizationKey);
        }
        else if (SaveUtil.GetInMemorySaveDataForSlot(slotNum).IsSaveNotAllowedToBeLoaded())
        {
            result = false;
            yield return ExtendedSaveData.ShowLoadFailedWithIssueDialog(titleController, selectable, callback);
            yield break;
        }
        callback(result);
    }

    public static void CheckIsSaveAllowedToBeLoaded(this ContinueOrNewButton continueOrNewButton)
    {
        var slotNum = GameManager.Instance.SaveManager.ActiveSettingsData.lastSaveSlot;
        SaveData s = GameManager.Instance.SaveManager.LoadIntoMemory(slotNum);
        continueOrNewButton.StartCoroutine(continueOrNewButton.titleController.CheckIsSaveAllowedToBeLoaded(slotNum, s, continueOrNewButton.selectable, (bool result) =>
        {
            if (result)
            {
                GameManager.Instance.Loader.LoadGameFromTitle(canCreateNew: false);
            }
            else
            {
                continueOrNewButton.hasBeenClicked = false;
                GameManager.Instance.Input.SetActiveActionLayer(ActionLayer.POPUP_WINDOW);
            }
        }));
    }

    public static void CheckIsSaveAllowedToBeLoaded(this SaveSlotUI saveSlotUI)
    {
        saveSlotUI.StartCoroutine(saveSlotUI.titleController.CheckIsSaveAllowedToBeLoaded(saveSlotUI.slotNum, saveSlotUI.saveData, saveSlotUI.selectable, (bool result) =>
        {
            if (result)
            {
                saveSlotUI.DoContinueOrNew(canCreateNew: false);
            }
            else
            {
                saveSlotUI.hasBeenClicked = false;
                GameManager.Instance.Input.SetActiveActionLayer(ActionLayer.POPUP_WINDOW);
            }
        }));
    }
    #endregion

    #region Reflection
    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeFields" />
    public static FieldInfo[] GetRuntimeFieldsIncludingBase(this Type type)
    {
        Dictionary<string, FieldInfo> fields = new Dictionary<string, FieldInfo>();
        while (type != null)
        {
            foreach (var field in type.GetRuntimeFields())
            {
                fields.SafeAdd(field.Name, field);
            }
            type = type.BaseType;
        }
        return fields.Values.ToArray();
    }

    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeProperties" />
    public static PropertyInfo[] GetRuntimePropertiesIncludingBase(this Type type)
    {
        Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
        while (type != null)
        {
            foreach (var property in type.GetRuntimeProperties())
            {
                properties.SafeAdd(property.Name, property);
            }
            type = type.BaseType;
        }
        return properties.Values.ToArray();
    }

    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeMethods" />
    public static MethodInfo[] GetRuntimeMethodsIncludingBase(this Type type)
    {
        Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();
        while (type != null)
        {
            foreach (var method in type.GetRuntimeMethods())
            {
                methods.SafeAdd(method.Name, method);
            }
            type = type.BaseType;
        }
        return methods.Values.ToArray();
    }

    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeEvents" />
    public static EventInfo[] GetRuntimeEventsIncludingBase(this Type type)
    {
        Dictionary<string, EventInfo> events = new Dictionary<string, EventInfo>();
        while (type != null)
        {
            foreach (var @event in type.GetRuntimeEvents())
            {
                events.SafeAdd(@event.Name, @event);
            }
            type = type.BaseType;
        }
        return events.Values.ToArray();
    }

    /// <summary>
    /// Gets the bytes for an embedded resource with the given name (found with endsWith), or null if no matches
    /// </summary>
    public static Stream? GetEmbeddedResource(this Assembly assembly, string endsWith)
    {
        var resource = Array.Find(assembly.GetManifestResourceNames(), s => s.EndsWith(endsWith));
        return resource != null ? assembly.GetManifestResourceStream(resource) : null;
    }

    /// <inheritdoc cref="GetEmbeddedResource" />
    public static bool TryGetEmbeddedResource(this Assembly assembly, string endsWith, out Stream? stream)
    {
        stream = GetEmbeddedResource(assembly, endsWith);
        return stream != null;
    }

    public static IEnumerable<Type> GetFilteredTypeList(this Type baseType) => UnityExtensions.GetFilteredTypeList(baseType);

    public static IEnumerable<Type> GetFilteredTypeList(this Assembly assembly, Type baseType)
    {
        return from type in assembly.GetTypes()
               where !type.IsAbstract
               where baseType.IsAssignableFrom(type)
               select type;
    }
    #endregion

    #region Stream
    /// <summary>
    /// Synchronously gets the full array of bytes from any stream, disposing with the Stream afterwards
    /// </summary>
    public static byte[]? GetByteArray(this Stream? stream)
    {
        if (stream == null)
        {
            return null;
        }

        try
        {
            using (stream)
            {
                if (stream is MemoryStream memoryStream)
                {
                    return memoryStream.ToArray();
                }

                using (memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region String
    public static string SplitCamelCase(this string s) => Regex.Replace(s, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2").Spaced();

    /// <summary>
    /// Puts spaces between capitalized words within a string. Accounts for acronyms like VR.
    /// </summary>
    /// <param name="s">The string to search for a match.</param>
    public static string Spaced(this string s) => Regex.Replace(s, @"(\p{Ll})(\P{Ll})", "$1 $2").Replace("  ", " ");

    /// <summary>
    /// Returns null if a string is empty / whitespace, otherwise just returns back the string
    /// </summary>
    public static string? NullIfEmpty(this string s) => string.IsNullOrWhiteSpace(s) ? null : s;

    /// <inheritdoc cref="Regex.Replace(string,string,string,RegexOptions)" />
    public static string RegexReplace(this string input, string pattern, string replacement,
          RegexOptions options = RegexOptions.Multiline | RegexOptions.CultureInvariant) =>
        Regex.Replace(input, pattern, replacement, options);

    public static bool TryMatch(this Regex regex, string input, out Match? match)
    {
        match = regex.Match(input);
        if (match.Success)
        {
            return true;
        }
        else
        {
            match = null;
            return false;
        }
    }

    /// <summary>
    /// Gets the index of a string inside this string using Invariant Culture
    /// </summary>
    /// <param name="source">The string to get the index from</param>
    /// <param name="value">The string to find the index of</param>
    /// <returns>The index if found, -1 if not</returns>
    public static int IndexOfInvariant(this string source, string value) => CultureInfo.InvariantCulture.CompareInfo.IndexOf(source, value);

    /// <summary>
    /// Gets the last index of a string inside this string using Invariant Culture
    /// </summary>
    /// <param name="source">The string to get the last index from</param>
    /// <param name="value">The string to find the last index of</param>
    /// <returns>The index if found, -1 if not</returns>
    public static int LastIndexOfInvariant(this string source, string value) => CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(source, value);

    public static string FixBackslashes(this string s) => s.Replace("\\\\", "/").Replace("\\", "/");
    #endregion

    #region Harmony
    public static CodeMatcher LogInstructions(this CodeMatcher matcher, string prefix)
    {
        matcher.InstructionEnumeration().LogInstructions(prefix + " at " + matcher.Pos);
        return matcher;
    }

    public static IEnumerable<CodeInstruction> LogInstructions(this IEnumerable<CodeInstruction> instructions, string prefix)
    {
        var message = prefix;
        int i = 0;
        foreach (var instruction in instructions)
            message += $"\n{i++} | {instruction}";
        WinchCore.Log.Error(message);
        return instructions;
    }
    #endregion

    #region Events
    /// <summary>
    /// Invokes each delegate, printing an error if an invocation fails. If an invocation fails, the other delegates will still be invoked.
    /// </summary>
    /// <param name="multicast">The MulticastDelegate to invoke.</param>
    /// <param name="args">The arguments to pass to each invocation.</param>
    public static void SafeInvoke(this MulticastDelegate multicast, params object[] args)
    {
        foreach (var del in multicast.GetInvocationList())
        {
            try
            {
                del.DynamicInvoke(args);
            }
            catch (TargetInvocationException ex)
            {
                WinchCore.Log.Error($"Error invoking delegate! {ex.InnerException}");
            }
        }
    }

    /// <summary>
    /// Raises an event in an instance by it's name.
    /// </summary>
    /// <typeparam name="T">The type of the instance.</typeparam>
    /// <param name="instance">The instance to raise the event in.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="args">The arguments to be passed to the event.</param>
    public static void RaiseEvent<T>(this T instance, string eventName, params object[] args)
    {
        const BindingFlags flags = BindingFlags.Instance
                                   | BindingFlags.Static
                                   | BindingFlags.Public
                                   | BindingFlags.NonPublic
                                   | BindingFlags.DeclaredOnly;
        if (typeof(T)
                .GetField(eventName, flags)?
                .GetValue(instance) is not MulticastDelegate multiDelegate)
        {
            return;
        }

        multiDelegate.SafeInvoke(args);
    }
    #endregion

    #region Collections
    /// <summary>
    /// Deconstruct a KeyValuePair
    /// </summary>
    public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> kvp, out T1 t1, out T2 t2)
    {
        t1 = kvp.Key;
        t2 = kvp.Value;
    }

    /// <summary>
    /// Add an item to an array
    /// </summary>
    /// <param name="array">The array to add to.</param>
    /// <param name="item">The item to add.</param>
    /// <returns>An array with <paramref name="item"/> added.</returns>
    public static T[] Add<T>(this T[] array, T item)
        => array.Concat(new T[] { item }).ToArray();

    /// <summary>
    /// Add items to an array
    /// </summary>
    /// <param name="array">The array to add to.</param>
    /// <param name="items">The items to add.</param>
    /// <returns>An array with <paramref name="items"/> added.</returns>
    public static T[] AddRange<T>(this T[] array, T[] items)
        => array.Concat(items).ToArray();

    /// <summary>
    /// Remove an item from an array
    /// </summary>
    /// <param name="array">The array to remove from.</param>
    /// <param name="item">The item to remove.</param>
    /// <returns>An array with <paramref name="item"/> removed.</returns>
    public static T[] Remove<T>(this T[] array, T item)
        => Remove(array, item, out bool _);

    /// <summary>
    /// Remove an item from an array
    /// </summary>
    /// <param name="array">The array to remove from.</param>
    /// <param name="item">The item to remove.</param>
    /// <param name="removed">Whether the item was removed or not.</param>
    /// <returns>An array with <paramref name="item"/> removed.</returns>
    public static T[] Remove<T>(this T[] array, T item, out bool removed)
    {
        var list = new List<T>(array);
        removed = list.Remove(item);
        return list.ToArray();
    }

    /// <summary>
    /// Retrieves all the elements that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="match"> The Predicate delegate that defines the conditions of the elements to search for.</param>
    /// <returns></returns>
    public static T[] FindAll<T>(this T[] array, Predicate<T> match) => Array.FindAll(array, match);

    /// <summary>Performs the specified action on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <param name="action">The <see cref="T:System.Action`1" /> delegate to perform on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="action" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.InvalidOperationException">An element in the collection has been modified.</exception>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (action == null) throw new ArgumentNullException("action");

        foreach (TSource item in source)
            action(item);
    }

    /// <summary>Performs the specified action on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <param name="action">The <see cref="T:System.Action`2" /> delegate to perform on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="action" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.InvalidOperationException">An element in the collection has been modified.</exception>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (action == null) throw new ArgumentNullException("action");

        int num = 0;
        foreach (TSource item in source)
            action(item, num++);
    }

    /// <summary>Searches for a sequence and returns the index of its first value that matches the condition.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to search.</param>
    /// <param name="predicate">The condition used to locate the index in <paramref name="source" />.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The zero-based index of the first value that matches the condition in the entire <paramref name="source" />, if found; otherwise, -1.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="predicate"/> is <see langword="null" />.</exception>
    public static int IndexOf<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (predicate == null) throw new ArgumentNullException("predicate");

        var index = 0;
        using IEnumerator<TSource> enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (predicate(enumerator.Current))
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    /// <summary>Filters a sequence of values by testing if they match a specified type.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type to filter and return.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that are the type <typeparamref name="TResult"/>.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static IEnumerable<TResult> WhereType<TSource, TResult>(this IEnumerable<TSource> source)
        => source.Where(item => item is TResult).Cast<TResult>();

    /// <summary>Filters a sequence of values by testing if they don't match a specified type.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TNot">The type to filter out.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence without any of the type <typeparamref name="TNot"/>.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static IEnumerable<TSource> WhereNotType<TSource, TNot>(this IEnumerable<TSource> source)
        => source.Where(item => item is not TNot);

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
    {
        foreach (var item in source)
        {
            if (item is object)
            {
                yield return item;
            }
        }
    }

    /// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
    public static TResult[] CastToArray<TResult>(this IEnumerable source)
        => source.Cast<TResult>().ToArray();

    /// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
    public static TResult[] Cast<TSource, TResult>(this TSource[] source)
        => source.Cast<TResult>().ToArray();

    /// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
    public static List<TResult> CastToList<TResult>(this IEnumerable source)
        => source.Cast<TResult>().ToList();

    /// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
    public static List<TResult> Cast<TSource, TResult>(this List<TSource> source)
        => source.Cast<TResult>().ToList();

    /// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
    public static HashSet<TResult> CastToHashSet<TResult>(this IEnumerable source)
        => Enumerable.ToHashSet(source.Cast<TResult>());

    /// <inheritdoc cref="Enumerable.Cast{TResult}(IEnumerable)"/>
    public static HashSet<TResult> Cast<TSource, TResult>(this HashSet<TSource> source)
        => Enumerable.ToHashSet(source.Cast<TResult>());

    /// <summary>Applies an accumulator function over a sequence.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to aggregate over.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="initialValue">The initial accumulator value.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <returns>The final accumulator value.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="func" /> is <see langword="null" />.</exception>
    public static TAccumulate Reduce<TSource, TAccumulate>(this IEnumerable<TSource> source, Func<TAccumulate, TSource, TAccumulate> func, TAccumulate initialValue = default)
        => source.Aggregate(initialValue, func);

    /// <summary>Projects each element of a sequence into a new form.</summary>
    /// <param name="source">A sequence of values to invoke a transform function on.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector" />.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> whose elements are the result of invoking the transform function on each element of <paramref name="source" />.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="selector" /> is <see langword="null" />.</exception>
    public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        => source.Select(selector);

    /// <summary>Filters a sequence of values based on a predicate.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that satisfy the condition.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is <see langword="null" />.</exception>
    public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        => source.Where(new Func<TSource, bool>(predicate));

    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default) => dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;

    public static TKey KeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, TKey defaultValue = default) => KeyByValue(dictionary, value, defaultValue);
    public static TKey GetKeyOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, TKey defaultValue = default)
    {
        foreach (KeyValuePair<TKey, TValue> pair in dictionary)
        {
            if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
                return pair.Key;
        }
        return defaultValue;
    }

    public static TKey KeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer, TKey defaultValue = default) => KeyByValue(dictionary, value, comparer, defaultValue);
    public static TKey GetKeyOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer, TKey defaultValue = default)
    {
        foreach (KeyValuePair<TKey, TValue> pair in dictionary)
        {
            if (comparer.Equals(pair.Value, value))
                return pair.Key;
        }
        return defaultValue;
    }

    public static bool SafeAdd<T>(this IList<T> list, T value)
    {
        if (!list.Contains(value))
        {
            list.Add(value);
            return true;
        }
        return false;
    }

    public static bool SafeAdd<T, K>(this IDictionary<T, K> dict, T key, K value)
    {
        if (!dict.ContainsKey(key))
        {
            dict.Add(key, value);
            return true;
        }
        return false;
    }

    public static void AddOrChange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary.ContainsKey(key))
            dictionary[key] = value;
        else
            dictionary.Add(key, value);
    }

    public static bool QuickRemove<T>(this IList<T> list, T item)
    {
        int num = list.IndexOf(item);
        if (num >= 0)
        {
            list.QuickRemoveAt(num);
            return true;
        }
        return false;
    }

    public static void QuickRemoveAt<T>(this IList<T> list, int index)
    {
        list[index] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
    }

    public static bool TryGetValue<T>(this T[] source, int index, out T value)
    {
        if (source.Length > index)
        {
            value = source[index];
            return true;
        }
        value = default(T);
        return false;
    }

    public static bool TryGetValue<T>(this List<T> source, int index, out T value)
    {
        if (source.Count > index)
        {
            value = source[index];
            return true;
        }
        value = default(T);
        return false;
    }

    public static bool TryGetValue<T>(this IEnumerable<T> source, Predicate<T> predicate, out T value)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                value = item;
                return true;
            }
        }
        value = default(T);
        return false;
    }
    #endregion

    #region Unity
    public static string RemoveClone(this string str) => str.Replace("(Clone)", "").Trim();

    public static GameObject FixPrimitive(this GameObject primitive, bool fixCollider = true)
    {
        var specific = primitive.GetOrAddComponent<SpecificShaderReplacer>();
        specific.renderer = primitive.GetComponent<MeshRenderer>();
        specific.shader = "Shader Graphs/Lit_Shader";
        specific.renderer.sharedMaterial.name = "Lit";
        specific.ReplaceShader();
        if (fixCollider)
        {
            if (primitive.TryGetComponent<SphereCollider>(out SphereCollider sphereCollider))
            {
                var collider = new GameObject("Collider", typeof(SphereCollider));
                collider.layer = Layer.CollidesWithPlayerAndCamera;
                collider.transform.SetParent(primitive.transform, false);
                collider.GetOrAddComponent<SphereCollider>().center = sphereCollider.center;
                collider.GetOrAddComponent<SphereCollider>().radius = sphereCollider.radius;
            }
            else if (primitive.TryGetComponent<BoxCollider>(out BoxCollider boxCollider))
            {
                var collider = new GameObject("Collider", typeof(BoxCollider));
                collider.layer = Layer.CollidesWithPlayerAndCamera;
                collider.transform.SetParent(primitive.transform, false);
                collider.GetOrAddComponent<BoxCollider>().center = boxCollider.center;
                collider.GetOrAddComponent<BoxCollider>().size = boxCollider.size;
            }
            else if (primitive.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsuleCollider))
            {
                var collider = new GameObject("Collider", typeof(CapsuleCollider));
                collider.layer = Layer.CollidesWithPlayerAndCamera;
                collider.transform.SetParent(primitive.transform, false);
                collider.GetOrAddComponent<CapsuleCollider>().center = capsuleCollider.center;
                collider.GetOrAddComponent<CapsuleCollider>().radius = capsuleCollider.radius;
                collider.GetOrAddComponent<CapsuleCollider>().height = capsuleCollider.height;
                collider.GetOrAddComponent<CapsuleCollider>().direction = capsuleCollider.direction;
            }
            else if (primitive.TryGetComponent<MeshCollider>(out MeshCollider meshCollider))
            {
                var collider = new GameObject("Collider", typeof(MeshCollider));
                collider.layer = Layer.CollidesWithPlayerAndCamera;
                collider.transform.SetParent(primitive.transform, false);
                collider.GetOrAddComponent<MeshCollider>().convex = meshCollider.convex;
                collider.GetOrAddComponent<MeshCollider>().cookingOptions = meshCollider.cookingOptions;
                collider.GetOrAddComponent<MeshCollider>().sharedMesh = meshCollider.sharedMesh;
            }
            primitive.RemoveComponent<Collider>();
        }
        return primitive;
    }

    internal static Transform? prefabParent;
    internal static Transform PrefabParent
    {
        get
        {
            if (prefabParent == null)
            {
                var prefabParentObj = new GameObject("PrefabParent");
                prefabParentObj.Deactivate();
                prefabParentObj.DontDestroyOnLoad();
                prefabParent = prefabParentObj.transform;
            }
            return prefabParent;
        }
    }

    /// <summary>
    /// Parent the given object to an inactive don't destroy on load object.
    /// </summary>
    public static GameObject Prefabitize(this GameObject obj)
    {
        if (!obj.IsResource())
            obj.transform.SetParent(PrefabParent, false);
        return obj;
    }

    /// <summary>
    /// Copies an object and prefabitizes that copy.
    /// </summary>
    public static GameObject CopyPrefab(this GameObject original) => original.Instantiate(PrefabParent, false).Rename(original.name);

    public static bool IsResource(this GameObject obj)
    {
        return !obj.scene.IsValid();
    }

    /// <summary>
    /// Activates the game object.
    /// </summary>
    public static void Activate(this GameObject obj) => obj.SetActive(true);

    /// <summary>
    /// Deactivates the game object.
    /// </summary>
    public static void Deactivate(this GameObject obj) => obj.SetActive(false);

    /// <summary>
    /// Deconstruct a Rect
    /// </summary>
    public static void Deconstruct(this Rect rect, out float x, out float y, out float width, out float height)
    {
        x = rect.x;
        y = rect.y;
        width = rect.width;
        height = rect.height;
    }

    /// <summary>
    /// Deconstruct a Vector2
    /// </summary>
    public static void Deconstruct(this Vector2 vector2, out float x, out float y)
    {
        x = vector2.x;
        y = vector2.y;
    }

    public static Texture2D ToTexture2D(this RenderTexture rTex)
    {
        Texture2D texture2D = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        texture2D.ReadPixels(new Rect(0f, 0f, (float)rTex.width, (float)rTex.height), 0, 0);
        texture2D.Apply();
        return texture2D;
    }

    public static string GetPath(this Transform current)
    {
        if (current.parent == null) return current.name;
        return current.parent.GetPath() + "/" + current.name;
    }

    public static GameObject FindChild(this GameObject go, string childPath) =>
        go.transform.Find(childPath)?.gameObject;

    public static Component[] GetComponents(this GameObject go) => go.GetComponents<Component>().Where(c => c != null).ToArray();

    public static void RemoveComponent<T>(this GameObject go) where T : Component => UnityEngine.Object.Destroy(go.GetComponent<T>());
    public static void RemoveComponentImmediate<T>(this GameObject go) where T : Component => UnityEngine.Object.DestroyImmediate(go.GetComponent<T>());
    public static void RemoveComponent<T>(this GameObject go, T component) where T : Component => UnityEngine.Object.Destroy(component);
    public static void RemoveComponentImmediate<T>(this GameObject go, T component) where T : Component => UnityEngine.Object.DestroyImmediate(component);

    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null) t = go.AddComponent<T>();
        return t;
    }

    public static T GetOrAddComponent<T>(this Component component) where T : Component => component.gameObject.GetOrAddComponent<T>();

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="go">Object to test</param>
    /// <param name="type">The type of component</param>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent(this GameObject go, System.Type type)
    {
        return go.GetComponent(type) != null;
    }

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="go">Object to test</param>
    /// <param name="comp">The component if found, null if not</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this GameObject go, out T comp) where T : Component
    {
        comp = go.GetComponent<T>();

        return comp != null;
    }

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="go">Object to test</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this GameObject go) where T : Component
    {
        return go.GetComponent<T>() != null;
    }

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="component">Object to test</param>
    /// <param name="comp">The component if found, null if not</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this Component component, out T comp) where T : Component => component.gameObject.HasComponent(out comp);

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="component">Object to test</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this Component component) where T : Component => component.gameObject.HasComponent<T>();

    public static GameObject InstantiateInactive(this GameObject original)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static GameObject InstantiateInactive(this GameObject original, Transform parent, bool worldPositionStays)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original, parent, worldPositionStays);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static GameObject InstantiateInactive(this GameObject original, Vector3 position, Quaternion rotation)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original, position, rotation);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static GameObject InstantiateInactive(this GameObject original, Vector3 position, Quaternion rotation, Transform parent)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original, position, rotation, parent);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static T Instantiate<T>(this T original) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original);
        copy.Rename(original.name);
        return copy;
    }

    public static T Instantiate<T>(this T original, Transform parent, bool worldPositionStays) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original, parent, worldPositionStays);
        copy.Rename(original.name);
        return copy;
    }

    public static T Instantiate<T>(this T original, Vector3 position) where T : UnityEngine.Object
        => original.Instantiate<T>(position, Quaternion.identity);

    public static T Instantiate<T>(this T original, Vector3 position, Transform parent) where T : UnityEngine.Object
        => original.Instantiate<T>(position, Quaternion.identity, parent);

    public static T Instantiate<T>(this T original, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original, position, rotation);
        copy.Rename(original.name);
        return copy;
    }

    public static T Instantiate<T>(this T original, Vector3 position, Quaternion rotation, Transform parent) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original, position, rotation, parent);
        copy.Rename(original.name);
        return copy;
    }

    public static T DontDestroyOnLoad<T>(this T target) where T : UnityEngine.Object
    {
        UnityEngine.Object.DontDestroyOnLoad(target);
        return target;
    }

    public static T Rename<T>(this T target, string name) where T : UnityEngine.Object
    {
        target.name = name;
        return target;
    }

    public static void Destroy<T>(this T target) where T : UnityEngine.Object => UnityEngine.Object.Destroy(target);
    public static void DestroyImmediate<T>(this T target) where T : UnityEngine.Object => UnityEngine.Object.DestroyImmediate(target);

    public static void SmoothLookDir(this GameObject go, Vector3 direction, float dt, float angularVelocity)
    {
        var start = go.transform.rotation;
        var end = Quaternion.FromToRotation(Vector3.forward, direction);

        var angle = Quaternion.Angle(start, end);

        go.transform.rotation = Quaternion.Slerp(start, end, (angularVelocity / angle) * dt);
    }

    public static void LookDir(this GameObject go, Vector3 direction)
    {
        go.transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
    }

    public static GameObject FindChildWithExactName(this GameObject parent, string name)
    {
        var parentTransform = parent.transform;
        for (int i = parentTransform.childCount - 1; i >= 0; i--)
        {
            var childTransform = parentTransform.GetChild(i);
            if (childTransform.name == name)
                return childTransform.gameObject;
        }
        return null;
    }

    public static Transform FindChildWithExactName(this Transform parent, string name)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            var childTransform = parent.GetChild(i);
            if (childTransform.name == name)
                return childTransform;
        }
        return null;
    }

    public static void DestroyAllComponents<T>(this GameObject obj) where T : Component
    {
        foreach (var component in obj.GetComponents<T>())
        {
            GameObject.Destroy(component);
        }
    }

    public static void DestroyAllComponentsImmediate<T>(this GameObject obj) where T : Component
    {
        foreach (var component in obj.GetComponents<T>())
        {
            GameObject.DestroyImmediate(component);
        }
    }

    public static void DestroyAllChildren(this Transform t)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(t.GetChild(i).gameObject);
        }
        t.DetachChildren();
    }

    public static void DestroyAllChildrenImmediate(this Transform t)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(t.GetChild(i).gameObject);
        }
        t.DetachChildren();
    }

    public static void DestroyAllChildren(this Transform t, int skipIndex)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            if (i == skipIndex) continue;
            GameObject.Destroy(t.GetChild(i).gameObject);
        }
    }

    public static void DestroyAllChildrenImmediate(this Transform t, int skipIndex)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            if (i == skipIndex) continue;
            GameObject.DestroyImmediate(t.GetChild(i).gameObject);
        }
    }

    public static void SetLocalPositionX(this Transform trans, float x)
    {
        Vector3 localPosition = trans.localPosition;
        localPosition.x = x;
        trans.localPosition = localPosition;
    }

    public static void SetLocalPositionY(this Transform trans, float y)
    {
        Vector3 localPosition = trans.localPosition;
        localPosition.y = y;
        trans.localPosition = localPosition;
    }

    public static void SetLocalPositionZ(this Transform trans, float z)
    {
        Vector3 localPosition = trans.localPosition;
        localPosition.z = z;
        trans.localPosition = localPosition;
    }

    public static Quaternion InverseTransformRotation(this Transform t, Quaternion q)
    {
        return Quaternion.Inverse(t.rotation) * q;
    }

    public static StringTableEntry GetEntry(
      this StringTable stringTable,
      long keyId,
      string key)
    {
        if (keyId != 0L)
            return stringTable.GetEntry(keyId);
        else if (!string.IsNullOrWhiteSpace(key))
            return stringTable.GetEntry(key);

        return null;
    }

    public static float[] ToArray(this Vector2 value) => new float[2] { value.x, value.y };
    public static float[] ToArray(this Vector3 value) => new float[3] { value.x, value.y, value.z };
    public static float[] ToArray(this Vector4 value) => new float[4] { value.x, value.y, value.z, value.w };

    public static Vector3 Abs(this Vector3 value) => new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));

    #region Coroutines
    public static void FireOnNextUpdate(this MonoBehaviour component, Action action) =>
        component.FireInNUpdates(action, 1);

    public static void FireInNUpdates(this MonoBehaviour component, Action action, int n) =>
        component.StartCoroutine(WaitForFrames(action, n));

    public static void RunWhen(this MonoBehaviour component, Func<bool> predicate, Action action) =>
        component.StartCoroutine(WaitUntil(predicate, action));

    private static IEnumerator WaitForFrames(Action action, int n)
    {
        for (var i = 0; i < n; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        action.Invoke();
    }

    private static IEnumerator WaitUntil(Func<bool> predicate, Action action)
    {
        yield return new WaitUntil(predicate);
        action();
    }
    #endregion

    #region RectTransform
    public static void SetWidth(this RectTransform rt, float width)
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }

    public static void SetHeight(this RectTransform rt, float height)
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

    public static void SetPosX(this RectTransform rt, float posX)
    {
        rt.localPosition = new Vector3(posX, rt.localPosition.y, rt.localPosition.z);
    }

    public static void SetPosY(this RectTransform rt, float posY)
    {
        rt.localPosition = new Vector3(rt.localPosition.x, posY, rt.localPosition.z);
    }

    public static void SetAnchoredPosX(this RectTransform rt, float posX)
    {
        rt.anchoredPosition = new Vector3(posX, rt.anchoredPosition.y);
    }

    public static void SetAnchoredPosY(this RectTransform rt, float posY)
    {
        rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, posY);
    }
    #endregion
    #endregion
}