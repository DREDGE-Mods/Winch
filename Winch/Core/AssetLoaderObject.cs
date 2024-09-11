using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Core;

internal class AssetLoaderObject : USingleton<AssetLoaderObject>
{
    protected override bool ShouldNotDestroyOnLoad => true;

    protected override void Awake()
    {
        base.Awake();
        WinchCore.Log.Debug("[AssetLoaderObject] Awake()");
        ApplicationEvents.Instance.OnTitleClosed += OnTitleClosed;
        ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
        ApplicationEvents.Instance.OnGameStartable += OnGameStartable;
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameEnded += OnGameEnded;
        ApplicationEvents.Instance.OnGameUnloaded += OnGameUnloaded;
    }

    private void OnDestroy()
    {
        WinchCore.Log.Debug("[AssetLoaderObject] OnDestroy()");
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
        GameEvents.Instance.OnItemDestroyed -= OnItemDestroyed;
    }

    private void OnGameEnded()
    {
        WinchCore.Log.Debug("[AssetLoaderObject] OnGameEnded()");
        GameEvents.Instance.OnItemDestroyed -= OnItemDestroyed;
        Clear();
    }

    private static void Clear()
    {
        VibrationUtil.ClearVibrationDatas();
        DockUtil.Clear();
        AbilityUtil.Clear();
        PoiUtil.Clear();
        HarvestZoneUtil.Clear();
        CharacterUtil.ClearSpeakerData();
    }

    private void OnGameUnloaded()
    {
        WinchCore.Log.Debug("[AssetLoaderObject] OnGameUnloaded()");
    }

    private void OnItemDestroyed(SpatialItemData spatialItemData, bool playerDestroyed)
    {
        if (spatialItemData is HarvestableItemData harvestableItemData && harvestableItemData.regenHarvestSpotOnDestroy)
        {
            StartCoroutine(FindAndRegenItemSpot(harvestableItemData));
        }
    }
    private IEnumerator FindAndRegenItemSpot(ItemData itemData)
    {
        List<ItemPOI> itemPOIs = (from itemPOI in UnityEngine.Object.FindObjectsOfType<ItemPOI>(includeInactive: true).ToList()
                                 where itemPOI.Harvestable.ContainsItem(itemData)
                                 select itemPOI).ToList();
        ItemPOI? targetPOI = itemPOIs.Reduce<ItemPOI, ItemPOI?>((targetPOI, p) => (targetPOI == null || (targetPOI != null && p.Stock < targetPOI.Stock)) ? p : targetPOI);
        if (targetPOI != null) targetPOI.AddStock();
        yield return null;
    }
}
