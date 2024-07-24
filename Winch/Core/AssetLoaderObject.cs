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
            GameManager.Instance.OnGameStarted += OnGameStarted;
            GameManager.Instance.OnGameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnDisable()");
            GameManager.Instance.OnGameStarted -= OnGameStarted;
            GameManager.Instance.OnGameEnded -= OnGameEnded;
        }

        public void Start()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] Start()");
            AssetLoader.LoadAssets();
            DredgeEvent.TriggerModAssetsLoaded();
            ModAssemblyLoader.ExecuteModAssemblies();
            Initializer.InitializePostUnityLoad();
        }

        private void OnGameStarted()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameStarted()");
        }

        private void OnGameEnded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameEnded()");
            PoiUtil.ClearHarvestablesAndHarvestParticlePrefabs();
        }
    }
}
