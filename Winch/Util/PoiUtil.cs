using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using Winch.Components;
using Winch.Core;
using Winch.Data.POI;
using Winch.Data.POI.Conversation;
using Winch.Data.POI.Dock;
using Winch.Data.POI.Harvest;
using Winch.Data.POI.Item;
using Winch.Serialization;
using Winch.Serialization.POI.Conversation;
using Winch.Serialization.POI.Dock;
using Winch.Serialization.POI.Harvest;
using Winch.Serialization.POI.Item;

namespace Winch.Util;

public static class PoiUtil
{
    private static Dictionary<Type, IDredgeTypeConverter> Converters = new()
    {
        { typeof(CustomDockPOI), new CustomDockPOIConverter() },
        { typeof(CustomAutoMovePOI), new CustomAutoMovePOIConverter() },
        { typeof(CustomInspectPOI), new CustomInspectPOIConverter() },
        { typeof(CustomExplosivePOI), new CustomExplosivePOIConverter() },
        { typeof(CustomHarvestPOI), new CustomHarvestPOIConverter()},
        { typeof(CustomItemPOI), new CustomItemPOIConverter()}
    };

    internal static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta) where T : CustomPOI
    {
        return UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters);
    }

    private static readonly int harvestAndItemPOIs = 1069;
    private static readonly string[] VanillaPOIs = new string[harvestAndItemPOIs + 1].Select((_,i) => i.ToString()).ToArray();

    internal static Dictionary<string, CustomPOI> ModdedPOIDict = new();
    internal static Dictionary<string, POI> CreatedModdedPOIDict = new();
    internal static Dictionary<string, POI> AllPOIDict = new();
    internal static Dictionary<string, IHarvestable> Harvestables = new();
    internal static Dictionary<string, GameObject> HarvestParticlePrefabs = new();
    internal static Dictionary<string, GameObject> ModdedHarvestParticlePrefabs = new();

    public static POI GetPOI(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllPOIDict.TryGetValue(id, out POI poi))
            return poi;

        if (CreatedModdedPOIDict.TryGetValue(id, out POI moddedPoi))
            return moddedPoi;

        return null;
    }

    public static CustomPOI GetModdedPOI(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedPOIDict.TryGetValue(id, out CustomPOI customPOI))
            return customPOI;
        else
            return null;
    }

    public static POI GetCreatedModdedPOI(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (CreatedModdedPOIDict.TryGetValue(id, out POI poi))
            return poi;
        else
            return null;
    }

    internal static GameObject InspectPoiContainer;
    internal static GameObject InspectionGlint;
    internal static VibrationData ExplodingWalls;
    internal static NoiseSettings _6DShake;

    internal static void Populate()
    {
        InspectPoiContainer = GameObject.FindObjectOfType<FinalePOIEnabler>().gameObject;
        if (InspectionGlint == null) InspectionGlint = Resources.FindObjectsOfTypeAll<ParticleSystemRenderer>().FirstOrDefault(psr => psr.name == "InspectionGlint").gameObject.CopyPrefab();
        if (ExplodingWalls == null) ExplodingWalls = Resources.FindObjectsOfTypeAll<VibrationData>().FirstOrDefault(vd => vd.name == "ExplodingWalls").DontDestroyOnLoad();
        if (_6DShake == null) _6DShake = Resources.FindObjectsOfTypeAll<NoiseSettings>().FirstOrDefault(vd => vd.name == "6D Shake").DontDestroyOnLoad();

        foreach (var harvestableParticle in Resources.FindObjectsOfTypeAll<HarvestableParticles>().Where(hp => !ModdedHarvestParticlePrefabs.Values.Contains(hp.gameObject)).Reverse())
        {
            var prefab = harvestableParticle.gameObject;
            var name = prefab.name.RemoveClone();
            if (!HarvestParticlePrefabs.ContainsKey(name))
            {
                prefab.name = name;
                HarvestParticlePrefabs.Add(name, prefab);
                WinchCore.Log.Debug($"Added particle {name} to HarvestParticlePrefabs");
            }
        }
        foreach (var dockPoi in Resources.FindObjectsOfTypeAll<DockPOI>())
        {
            AllPOIDict.Add(dockPoi.dock.Data.Id, dockPoi);
            WinchCore.Log.Debug($"Added POI {dockPoi.dock.Data.Id} to AllPOIDict");
        }
        foreach (var conversationPoi in Resources.FindObjectsOfTypeAll<ConversationPOI>())
        {
            var id = conversationPoi is ExplosivePOI explosivePoi ? explosivePoi.id : conversationPoi.name.Replace("_Inspect", "");
            AllPOIDict.Add(id, conversationPoi);
            WinchCore.Log.Debug($"Added POI {id} to AllPOIDict");
        }
        foreach (var harvestPoi in GameManager.Instance.HarvestPOIManager.allHarvestPOIs)
        {
            try
            {
                AllPOIDict.SafeAdd(harvestPoi.Harvestable.GetId(), harvestPoi);
                WinchCore.Log.Debug($"Added POI \"{harvestPoi.name}\" to AllPOIDict");
                Harvestables.SafeAdd(harvestPoi.Harvestable.GetId(), harvestPoi.Harvestable);
                var prefab = harvestPoi.Harvestable.GetParticlePrefab();
                var name = prefab.name.RemoveClone();
                if (!HarvestParticlePrefabs.ContainsKey(name))
                {
                    prefab.name = name;
                    HarvestParticlePrefabs.Add(name, prefab);
                    WinchCore.Log.Debug($"Added particle {name} to HarvestParticlePrefabs");
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
                AllPOIDict.SafeAdd(itemPoi.Harvestable.GetId(), itemPoi);
                WinchCore.Log.Debug($"Added POI \"{itemPoi.name}\" to AllPOIDict");
                Harvestables.SafeAdd(itemPoi.Harvestable.GetId(), itemPoi.Harvestable);
                var prefab = itemPoi.Harvestable.GetParticlePrefab();
                var name = prefab.name.RemoveClone();
                if (!HarvestParticlePrefabs.ContainsKey(name))
                {
                    prefab.name = name;
                    HarvestParticlePrefabs.Add(name, prefab);
                    WinchCore.Log.Debug($"Added particle {name} to HarvestParticlePrefabs");
                }
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Unable to add harvestable {itemPoi.Harvestable.GetId()} to Harvestables and HarvestParticlePrefabs: {ex}");
            }
        }
    }

    internal static void Clear()
    {
        CreatedModdedPOIDict.Clear();
        AllPOIDict.Clear();
        Harvestables.Clear();
        HarvestParticlePrefabs.Clear();
    }

    public static void AddModdedHarvestableParticlePrefab(string id, GameObject prefab)
    {
        if (string.IsNullOrWhiteSpace(id))
            return;

        if (!PoiUtil.ModdedHarvestParticlePrefabs.ContainsKey(id))
            PoiUtil.ModdedHarvestParticlePrefabs.Add(id, prefab.Prefabitize());
        else
            WinchCore.Log.Error($"Modded harvest particle prefab \"{id}\" already registered");
    }

    public static GameObject GetModdedHarvestableParticlePrefab(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (PoiUtil.ModdedHarvestParticlePrefabs.TryGetValue(id, out var moddedPrefab))
            return moddedPrefab;

        return null;
    }

    internal static GameObject GetHarvestableParticlePrefab(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (PoiUtil.HarvestParticlePrefabs.TryGetValue(id, out var prefab))
            return prefab;

        if (PoiUtil.ModdedHarvestParticlePrefabs.TryGetValue(id, out var moddedPrefab))
            return moddedPrefab;

        return null;
    }

    internal static void CreateModdedPois()
    {
        foreach (var customPoi in ModdedPOIDict.Values)
        {
            CreateGameObjectFromCustomPoi(customPoi);
        }
    }

    internal static GameObject? CreateGameObjectFromCustomPoi(CustomPOI customPoi)
    {
        if (customPoi is CustomHarvestPOI customHarvestPoi)
        {
            return CreateGameObjectFromCustomHarvestPoi(customHarvestPoi);
        }
        else if (customPoi is CustomItemPOI customItemPoi)
        {
            return CreateGameObjectFromCustomItemPoi(customItemPoi);
        }
        else if (customPoi is CustomConversationPOI customConversationPoi)
        {
            return CreateGameObjectFromCustomConversationPoi(customConversationPoi);
        }
        else if (customPoi is CustomDockPOI customDockPoi)
        {
            return CreateGameObjectFromCustomDockPoi(customDockPoi);
        }

        return null;
    }

    internal static GameObject? CreateGameObjectFromCustomConversationPoi(CustomConversationPOI customConversationPoi)
    {
        if (customConversationPoi is CustomInspectPOI customInspectPoi)
        {
            return CreateGameObjectFromCustomInspectPoi(customInspectPoi);
        }
        else if (customConversationPoi is CustomAutoMovePOI customAutoMovePoi)
        {
            return CreateGameObjectFromCustomAutoMovePoi(customAutoMovePoi);
        }
        else if (customConversationPoi is CustomExplosivePOI customExplosivePoi)
        {
            return CreateGameObjectFromCustomExplosivePoi(customExplosivePoi);
        }

        return null;
    }

    internal static GameObject CreateGameObjectFromCustomHarvestPoi(CustomHarvestPOI customHarvestPoi)
    {
        (GameObject customPoi, HarvestPOI harvestPoi) = CreateGenericPoiFromCustomPoi<HarvestPOI>(customHarvestPoi, GameSceneInitializer.Instance.HarvestPoiContainer.transform);

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
        Harvestables.Add(customHarvestPoi.id, harvestPoiDataModel);

        harvestPoi.HarvestPOIData = harvestPoiDataModel;
        harvestPoi.Harvestable = harvestPoiDataModel;

        harvestPoi.harvestParticlePrefab = customHarvestPoi.HarvestableParticlePrefab;

        // Default Harvest POI Sphere Collider
        var sphereCollider = customPoi.AddComponent<SphereCollider>();
        sphereCollider.radius = 2;
        sphereCollider.enabled = true;
        sphereCollider.contactOffset = 0.01f;

        harvestPoi.poiCollider = sphereCollider;

        if (customHarvestPoi.cullable)
        {
            // This needs to be added to the GameManager.Instance.CullingBrain
            var cullable = customPoi.AddComponent<Cullable>();
            cullable.cullingGroupType = CullingGroupType.STATIC_SHORT_RANGE;
            cullable.sphereRadius = 5;
            GameManager.Instance.CullingBrain.AddCullable(cullable);
        }

        // No setup needed
        customPoi.AddComponent<SimpleBuoyantObject>();

        GameManager.Instance.HarvestPOIManager.allHarvestPOIs.Add(harvestPoi);
        return customPoi;
    }

    internal static GameObject CreateGameObjectFromCustomItemPoi(CustomItemPOI customItemPoi)
    {
        (GameObject customPoi, ParticledItemPOI itemPoi) = CreateGenericPoiFromCustomPoi<ParticledItemPOI>(customItemPoi, GameSceneInitializer.Instance.HarvestPoiContainer.transform);

        var itemPoiDataModel = new ItemPOIDataModel();

        itemPoiDataModel.items = customItemPoi.Items;

        itemPoiDataModel.id = customItemPoi.id;
        Harvestables.Add(customItemPoi.id, itemPoiDataModel);

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

        if (customItemPoi.cullable)
        {
            // This needs to be added to the GameManager.Instance.CullingBrain
            var cullable = customPoi.AddComponent<Cullable>();
            cullable.cullingGroupType = CullingGroupType.STATIC_SHORT_RANGE;
            cullable.sphereRadius = 1;
            GameManager.Instance.CullingBrain.AddCullable(cullable);
        }

        var sfx = customPoi.AddComponent<IntermittentSFXPlayer>();
        sfx.assetReferences = customItemPoi.intermittentSFX;
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
        return customPoi;
    }

    internal static GameObject CreateGameObjectFromCustomInspectPoi(CustomInspectPOI customInspectPoi)
    {
        (GameObject customPoi, InspectPOI inspectPoi) = CreateGenericPoiFromCustomConversationPoi<InspectPOI>(customInspectPoi);

        return customPoi;
    }

    internal static GameObject CreateGameObjectFromCustomAutoMovePoi(CustomAutoMovePOI customAutoMovePoi)
    {
        (GameObject customPoi, ModdedAutoMovePOI autoMovePoi) = CreateGenericPoiFromCustomConversationPoi<ModdedAutoMovePOI>(customAutoMovePoi);

        var autoMoveDestination = new GameObject("AutoMoveDestination");
        autoMoveDestination.transform.SetParent(customPoi.transform);
        autoMoveDestination.transform.localPosition = customAutoMovePoi.autoMovePosition;
        autoMoveDestination.transform.localEulerAngles = customAutoMovePoi.autoMoveRotation;

        autoMovePoi.autoMoveDestination = autoMoveDestination.transform;
        autoMovePoi.includeRotation = customAutoMovePoi.includeRotation;
        autoMovePoi.unlockPlayerMovementAfterConversationCompleted = customAutoMovePoi.unlockPlayerMovementAfterConversationCompleted;

        return customPoi;
    }

    internal static GameObject CreateGameObjectFromCustomExplosivePoi(CustomExplosivePOI customExplosivePoi)
    {
        (GameObject customPoi, ExplosivePOI explosivePoi) = CreateGenericPoiFromCustomConversationPoi<ExplosivePOI>(customExplosivePoi, false, 2);

        explosivePoi.id = customExplosivePoi.id;
        explosivePoi.animator = customPoi.AddComponent<Animator>();
        explosivePoi.impulseSource = customPoi.AddComponent<CinemachineImpulseSource>();
        explosivePoi.impulseSource.m_ImpulseDefinition = new CinemachineImpulseDefinition();
        explosivePoi.impulseSource.m_ImpulseDefinition.m_AmplitudeGain = 5;
        explosivePoi.impulseSource.m_ImpulseDefinition.m_FrequencyGain = 5;
        explosivePoi.impulseSource.m_ImpulseDefinition.m_RawSignal = _6DShake;
        explosivePoi.ExplodeVibration = !string.IsNullOrWhiteSpace(customExplosivePoi.explodeVibration)
                ? VibrationUtil.GetVibrationData(customExplosivePoi.explodeVibration)
                : ExplodingWalls;

        var collider = (SphereCollider)explosivePoi.interactCollider;
        collider.radius = 7;
        explosivePoi.interactCollider = null;
        explosivePoi.canBeGhostWindTarget = false;

        return customPoi;
    }

    internal static (GameObject, T) CreateGenericPoiFromCustomConversationPoi<T>(CustomConversationPOI customConversationPoi, bool isCullable = true, float glintHeight = 1) where T : ConversationPOI
    {
        (GameObject customPoi, T poi) = CreateGenericPoiFromCustomPoi<T>(customConversationPoi, InspectPoiContainer.transform);

        poi.isOneTimeOnly = customConversationPoi.isOneTimeOnly;
        poi.releaseCameraOnComplete = customConversationPoi.releaseCameraOnComplete;
        poi.conversationNodeName = customConversationPoi.conversationNodeName;
        poi.enabledByOtherNodeVisit = customConversationPoi.enabledByOtherNodeVisit;
        poi.enableNodeNames = customConversationPoi.enableNodeNames;
        poi.shouldDisableOnOtherNodeVisit = customConversationPoi.shouldDisableOnOtherNodeVisit;
        poi.otherNodeNames = customConversationPoi.otherNodeNames;

        var glint = InspectionGlint.Instantiate(customPoi.transform, false);
        glint.transform.localPosition = new Vector3(0, glintHeight, 0);

        var vcamObject = new GameObject("InspectPOI_VCam");
        vcamObject.transform.SetParent(customPoi.transform);
        vcamObject.transform.localPosition = customConversationPoi.vCam;
        vcamObject.SetActive(false);
        var vcam = vcamObject.AddComponent<CinemachineVirtualCamera>();
        vcam.LookAt = customPoi.transform;
        vcam.AddExtension(vcamObject.AddComponent<CinemachineCollider>());
        vcam.AddExtension(vcamObject.AddComponent<CinemachineImpulseListener>());
        vcam.AddCinemachineComponent<CinemachineComposer>();
        vcamObject.AddComponent<CameraShakeSettingResponder>();
        poi.vCam = vcam;

        // Default Harvest POI Sphere Collider
        var sphereCollider = customPoi.AddComponent<SphereCollider>();
        sphereCollider.radius = 5;
        sphereCollider.enabled = true;
        sphereCollider.contactOffset = 0.01f;

        poi.interactCollider = sphereCollider;

        if (isCullable)
        {
            // This needs to be added to the GameManager.Instance.CullingBrain
            var cullable = customPoi.AddComponent<Cullable>();
            cullable.cullingGroupType = CullingGroupType.STATIC_SHORT_RANGE;
            cullable.sphereRadius = 15;
            GameManager.Instance.CullingBrain.AddCullable(cullable);
        }

        return (customPoi, poi);
    }

    internal static GameObject CreateGameObjectFromCustomDockPoi(CustomDockPOI customDockPoi)
    {
        return DockUtil.CreateDock(customDockPoi).gameObject;
    }

    internal static (GameObject, T) CreateGenericPoiFromCustomPoi<T>(CustomPOI customPoi, Transform parent) where T : POI
    {
        GameObject customPoiObject = new GameObject(customPoi.id);
        customPoiObject.transform.SetParent(parent);
        customPoiObject.transform.position = customPoi.location;
        var poi = customPoiObject.AddComponent<T>();
        CreatedModdedPOIDict.Add(customPoi.id, poi);
        WinchCore.Log.Debug($"Added POI {customPoi.id} to CreatedModdedPOIDict");

        poi.canBeGhostWindTarget = customPoi.canBeGhostWindTarget;

        if (customPoi.ghostWindTarget != Vector3.zero)
        {
            GameObject ghostWindTarget = new GameObject("GhostWindTarget");
            ghostWindTarget.transform.SetParent(customPoiObject.transform);
            ghostWindTarget.transform.localPosition = customPoi.ghostWindTarget;
            poi.ghostWindTargetTransform = ghostWindTarget.transform;
        }

        if (customPoi.interactPointTarget != Vector3.zero)
        {
            GameObject interactPointTarget = new GameObject("InteractionUITransform");
            interactPointTarget.transform.SetParent(customPoiObject.transform);
            interactPointTarget.transform.localPosition = customPoi.interactPointTarget;
            poi.interactPointTargetTransform = interactPointTarget.transform;
        }

        if (!string.IsNullOrWhiteSpace(customPoi.mapMarkerData))
        {
            var mapMarkerLocation = customPoiObject.AddComponent<MapMarkerLocation>();
            mapMarkerLocation.mapMarkerData = MapMarkerUtil.GetMapMarkerData(customPoi.mapMarkerData);
            mapMarkerLocation.SetMapMarkerData();
        }

        customPoiObject.layer = Layer.POI;
        return (customPoiObject, poi);
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
        if (VanillaPOIs.Contains(id))
        {
            WinchCore.Log.Error($"POI {id} already exists in vanilla.");
            return;
        }
        if (ModdedPOIDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate POI {id} at {metaPath} failed to load");
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

    public static IReadOnlyDictionary<string, POI> GetAllPOI()
    {
        return AllPOIDict.Concat(CreatedModdedPOIDict).ToDictionary();
    }

    public static IHarvestable[] GetAllHarvestables()
    {
        return Harvestables.Values.ToArray();
    }

    public static GameObject[] GetAllHarvestParticlePrefabs()
    {
        return HarvestParticlePrefabs.Values.Concat(ModdedHarvestParticlePrefabs.Values).ToArray();
    }
}
