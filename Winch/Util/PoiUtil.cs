using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using Winch.Core;
using Winch.Serialization;

using Winch.Serialization.POI;
using Winch.Serialization.POI.Conversation;
using Winch.Serialization.POI.Harvest;
using Winch.Serialization.POI.Item;

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
        { typeof(CustomItemPOI), new CustomItemPOIConverter()}
    };

    public static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta) where T : CustomPOI
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
        else if (customPoi is CustomItemPOI customItemPoi)
        {
            return CreateGameObjectFromCustomItemPoi(customItemPoi);
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
        harvestPoiDataModel.maxStock = customHarvestPoi.maxStock;
        harvestPoiDataModel.doesRestock = customHarvestPoi.doesRestock;
        harvestPoiDataModel.usesTimeSpecificStock = customHarvestPoi.usesTimeSpecificStock;
        harvestPoiDataModel.overrideDefaultDaySpecialChance = customHarvestPoi.overrideDefaultDaySpecialChance;
        harvestPoiDataModel.overriddenDaytimeSpecialChance = customHarvestPoi.overriddenDaytimeSpecialChance;
        harvestPoiDataModel.overrideDefaultNightSpecialChance = customHarvestPoi.overrideDefaultNightSpecialChance;
        harvestPoiDataModel.overriddenNighttimeSpecialChance = customHarvestPoi.overriddenNighttimeSpecialChance;

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
        cullable.sphereRadius = 5;
        GameManager.Instance.CullingBrain.AddCullable(cullable);

        // No setup needed
        customPoi.AddComponent<SimpleBuoyantObject>();

        GameManager.Instance.HarvestPOIManager.allHarvestPOIs.Add(harvestPoi);

        customPoi.layer = Layer.POI;
        return customPoi;
    }

    public static GameObject CreateGameObjectFromCustomItemPoi(CustomItemPOI customItemPoi)
    {
        GameObject customPoi = new GameObject();
        customPoi.transform.SetParent(GameSceneInitializer.Instance.HarvestPoiContainer.transform);
        customPoi.transform.position = customItemPoi.location;
        customPoi.name = customItemPoi.id;
        var itemPoi = customPoi.AddComponent<ParticledItemPOI>();

        var itemPoiDataModel = new ItemPOIDataModel();

        itemPoiDataModel.items = customItemPoi.Items;

        itemPoiDataModel.id = customItemPoi.id;

        itemPoi.itemPOIData = itemPoiDataModel;
        itemPoi.Harvestable = itemPoiDataModel;

        itemPoi.harvestParticlePrefab = customItemPoi.HarvestableParticlePrefab;

        // Default Harvest POI Sphere Collider
        var sphereCollider = customPoi.AddComponent<SphereCollider>();
        sphereCollider.radius = 2;
        sphereCollider.enabled = true;
        sphereCollider.contactOffset = 0.01f;

        itemPoi.poiCollider = sphereCollider;

        // No setup needed
        customPoi.AddComponent<SimpleBuoyantObject>();

        // This needs to be added to the GameManager.Instance.CullingBrain
        var cullable = customPoi.AddComponent<Cullable>();
        cullable.sphereRadius = 1;
        GameManager.Instance.CullingBrain.AddCullable(cullable);

        var sfx = customPoi.AddComponent<IntermittentSFXPlayer>();
        sfx.assetReferences = new List<AssetReference>();
        sfx.audioMixerGroup = Resources.FindObjectsOfTypeAll<AudioMixerGroup>().FirstOrDefault(amg => amg.name == "WorldSFX");
        sfx.audioRolloffMode = AudioRolloffMode.Linear;
        sfx.volumeScale = 1;
        sfx.minDelaySec = 3;
        sfx.maxDelaySec = 5;
        sfx.minDistance = 5;
        sfx.maxDistance = 50;
        sfx.affectedByDebugCommand = true;
        itemPoi.intermittentSFXPlayer = sfx;

        GameManager.Instance.HarvestPOIManager.allItemPOIs.Add(itemPoi);

        customPoi.layer = Layer.POI;
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
