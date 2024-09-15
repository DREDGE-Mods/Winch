using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace Winch.AbyssApi;

/// <summary>
/// Contains events that are invoked by the Abyss API
/// </summary>
[UsedImplicitly]
[PublicAPI]
public static class AbyssEvents
{
    /// <summary>
    /// Invoked when the game managers are loaded, equivalent to a Harmony Postfix on <see cref="GameManager.WaitForAllAsyncManagers"/>
    /// </summary>
    public static event Action OnGameManagersLoaded = delegate { };

    internal static void InvokeGameManagersLoaded()
    {
        OnGameManagersLoaded();
    }

    /// <summary>
    /// Invoked when a scene is loaded, equivalent to adding a listener to <see cref="SceneManager.sceneLoaded"/>
    /// </summary>
    public static event Action<Scene> OnSceneLoaded = delegate { };

    internal static void InvokeSceneLoaded(Scene scene)
    {
        OnSceneLoaded(scene);
    }

    /// <summary>
    /// Invoked when the world event data is loaded, equivalent to a Harmony Postfix on <see cref="DataLoader.OnWorldEventDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<WorldEventData>> OnWorldEventDataLoaded = delegate {  };

    internal static void InvokeWorldEventDataLoaded(IList<WorldEventData> eventData)
    {
        OnWorldEventDataLoaded(eventData);
    }

    /// <summary>
    /// Invoked when the quest data is loaded, equivalent to a Harmony Postfix on <see cref="DataLoader.OnQuestDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<QuestData>> OnQuestDataLoaded = delegate { };

    internal static void InvokeQuestDataLoaded(IList<QuestData> questData)
    {
        OnQuestDataLoaded(questData);
    }

    /// <summary>
    /// Invoked when the quest grid configs are loaded, equivalent to a Harmony Postfix on <see cref="DataLoader.OnQuestGridDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<QuestGridConfig>> OnQuestGridConfigLoaded = delegate { };

    internal static void InvokeQuestGridConfigLoaded(IList<QuestGridConfig> questGridConfigs)
    {
        OnQuestGridConfigLoaded(questGridConfigs);
    }

    /// <summary>
    /// Invoked when the map marker data is loaded, equivalent to a Harmony Postfix on <see cref="DataLoader.OnMapMarkerDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<MapMarkerData>> OnMapMarkerDataLoaded = delegate { };

    internal static void InvokeMapMarkerDataLoaded(IList<MapMarkerData> mapMarkerData)
    {
        OnMapMarkerDataLoaded(mapMarkerData);
    }

    /// <summary>
    /// Invoked when the grid config data is loaded, equivalent to a Harmony Postfix on <see cref="DataLoader.OnGridConfigDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<GridConfiguration>> OnGridConfigurationLoaded = delegate { };

    internal static void InvokeGridConfigurationLoaded(IList<GridConfiguration> gridConfigurations)
    {
        OnGridConfigurationLoaded(gridConfigurations);
    }

    /// <summary>
    /// Invoked when the weather data is loaded, equivalent to a Harmony Postfix on <see cref="DataLoader.OnWeatherDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<WeatherData>> OnWeatherDataLoaded = delegate { };

    internal static void InvokeWeatherDataLoaded(IList<WeatherData> weatherData)
    {
        OnWeatherDataLoaded(weatherData);
    }

    /// <summary>
    /// Invoked when the avhivement data is loaded, equivalent to a Harmony Postfix on <see cref="AchievementManager.OnAchievementDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<AchievementData>> OnAchievementDataLoaded = delegate { };

    internal static void InvokeAchievementDataLoaded(IList<AchievementData> achievementData)
    {
        OnAchievementDataLoaded(achievementData);
    }

    /// <summary>
    /// Invoked when the item data is loaded, equivalent to a Harmony Postfix on <see cref="ItemManager.OnItemDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<ItemData>> OnItemDataLoaded = delegate { };

    internal static void InvokeItemDataLoaded(IList<ItemData> itemData)
    {
        OnItemDataLoaded(itemData);
    }

    /// <summary>
    /// Invoked when the upgrade data is loaded, equivalent to a Harmony Postfix on <see cref="UpgradeManager.OnUpgradeDataAddressablesLoaded"/>
    /// </summary>
    public static event Action<IList<UpgradeData>> OnUpgradeDataLoaded = delegate { };

    internal static void InvokeUpgradeDataLoaded(IList<UpgradeData> upgradeData)
    {
        OnUpgradeDataLoaded(upgradeData);
    }


}