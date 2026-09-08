using HarmonyLib;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Winch.Core.API;

namespace Winch.Patches;

[HarmonyPatch(typeof(SceneLoader))]
internal static class SceneLoaderPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(SceneLoader.LoadTitleFromStartup))]
    private static bool LoadTitleFromStartupPrefix(SceneLoader __instance)
    {
        CustomDebug.EditorLog("[SceneLoader] LoadTitleFromStartup()");

        SceneLoader.SceneSwitchRequest request = default;

        request.doUnload = true;
        request.unloadHandle = __instance.startupSceneHandle;
        request.unloadCallback = delegate (AsyncOperationHandle<SceneInstance> unloadHandle)
        {
            __instance.startupSceneHandle = unloadHandle;
        };

        request.doLoad = true;
        request.loadSceneReference = __instance.titleSceneReference;
        request.loadHandle = __instance.titleSceneHandle;
        request.loadCallback = delegate (AsyncOperationHandle<SceneInstance> loadHandle)
        {
            __instance.titleSceneHandle = loadHandle;
            DredgeEvent.TriggerTitleOpen();
        };

        request.showLoadingScreenOnUnload = !GameManager.Instance.SaveManager.HasAnySaveFiles();
        request.hideLoadingScreenOnLoad = true;
        request.unloadMixerSnapshot = SnapshotType.NONE;
        request.loadMixerSnapshot = SnapshotType.MENU;

        __instance.StartCoroutine(__instance.DoSwitchSceneRequest(request));

        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(SceneLoader.LoadTitleFromGame))]
    private static bool LoadTitleFromGamePrefix(SceneLoader __instance)
    {
        CustomDebug.EditorLog("[SceneLoader] LoadTitleFromGame()");

        GameManager.Instance.EndGame();
        AutoSplitterData.isRunning = 0;

        SceneLoader.SceneSwitchRequest request = default;

        request.doUnload = true;
        request.unloadHandle = __instance.gameSceneHandle;
        request.unloadCallback = delegate (AsyncOperationHandle<SceneInstance> unloadHandle)
        {
            __instance.gameSceneHandle = unloadHandle;
            ApplicationEvents.Instance.TriggerGameUnloaded();
        };

        request.doLoad = true;
        request.loadSceneReference = __instance.titleSceneReference;
        request.loadHandle = __instance.titleSceneHandle;
        request.loadCallback = delegate (AsyncOperationHandle<SceneInstance> loadHandle)
        {
            __instance.titleSceneHandle = loadHandle;
            GameManager.Instance.CanUnpause = true;
            GameManager.Instance.UnpauseAndDismissSettings();

            DredgeEvent.TriggerTitleOpen();
        };

        request.showLoadingScreenOnUnload = true;
        request.hideLoadingScreenOnLoad = true;
        request.unloadMixerSnapshot = SnapshotType.LOADING;
        request.loadMixerSnapshot = SnapshotType.MENU;

        __instance.StartCoroutine(__instance.DoSwitchSceneRequest(request));

        return false;
    }
}