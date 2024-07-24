using HarmonyLib;
using System;
using UnityEngine;
using Winch.Core.API;
using Winch.Patches;
using Winch.Util;

namespace Winch.Core
{
    internal class AssetLoaderObject : MonoBehaviour
    {
        private void Awake()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] Awake()");
            ApplicationEvents.Instance.OnTitleClosed += OnTitleClosed;
            ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
            ApplicationEvents.Instance.OnGameStartable += OnGameStartable;
            GameManager.Instance.OnGameStarted += OnGameStarted;
            GameManager.Instance.OnGameEnded += OnGameEnded;
            ApplicationEvents.Instance.OnGameUnloaded += OnGameUnloaded;

            try
            {
                LatePatcher.Initialize(WinchCore.Harmony);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to apply late winch patches: {ex}");
            }
            WinchCore.Log.Debug("Late Harmony Patching complete.");
        }

        private void OnDisable()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnDisable()");
            GameManager.Instance.OnGameStarted -= OnGameStarted;
            GameManager.Instance.OnGameEnded -= OnGameEnded;
            ApplicationEvents.Instance.OnTitleClosed -= OnTitleClosed;
            ApplicationEvents.Instance.OnGameLoaded -= OnGameLoaded;
            ApplicationEvents.Instance.OnGameStartable -= OnGameStartable;
            GameManager.Instance.OnGameStarted -= OnGameStarted;
            GameManager.Instance.OnGameEnded -= OnGameEnded;
            ApplicationEvents.Instance.OnGameUnloaded -= OnGameUnloaded;
        }

        public void Start()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] Start()");
            AssetLoader.LoadAssets();
            DredgeEvent.TriggerModAssetsLoaded();
            ModAssemblyLoader.ExecuteModAssemblies();
            Initializer.InitializePostUnityLoad();
        }

        private void OnTitleClosed()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnTitleClosed()");
        }

        private void OnGameLoaded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameLoaded()");
        }

        private void OnGameStartable()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameStartable()");
        }

        private void OnGameStarted()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameStarted()");
            DialogueUtil.Inject();
        }

        private void OnGameEnded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameEnded()");
            PoiUtil.ClearHarvestablesAndHarvestParticlePrefabs();
            CharacterUtil.ClearSpeakerData();
        }

        private void OnGameUnloaded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameUnloaded()");
        }
    }
}
