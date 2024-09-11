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
        GameEvents.Instance.OnItemDestroyed -= OnItemDestroyed;
    }

    private void OnGameEnded()
    {
        WinchCore.Log.Debug("[WinchBehaviour] OnGameEnded()");
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
        WinchCore.Log.Debug("[WinchBehaviour] OnGameUnloaded()");
    }

    private void OnItemDestroyed(SpatialItemData spatialItemData, bool playerDestroyed)
    {
        if ((spatialItemData is HarvestableItemData harvestableItemData && harvestableItemData.regenHarvestSpotOnDestroy) || spatialItemData is not HarvestableItemData)
        {
            StartCoroutine(FindAndRegenItemSpot(spatialItemData));
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
