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
}
