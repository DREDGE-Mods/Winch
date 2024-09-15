using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;

namespace Winch.AbyssApi;

public static class ScriptableObjectInstances
{
    private static IReadOnlyList<WorldEventData>? _worldEventDatas;

    /// <summary>
    /// All vanilla world event datas.
    /// </summary>
    public static IReadOnlyCollection<WorldEventData> WorldEventDatas => _worldEventDatas ??= Addressables.LoadAssetsAsync<WorldEventData>(GameManager.Instance.DataLoader.worldEventDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<WeatherData>? _weatherDatas;

    /// <summary>
    /// All vanilla weather datas.
    /// </summary>
    public static IReadOnlyCollection<WeatherData> WeatherDatas => _weatherDatas ??= Addressables.LoadAssetsAsync<WeatherData>(GameManager.Instance.DataLoader.weatherDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<QuestData>? _questDatas;

    /// <summary>
    /// All vanilla quest datas.
    /// </summary>
    public static IReadOnlyCollection<QuestData> QuestDatas => _questDatas ??= Addressables.LoadAssetsAsync<QuestData>(GameManager.Instance.DataLoader.questDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<GridConfiguration>? _gridConfigurations;

    /// <summary>
    /// All vanilla grid configurations.
    /// </summary>
    public static IReadOnlyCollection<GridConfiguration> GridConfigurations => _gridConfigurations ??= Addressables.LoadAssetsAsync<GridConfiguration>(GameManager.Instance.DataLoader.gridConfigDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<MapMarkerData>? _mapMarkerDatas;

    /// <summary>
    /// All vanilla map marker datas.
    /// </summary>
    public static IReadOnlyCollection<MapMarkerData> MapMarkerDatas => _mapMarkerDatas ??= Addressables.LoadAssetsAsync<MapMarkerData>(GameManager.Instance.DataLoader.mapMarkerDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<QuestGridConfig>? _questGridConfigs;

    /// <summary>
    /// All vanilla quest grid configs.
    /// </summary>
    public static IReadOnlyCollection<QuestGridConfig> QuestGridConfigs => _questGridConfigs ??= Addressables.LoadAssetsAsync<QuestGridConfig>(GameManager.Instance.DataLoader.questGridDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<QuestStepData>? _questStepDatas;

    /// <summary>
    /// All vanilla quest step datas.
    /// </summary>
    public static IReadOnlyCollection<QuestStepData> QuestStepDatas => _questStepDatas ??= QuestDatas.SelectMany(questData => questData.steps).ToList().AsReadOnly();

    private static IReadOnlyList<AchievementData>? _achievementDatas;
    /// <summary>
    /// All vanilla achievement datas.
    /// </summary>
    public static IReadOnlyCollection<AchievementData> AchievementDatas => _achievementDatas ??= Addressables.LoadAssetsAsync<AchievementData>(GameManager.Instance.AchievementManager.achievementDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<UpgradeData>? _upgradeDatas;

    /// <summary>
    /// All vanilla upgrade datas.
    /// </summary>
    public static IReadOnlyCollection<UpgradeData> UpgradeDatas => _upgradeDatas ??= Addressables.LoadAssetsAsync<UpgradeData>(GameManager.Instance.UpgradeManager.upgradeDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<ItemData>? _itemDatas;

    /// <summary>
    /// All vanilla item datas.
    /// </summary>
    public static IReadOnlyCollection<ItemData> ItemDatas => _itemDatas ??= Addressables.LoadAssetsAsync<ItemData>(GameManager.Instance.ItemManager.itemDataAssetLabelReference, null).WaitForCompletion().ToList().AsReadOnly();

    private static IReadOnlyList<HarvestableItemData>? _harvestableItemDatas;

    /// <summary>
    /// All vanilla harvestable item datas.
    /// </summary>
    public static IReadOnlyCollection<HarvestableItemData> HarvestableItemDatas => _harvestableItemDatas ??= ItemDatas.OfType<HarvestableItemData>().ToList().AsReadOnly();

    private static IReadOnlyList<FishItemData>? _fishItemDatas;

    /// <summary>
    /// All vanilla fish item datas.
    /// </summary>
    public static IReadOnlyCollection<FishItemData> FishItemDatas => _fishItemDatas ??= ItemDatas.OfType<FishItemData>().ToList().AsReadOnly();


    private static IReadOnlyList<HullUpgradeData>? _hullUpgradeDatas;

    /// <summary>
    /// All vanilla hull upgrade datas.
    /// </summary>
    public static IReadOnlyCollection<HullUpgradeData> HullUpgradeDatas => _hullUpgradeDatas ??= UpgradeDatas.OfType<HullUpgradeData>().ToList().AsReadOnly();

    private static IReadOnlyList<SlotUpgradeData>? _slotUpgradeDatas;

    /// <summary>
    /// All vanilla slot upgrade datas.
    /// </summary>
    public static IReadOnlyCollection<SlotUpgradeData> SlotUpgradeDatas => _slotUpgradeDatas ??= UpgradeDatas.OfType<SlotUpgradeData>().ToList().AsReadOnly();


}