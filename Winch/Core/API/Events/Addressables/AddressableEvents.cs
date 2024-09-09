using Winch.Core.API.Events.LookupTable;

namespace Winch.Core.API.Events.Addressables;

public class AddressableEvents
{
    public LookupTableLoadedHook<AbilityData> AbilitiesLoaded = new LookupTableLoadedHook<AbilityData>();

    public AddressablesLoadedHook<AchievementData> AchievementsLoaded = new AddressablesLoadedHook<AchievementData>();

    public AddressablesLoadedHook<GridConfiguration> GridConfigsLoaded = new AddressablesLoadedHook<GridConfiguration>();

    public AddressablesLoadedHook<ItemData> ItemsLoaded = new AddressablesLoadedHook<ItemData>();

    public AddressablesLoadedHook<MapMarkerData> MapMarkersLoaded = new AddressablesLoadedHook<MapMarkerData>();

    public AddressablesLoadedHook<QuestData> QuestsLoaded = new AddressablesLoadedHook<QuestData>();

    public AddressablesLoadedHook<QuestGridConfig> QuestGridConfigsLoaded = new AddressablesLoadedHook<QuestGridConfig>();

    public LookupTableLoadedHook<SpeakerData> SpeakersLoaded = new LookupTableLoadedHook<SpeakerData>();

    public AddressableLoadedHook<SupportedLocaleData> SupportedLocalesLoaded = new AddressableLoadedHook<SupportedLocaleData>();

    public AddressablesLoadedHook<UpgradeData> UpgradesLoaded = new AddressablesLoadedHook<UpgradeData>();

    public AddressablesLoadedHook<WeatherData> WeatherDataLoaded = new AddressablesLoadedHook<WeatherData>();

    public AddressablesLoadedHook<WorldEventData> WorldEventsLoaded = new AddressablesLoadedHook<WorldEventData>();
}
