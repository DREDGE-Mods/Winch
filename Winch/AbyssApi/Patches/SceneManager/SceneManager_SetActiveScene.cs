/*using Abyss.Events;
using Abyss.Utilities;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace Abyss.Patches;

[HarmonyPatch(typeof(SceneManager), nameof(SceneManager.SetActiveScene))]
internal static class SceneManager_SetActiveScene
{
    [HarmonyPostfix]
    private static void Postfix(Scene scene)
    {
        AbyssEvents.OnSceneLoaded.Invoke(scene);
        if (scene.name == "Game")
        {
            AbyssEvents.OnGameSceneLoaded.Invoke();
        }
    }
}*/