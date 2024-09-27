using System;
using Winch.Core.API.Events.Addressables;

namespace Winch.Core.API;

public static class DredgeEvent
{
    public static AddressableEvents AddressableEvents = new AddressableEvents();

    public static event Action? OnManagersLoaded;
    internal static void TriggerManagersLoaded()
    {
        WinchCore.Log.Debug("Triggered OnManagersLoaded event");
        OnManagersLoaded?.Invoke();
    }

    public static event Action? OnModAssetsLoaded;
    internal static void TriggerModAssetsLoaded()
    {
        WinchCore.Log.Debug("Triggered OnModAssetsLoaded event");
        OnModAssetsLoaded?.Invoke();
    }

    public static event Action<GameSceneInitializer>? OnGameLoading;
    internal static void TriggerGameLoading(GameSceneInitializer gameSceneInitializer)
    {
        WinchCore.Log.Debug("Triggered OnGameLoading event");
        OnGameLoading?.Invoke(gameSceneInitializer);
    }

    public static event Action<DredgeDialogueRunner>? OnDialogueRunnerLoaded;
    internal static void TriggerDialogueRunnerLoaded(DredgeDialogueRunner dialogueRunner)
    {
        WinchCore.Log.Debug("Triggered OnDialogueRunnerLoaded event");
        OnDialogueRunnerLoaded?.Invoke(dialogueRunner);
    }

    public static event Action<HarvestPOI, SpatialItemInstance>? OnPOIHarvested;
    /// <param name="harvestPOI">The POI that was harvested from</param>
    /// <param name="itemInstance">Harvestable item instance</param>
    public static void TriggerPOIHarvested(HarvestPOI harvestPOI, SpatialItemInstance itemInstance)
    {
        WinchCore.Log.Debug($"Triggered OnPOIHarvested({harvestPOI.Harvestable.GetId()}, {itemInstance.id}) event");
        OnPOIHarvested?.Invoke(harvestPOI, itemInstance);
    }

    public static event Action<ItemPOI, ItemInstance>? OnPOIItemCollected;
    /// <param name="itemPOI">The POI that was collected from</param>
    /// <param name="itemInstance">Item instance (can be spatial or non spatial)</param>
    public static void TriggerPOIItemCollected(ItemPOI itemPOI, ItemInstance itemInstance)
    {
        WinchCore.Log.Debug($"Triggered OnPOIItemCollected({itemPOI.Harvestable.GetId()}, {itemInstance.id}) event");
        OnPOIItemCollected?.Invoke(itemPOI, itemInstance);
    }

    public static event Action<SpatialItemInstance>? OnFishCaught;
    /// <param name="itemInstance">Fish item instance</param>
    public static void TriggerFishCaught(SpatialItemInstance itemInstance)
    {
        WinchCore.Log.Debug($"Triggered OnFishCaught({itemInstance.id}) event");
        OnFishCaught?.Invoke(itemInstance);
    }

    public static event Action<BoatArea, string> OnBoatColorsChanged;
    public static void TriggerBoatColorsChanged(BoatArea area, string paintId)
    {
        WinchCore.Log.Debug($"Triggered OnBoatColorsChanged({area},{paintId}) event");
        OnBoatColorsChanged?.Invoke(area, paintId);
    }

    public static event Action<string> OnBoatFlagChanged;
    public static void TriggerBoatFlagChanged(string flagId)
    {
        WinchCore.Log.Debug($"Triggered OnBoatFlagChanged({flagId}) event");
        OnBoatFlagChanged?.Invoke(flagId);
    }
}
