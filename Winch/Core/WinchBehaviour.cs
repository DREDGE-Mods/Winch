using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Core;

[DefaultExecutionOrder(-500)]
internal class WinchBehaviour : USingleton<WinchBehaviour>
{
    protected override bool ShouldNotDestroyOnLoad => true;

    protected override void Awake()
    {
        base.Awake();
        WinchCore.Log.Debug("[WinchBehaviour] Awake()");
        ApplicationEvents.Instance.OnTitleClosed += OnTitleClosed;
        ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
        ApplicationEvents.Instance.OnGameStartable += OnGameStartable;
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameEnded += OnGameEnded;
        ApplicationEvents.Instance.OnGameUnloaded += OnGameUnloaded;
    }

    private void OnDestroy()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnDestroy()");
        ApplicationEvents.Instance.OnTitleClosed -= OnTitleClosed;
        ApplicationEvents.Instance.OnGameLoaded -= OnGameLoaded;
        ApplicationEvents.Instance.OnGameStartable -= OnGameStartable;
        GameManager.Instance.OnGameStarted -= OnGameStarted;
        GameManager.Instance.OnGameEnded -= OnGameEnded;
        ApplicationEvents.Instance.OnGameUnloaded -= OnGameUnloaded;
    }

    public void Start()
    {
        WinchCore.Log.Debug("[WinchBehaviour] Start()");
        AssetLoader.LoadAssets();
        DredgeEvent.TriggerModAssetsLoaded();
        ModAssemblyLoader.ExecuteModAssemblies();
        Initializer.InitializePostUnityLoad();
    }

    private void OnTitleClosed()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnTitleClosed()");
    }

    private void OnGameLoaded()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnGameLoaded()");
    }

    private void OnGameStartable()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnGameStartable()");
    }

    private void OnGameStarted()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnGameStarted()");
    }

    private void OnGameEnded()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnGameEnded()");
        Clear();
    }

    private static void Clear()
    {
        VibrationUtil.ClearVibrationDatas();
        DockUtil.Clear();
        AbilityUtil.Clear();
        RecipeUtil.ClearRecipeData();
        PoiUtil.Clear();
        HarvestZoneUtil.Clear();
        CharacterUtil.ClearSpeakerData();
        ShopUtil.Clear();
        ConstructableBuildingUtil.Clear();
    }

    private void OnGameUnloaded()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnGameUnloaded()");
    }
}
