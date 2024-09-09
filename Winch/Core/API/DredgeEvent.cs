using System;
using Winch.Core.API.Events;
using Winch.Core.API.Events.Addressables;

namespace Winch.Core.API;

public static class DredgeEvent
{
    public static AddressableEvents AddressableEvents = new AddressableEvents();

    public static event EventHandler? ManagersLoaded;
    internal static void TriggerManagersLoaded()
    {
        WinchCore.Log.Debug("Triggered ManagersLoaded event");
        ManagersLoaded?.Invoke(null, EventArgs.Empty);
    }

    public static event EventHandler? ModAssetsLoaded;
    internal static void TriggerModAssetsLoaded()
    {
        WinchCore.Log.Debug("Triggered ModAssetsLoaded event");
        ModAssetsLoaded?.Invoke(null, EventArgs.Empty);
    }

    public static event GameLoadingEventHandler? OnGameLoading;
    internal static void TriggerOnGameLoading(GameSceneInitializer gameSceneInitializer)
    {
        WinchCore.Log.Debug("Triggered OnGameLoading event");
        OnGameLoading?.Invoke(gameSceneInitializer, EventArgs.Empty);
    }

    public static event DialogueRunnerLoadedEventHandler? DialogueRunnerLoaded;
    internal static void TriggerDialogueRunnerLoaded(DredgeDialogueRunner dialogueRunner)
    {
        WinchCore.Log.Debug("Triggered DialogueRunnerLoaded event");
        DialogueRunnerLoaded?.Invoke(dialogueRunner, EventArgs.Empty);
    }
}
