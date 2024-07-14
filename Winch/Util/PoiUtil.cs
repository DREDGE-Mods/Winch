using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using HarmonyLib;
using UnityEngine;
using Winch.Core;
using Winch.Serialization;

using Winch.Serialization.POI;
using Winch.Serialization.POI.Conversation;
using Winch.Serialization.POI.Harvest;

namespace Winch.Util;

internal static class PoiUtil
{
    private static Dictionary<Type, IDredgeTypeConverter> Converters = new()
    {
        //{ typeof(POI), new PoiConverter() },
        //{ typeof(DockPOI), new DockPoiConverter() },
        //{ typeof(ItemPOI), new ItemPoiConverter() },
        //{ typeof(HarvestPOI), new HarvestPoiConverter() },
        //{ typeof(HarvestPOIDataModel), new HarvestPoiDataModelConverter() },
        //{ typeof(BaitHarvestPOI), new BaitPoiConverter() },
        //{ typeof(PlacedHarvestPOI), new PlacedPoiConverter() },
        //{ typeof(ConversationPOI), new ConversationPoiConverter() },
        //{ typeof(AutoMovePOI), new AutoMovePoiConverter() },
        //{ typeof(ConversationPOI), new ConversationPoiConverter() },
        //{ typeof(ExplosivePOI), new ExplosivePoiConverter() },
        { typeof(CustomHarvestPOI), new CustomHarvestPOIConverter()},
    };

    public static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters);
    }

    public static Dictionary<string, CustomPOI> ModdedPOIDict = new();
    public static Dictionary<string, IHarvestable> Harvestables = new();
    public static Dictionary<string, GameObject> HarvestParticlePrefabs = new();

    public static void PopulateHarvestablesAndHarvestParticlePrefabs()
    {
        foreach (var harvestPoi in GameManager.Instance.HarvestPOIManager.allHarvestPOIs)
        {
            try
            {
                if (!Harvestables.ContainsKey(harvestPoi.Harvestable.GetId()))
                    Harvestables.Add(harvestPoi.Harvestable.GetId(), harvestPoi.Harvestable);
                var prefab = harvestPoi.Harvestable.GetParticlePrefab();
                if (!HarvestParticlePrefabs.ContainsKey(prefab.name))
                {
                    HarvestParticlePrefabs.Add(prefab.name, prefab);
                    WinchCore.Log.Debug($"Added particle {prefab.name} to HarvestParticlePrefabs");
                }
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Unable to add harvestable {harvestPoi.Harvestable.GetId()} to Harvestables and HarvestParticlePrefabs: {ex}");
            }
        }
        foreach (var itemPoi in GameManager.Instance.HarvestPOIManager.allItemPOIs)
        {
            try
            {
                if (!Harvestables.ContainsKey(itemPoi.Harvestable.GetId()))
                    Harvestables.Add(itemPoi.Harvestable.GetId(), itemPoi.Harvestable);
                var prefab = itemPoi.Harvestable.GetParticlePrefab();
                if (!HarvestParticlePrefabs.ContainsKey(prefab.name))
                {
                    HarvestParticlePrefabs.Add(prefab.name, prefab);
                    WinchCore.Log.Debug($"Added particle {prefab.name} to HarvestParticlePrefabs");
                }
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Unable to add harvestable {itemPoi.Harvestable.GetId()} to Harvestables and HarvestParticlePrefabs: {ex}");
            }
        }
    }

    public static void ClearHarvestablesAndHarvestParticlePrefabs()
    {
        Harvestables.Clear();
        HarvestParticlePrefabs.Clear();
    }

    public static void CreateModdedPois()
    {
        foreach (var customPoi in ModdedPOIDict.Values)
        {
            CreateGameObjectFromCustomPoi(customPoi);
        }
    }

    public static GameObject? CreateGameObjectFromCustomPoi(CustomPOI customPoi)
    {
        if (customPoi is CustomHarvestPOI customHarvestPoi)
        {
            return CreateGameObjectFromCustomHarvestPoi(customHarvestPoi);
        }

        return null;
    }

    public static GameObject CreateGameObjectFromCustomHarvestPoi(CustomHarvestPOI customHarvestPoi)
    {
        GameObject customPoi = new GameObject();
        customPoi.transform.SetParent(GameSceneInitializer.Instance.HarvestPoiContainer.transform);
        customPoi.transform.position = customHarvestPoi.location;
        customPoi.name = customHarvestPoi.id;
        var harvestPoi = customPoi.AddComponent<HarvestPOI>();

        var harvestPoiDataModel = new HarvestPOIDataModel();
        harvestPoiDataModel.doesRestock = customHarvestPoi.doesRestock;
        harvestPoiDataModel.startStock = customHarvestPoi.startStock;
        harvestPoiDataModel.usesTimeSpecificStock = customHarvestPoi.useTimeSpecificStock;

        harvestPoiDataModel.items = customHarvestPoi.Items;
        harvestPoiDataModel.nightItems = customHarvestPoi.NightItems;

        harvestPoiDataModel.id = customHarvestPoi.id;

        harvestPoi.HarvestPOIData = harvestPoiDataModel;
        harvestPoi.Harvestable = harvestPoiDataModel;

        harvestPoi.harvestParticlePrefab = customHarvestPoi.HarvestableParticlePrefab;

        // Default Harvest POI Sphere Collider
        var sphereCollider = customPoi.AddComponent<SphereCollider>();
        sphereCollider.radius = 2;
        sphereCollider.enabled = true;
        sphereCollider.contactOffset = 0.01f;

        harvestPoi.poiCollider = sphereCollider;

        // This needs to be added to the GameManager.Instance.CullingBrain
        var cullable = customPoi.AddComponent<Cullable>();
        GameManager.Instance.CullingBrain.AddCullable(cullable);

        // No setup needed
        customPoi.AddComponent<SimpleBuoyantObject>();

        GameManager.Instance.HarvestPOIManager.allHarvestPOIs.Add(harvestPoi);

        customPoi.layer = LayerMask.NameToLayer("POI");
        return customPoi;
    }

    internal static void AddCustomPoiFromMeta<T>(string metaPath) where T : CustomPOI
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var poi = UtilHelpers.GetScriptableObjectFromMeta<T>(meta, metaPath);
        if (poi == null)
        {
            WinchCore.Log.Error($"Couldn't create {typeof(T).FullName}");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedPOIDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate poi {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateObjectFromMetaWithConverters<T>(poi, meta))
        {
            ModdedPOIDict.Add(id, poi);
        }
        else
        {
            WinchCore.Log.Error($"No POI converter found for type {typeof(T)}");
        }
    }

}
