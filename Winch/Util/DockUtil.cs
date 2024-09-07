using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using Winch.Core;
using Winch.Data;
using Winch.Data.Dock;
using Winch.Data.POI.Dock;
using Winch.Serialization.Dock;
using static Winch.Data.POI.Dock.CustomDockPOI;
using UnityEngine.SceneManagement;
using Winch.Components;
using Cinemachine;
using UnityEngine.AddressableAssets;

namespace Winch.Util;

public static class DockUtil
{
    internal static AssetBundle DockPrefabsBundle = AssetBundleUtil.GetBundle("docks.bundle");
    internal static Dictionary<DockPrefab, GameObject> DockPrefabs = new Dictionary<DockPrefab, GameObject>
    {
        { DockPrefab.GENERIC, DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/GenericDock.prefab") },
        { DockPrefab.LARGE, DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/LargeGenericDock.prefab") },
        { DockPrefab.MAKESHIFT, DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/MakeshiftDock.prefab") },
        { DockPrefab.STONE, DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/StoneDock.prefab") },
        { DockPrefab.PLAIN_STONE, DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/PlainStoneDock.prefab") },
        { DockPrefab.ROCK, DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/RockDock.prefab") },
    };
    internal static Dictionary<DockPrefab, DockPOICollider> DockPrefabColliders = new Dictionary<DockPrefab, DockPOICollider>
    {
        { DockPrefab.MAKESHIFT, new DockPOICollider { colliderType = ColliderType.BOX, center = new Vector3(0,0,-1), size = new Vector3(5,2,3) } },
    };
    internal static Dictionary<DockPrefab, Vector3> DockPrefabLookAtTargets = new Dictionary<DockPrefab, Vector3>
    {
        { DockPrefab.GENERIC, new Vector3(-1,1,0) },
        { DockPrefab.LARGE, new Vector3(-2f,0,0) },
        { DockPrefab.MAKESHIFT, new Vector3(1,1.5f,-0.3f) },
        { DockPrefab.STONE, new Vector3(-1,1,0) },
        { DockPrefab.PLAIN_STONE, new Vector3(1,1.5f,-0.3f) },
        { DockPrefab.ROCK, new Vector3(-0.7217255f,2.75f,-0.8538818f) },
    };
    internal static Dictionary<DockPrefab, Vector3> DockPrefabVCams = new Dictionary<DockPrefab, Vector3>
    {
        { DockPrefab.GENERIC, new Vector3(10,3.4f,-4.9f) },
        { DockPrefab.LARGE, new Vector3(18.57f,6.59f,6.04f) },
        { DockPrefab.MAKESHIFT, new Vector3(9.45f,4.6f,-8.1f) },
        { DockPrefab.STONE, new Vector3(8.5f,5,-9.5f) },
        { DockPrefab.PLAIN_STONE, new Vector3(10.125f,4.59f,-8.1f) },
        { DockPrefab.ROCK, new Vector3(8, 3.25f, -7) },
    };
    internal static Dictionary<DockPrefab, Vector3> DockPrefabPOIOffsets = new Dictionary<DockPrefab, Vector3>
    {
        { DockPrefab.GENERIC, new Vector3(1.43f,0,0) },
        { DockPrefab.LARGE, new Vector3(0,0,0) },
        { DockPrefab.MAKESHIFT, new Vector3(2, 0, 0) },
        { DockPrefab.STONE, new Vector3(0.5f,0,0) },
        { DockPrefab.PLAIN_STONE, new Vector3(2, 0, 0) },
        { DockPrefab.ROCK, new Vector3(0,0,0) },
    };
    internal static Dictionary<DockPrefab, Vector3> DockPrefabBoatActions = new Dictionary<DockPrefab, Vector3>
    {
        { DockPrefab.GENERIC, new Vector3(3.03f,1.6f,0) },
        { DockPrefab.LARGE, new Vector3(0.4f,1.14f,-0.08f) },
        { DockPrefab.MAKESHIFT, new Vector3(1.55f,2.05f,0.14f) },
        { DockPrefab.STONE, new Vector3(1,2.51f,-0.111f) },
        { DockPrefab.PLAIN_STONE, new Vector3(2,2.05f,0) },
        { DockPrefab.ROCK, new Vector3(-1.5f,0,1.5f) },
    };
    internal static Dictionary<DockPrefab, List<DockSlot>> DockPrefabSlots = new Dictionary<DockPrefab, List<DockSlot>>
    {
        { DockPrefab.GENERIC, new List<DockSlot> {
            new DockSlot
            {
                position = new Vector3(3.03f,0,0),
                rotation = Vector3.zero
            },
            new DockSlot
            {
                position = new Vector3(1.13f,0,-2),
                rotation = new Vector3(0,-90,0)
            },
            new DockSlot
            {
                position = new Vector3(1.13f,0,2),
                rotation = new Vector3(0,-90,0)
            }
        } },
        { DockPrefab.LARGE, new List<DockSlot> {
            new DockSlot
            {
                position = new Vector3(2.5f,0,0),
                rotation = Vector3.zero
            },
            new DockSlot
            {
                position = new Vector3(-1,0,-2),
                rotation = new Vector3(0,-90,0)
            },
            new DockSlot
            {
                position = new Vector3(-1,0,2),
                rotation = new Vector3(0,-90,0)
            }
        } },
        { DockPrefab.MAKESHIFT, new List<DockSlot> {
            new DockSlot
            {
                position = new Vector3(4,0,0),
                rotation = Vector3.zero
            },
            new DockSlot
            {
                position = new Vector3(1,0,-2),
                rotation = new Vector3(0,-90,0)
            }
        } },
        { DockPrefab.STONE, new List<DockSlot> {
            new DockSlot
            {
                position = new Vector3(2.5f,0,0),
                rotation = Vector3.zero
            },
            new DockSlot
            {
                position = new Vector3(-1,0,-2),
                rotation = new Vector3(0,-90,0)
            },
            new DockSlot
            {
                position = new Vector3(-1,0,2),
                rotation = new Vector3(0,-90,0)
            }
        } },
        { DockPrefab.PLAIN_STONE, new List<DockSlot> {
            new DockSlot
            {
                position = new Vector3(4,0,0),
                rotation = Vector3.zero
            },
            new DockSlot
            {
                position = new Vector3(1,0,-2),
                rotation = new Vector3(0,-90,0)
            },
            new DockSlot
            {
                position = new Vector3(1,0,2),
                rotation = new Vector3(0,-90,0)
            }
        } },
        { DockPrefab.ROCK, new List<DockSlot> {
            new DockSlot
            {
                position = new Vector3(1.407684f,0,-0.1358032f),
                rotation = Vector3.zero
            }
        } },
    };
    internal static Dictionary<DockPrefab, PrebuiltStorageDestination> DockPrefabStorages = new Dictionary<DockPrefab, PrebuiltStorageDestination>
    {
        { DockPrefab.GENERIC, new PrebuiltStorageDestination {
            position = new Vector3(-1.65f,0.5f,-0.45f),
            vCam = new Vector3(4.5f,3.45f,6.75f),
            overflowHeight = 0.6f
        } },
        { DockPrefab.LARGE, new PrebuiltStorageDestination {
            position = new Vector3(-5.8f,0.68f,-7.1f),
            yRotation = 90,
            vCam = new Vector3(7.2f,3.72f,4.8f),
            overflowHeight = 0.6f
        } },
        { DockPrefab.MAKESHIFT, new PrebuiltStorageDestination {
            position = new Vector3(-1.925f,0.58f,-0.35f),
            vCam = new Vector3(0.75f,2,4.25f),
            overflowHeight = 0.7f
        } },
        { DockPrefab.STONE, new PrebuiltStorageDestination {
            position = new Vector3(-2.25f,0.575f,-0.3f),
            vCam = new Vector3(1.51f,2.63f,3.48f),
            overflowHeight = 0.65f
        } },
        { DockPrefab.PLAIN_STONE, new PrebuiltStorageDestination {
            position = new Vector3(-3,0.55f,-0.3f),
            vCam = new Vector3(4.5f,3.45f,6.75f),
            overflowHeight = 0.6f
        } },
        { DockPrefab.ROCK, new PrebuiltStorageDestination {
            position = new Vector3(-0.5625f,0.188f,-2.24f),
            vCam = new Vector3(0.56f,3.45f,6.75f),
            overflowHeight = 0.65f,
            hasBoxes = false
        } },
    };
    internal static GameObject StorageBox = DockPrefabsBundle.LoadAsset<GameObject>("Assets/DREDGE/Mods/Winch/Docks/GenericStorage.prefab");

    private static DockDataConverter DockDataConverter = new DockDataConverter();

    internal static bool PopulateDockDataFromMetaWithConverter(DeferredDockData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, DockDataConverter);
    }

    internal static Dictionary<string, DeferredDockData> DeferredDockDataDict = new();
    internal static Dictionary<string, DockData> AllDockDataDict = new();

    public static DeferredDockData GetDeferredDockData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (DeferredDockDataDict.TryGetValue(id, out DeferredDockData dockData))
            return dockData;
        else
            return null;
    }

    public static DockData GetDockData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllDockDataDict.TryGetValue(id, out var dock))
            return dock;

        if (DeferredDockDataDict.TryGetValue(id, out var moddedDock))
            return moddedDock;

        return null;
    }

    internal static void PopulateDockDatas()
    {
        foreach (var dockData in Resources.FindObjectsOfTypeAll<DockData>())
        {
            AllDockDataDict.Add(dockData.id, dockData);
            WinchCore.Log.Debug($"Added dock data \"{dockData.id}\" to AllDockDataDict");
        }
    }

    internal static void ClearDockDatas()
    {
        AllDockDataDict.Clear();
    }

    internal static void AddDockDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var dockData = UtilHelpers.GetScriptableObjectFromMeta<DeferredDockData>(meta, metaPath);
        if (dockData == null)
        {
            WinchCore.Log.Error($"Couldn't create DockData");
            return;
        }
        var id = (string)meta["id"];
        if (DeferredDockDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate dock data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateDockDataFromMetaWithConverter(dockData, meta))
        {
            DeferredDockDataDict.Add(id, dockData);
        }
        else
        {
            WinchCore.Log.Error($"No dock data converter found");
        }
    }

    public static DockData[] GetAllDockData()
    {
        return AllDockDataDict.Values.ToArray();
    }

    public static GameObject GetDockPrefab(DockPrefab prefab)
    {
        if (DockPrefabs.TryGetValue(prefab, out var dockPrefab))
            return dockPrefab;
        else
            throw new InvalidOperationException(prefab.ToString());
    }

    public static Transform Docks;
    public static HighlightConditionExtraData ResearchTutorial;
    public static HighlightConditionExtraData ResearchBottomlessLines;

    public static void Populate()
    {
        PopulateDockDatas();
        Docks = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault(go => go.name == "Docks").transform;
        var hceds = Resources.FindObjectsOfTypeAll<HighlightConditionExtraData>();
        ResearchTutorial = hceds.FirstOrDefault(hced => hced.name == "ResearchTutorial");
        ResearchBottomlessLines = hceds.FirstOrDefault(hced => hced.name == "ResearchBottomlessLines");

    }

    public static DockPOI CreateDock(CustomDockPOI customDockPoi)
    {
        var dockObject = new GameObject(customDockPoi.id);
        dockObject.transform.SetParent(Docks, false);
        dockObject.transform.position = customDockPoi.location;
        dockObject.transform.eulerAngles = customDockPoi.rotation;
        var dock = dockObject.AddComponent<ModdedDock>();
        dock.dockData = DockUtil.GetDockData(customDockPoi.dockData);

        // This needs to be added to the GameManager.Instance.CullingBrain
        var cullable = dockObject.AddComponent<Cullable>();
        cullable.cullingGroupType = CullingGroupType.STATIC_LONG_RANGE;
        cullable.sphereRadius = customDockPoi.prefab == DockPrefab.LARGE ? 12 : 5;
        cullable.sphereOffset = new Vector3(-2, 0, 0);
        if (customDockPoi.prefab == DockPrefab.MAKESHIFT || customDockPoi.prefab == DockPrefab.PLAIN_STONE)
            cullable.sphereOffset = new Vector3(-1, 0, 0);
        GameManager.Instance.CullingBrain.AddCullable(cullable);

        var dockContainer = new GameObject("Dock").transform;
        dockContainer.SetParent(dockObject.transform, false);

        (GameObject customPoi, DockPOI dockPoi) = PoiUtil.CreateGenericPoiFromCustomPoi<DockPOI>(customDockPoi, dockContainer);
        customPoi.name = "DockPOI";
        var poiOffset = customDockPoi.poiOffset ?? (DockPrefabPOIOffsets.ContainsKey(customDockPoi.prefab) ? DockPrefabPOIOffsets[customDockPoi.prefab] : new Vector3(2, 0, 0));
        customDockPoi.poiOffset = poiOffset;
        customPoi.transform.localPosition = poiOffset;
        dock.dockPOI = dockPoi;
        dockPoi.dock = dock;

        var colliderSettings = customDockPoi.collider ?? (DockPrefabColliders.ContainsKey(customDockPoi.prefab) ? DockPrefabColliders[customDockPoi.prefab] : new DockPOICollider());
        customDockPoi.collider = colliderSettings;
        if (colliderSettings.colliderType == ColliderType.SPHERE)
        {
            var sphereCollider = customPoi.AddComponent<SphereCollider>();
            sphereCollider.center = colliderSettings.center;
            sphereCollider.radius = colliderSettings.radius;
            sphereCollider.enabled = true;
            sphereCollider.contactOffset = 0.01f;
        }
        else if (colliderSettings.colliderType == ColliderType.BOX)
        {
            var boxCollider = customPoi.AddComponent<BoxCollider>();
            boxCollider.center = colliderSettings.center;
            boxCollider.size = colliderSettings.size;
            boxCollider.enabled = true;
            boxCollider.contactOffset = 0.01f;
        }

        var slots = customDockPoi.dockSlots ?? (DockPrefabSlots.ContainsKey(customDockPoi.prefab) ? DockPrefabSlots[customDockPoi.prefab] : DockPrefabSlots[DockPrefab.PLAIN_STONE]);
        customDockPoi.dockSlots = slots;
        List<Transform> dockSlots = new List<Transform>();
        var count = 1;
        foreach (var dockSlot in slots)
        {
            var dockSlotObj = new GameObject("DockSlot" + count++);
            dockSlotObj.transform.SetParent(dockContainer);
            dockSlotObj.transform.localPosition = dockSlot.position;
            dockSlotObj.transform.localEulerAngles = dockSlot.rotation;
            dockSlots.Add(dockSlotObj.transform);
        }
        dockPoi.dockSlots = dockSlots.ToArray();

        if (customDockPoi.prefab != DockPrefab.NONE)
        {
            GetDockPrefab(customDockPoi.prefab).Instantiate(dockContainer, false);
        }

        var boatContainer = new GameObject("Boat").transform;
        boatContainer.SetParent(dockObject.transform, false);
        var lookAtTargetPosition = customDockPoi.lookAtTarget ?? (DockPrefabLookAtTargets.ContainsKey(customDockPoi.prefab) ? DockPrefabLookAtTargets[customDockPoi.prefab] : new Vector3(1, 0, 0));
        customDockPoi.lookAtTarget = lookAtTargetPosition;
        var lookAtTarget = CreateLookAtTarget(lookAtTargetPosition, boatContainer.transform);
        var vCamPosition = customDockPoi.vCam ?? (DockPrefabVCams.ContainsKey(customDockPoi.prefab) ? DockPrefabVCams[customDockPoi.prefab] : new Vector3(10, 3.4f, -4.9f));
        customDockPoi.vCam = vCamPosition;
        var vCam = CreateDockVirtualCamera(vCamPosition, lookAtTarget, boatContainer.transform, priority: 12);
        dock.lookAtTarget = lookAtTarget;
        dock.dockVCam = vCam;
        var boatActions = customDockPoi.boatActions ?? (DockPrefabBoatActions.ContainsKey(customDockPoi.prefab) ? DockPrefabBoatActions[customDockPoi.prefab] : new Vector3(3.03f, 1.6f, 0));
        customDockPoi.boatActions = boatActions;
        dock.boatActionsDestination = CreateBoatActions(boatActions, vCam, boatContainer.transform);

        var prebuiltStorage = customDockPoi.storage ?? (DockPrefabStorages.ContainsKey(customDockPoi.prefab) ? DockPrefabStorages[customDockPoi.prefab] : new PrebuiltStorageDestination());
        customDockPoi.storage = prebuiltStorage;
        (StorageDestination storage, OverflowStorageDestination overflowStorage) = CreateStorage(prebuiltStorage, dockObject.transform);
        dock.storageDestination = storage;
        dock.overflowStorageDestination = overflowStorage;
        dock.storageEnabled = prebuiltStorage.enabled;
        dock.overflowStorageEnabled = prebuiltStorage.hasOverflow;

        dock.destinations = new List<BaseDestination>();

        dock.sanityModifier = CreateDockSanityModifier(customDockPoi.sanityModifier, dockObject.transform);
        dock.safeZone = CreateDockSafeZone(customDockPoi.safeZone, dockObject.transform);

        return dockPoi;
    }

    public static Transform CreateLookAtTarget(Vector3 position, Transform parent, string name = "LookAt")
    {
        var lookAt = new GameObject(name);
        lookAt.transform.SetParent(parent, false);
        lookAt.transform.localPosition = position;
        return lookAt.transform;
    }

    public static BoatActionsDestination CreateBoatActions(Vector3 position, CinemachineVirtualCamera vCam, Transform parent)
    {
        var boatActionsObject = new GameObject("BoatActions");
        boatActionsObject.transform.SetParent(parent, false);
        boatActionsObject.transform.localPosition = position;
        var boatActions = boatActionsObject.AddComponent<BoatActionsDestination>();
        var undock = boatActionsObject.AddComponent<UndockDestination>();
        undock.id = "destination.undock";
        undock.alwaysShow = true;
        undock.isIndoors = false;
        undock.vCam = vCam;
        undock.icon = TextureUtil.GetSprite("UndockIcon");
        undock.titleKey = LocalizationUtil.Empty;
        undock.playerInventoryTabIndexesToShow = new List<int>();
        undock.highlightConditions = new List<HighlightCondition>();
        undock.speakerRootNodeOverride = string.Empty;
        undock.visitSFX = new AssetReference();
        var rest = boatActionsObject.AddComponent<RestDestination>();
        rest.id = "destination.rest";
        rest.alwaysShow = false;
        rest.isIndoors = true;
        rest.vCam = vCam;
        rest.icon = TextureUtil.GetSprite("SleepIcon");
        rest.titleKey = LocalizationUtil.Empty;
        rest.playerInventoryTabIndexesToShow = new List<int>();
        rest.highlightConditions = new List<HighlightCondition>();
        rest.speakerRootNodeOverride = string.Empty;
        rest.visitSFX = new AssetReference();
        var research = boatActionsObject.AddComponent<ResearchDestination>();
        research.id = "destination.research";
        research.alwaysShow = false;
        research.isIndoors = true;
        research.vCam = vCam;
        research.icon = TextureUtil.GetSprite("CogIcon");
        research.titleKey = LocalizationUtil.Empty;
        research.playerInventoryTabIndexesToShow = new List<int>();
        research.highlightConditions = new List<HighlightCondition> {
            new UnstructedHighlightCondition { andTheseNodesVisited = new List<string> { "Mayor_Intro_2" }, extraConditions = ResearchTutorial },
            new UnstructedHighlightCondition { andTheseNodesVisited = new List<string> { "Researcher_GiveSamplingDevice_Accepted" }, extraConditions = ResearchBottomlessLines }
        };
        research.speakerRootNodeOverride = string.Empty;
        research.visitSFX = new AssetReference("71dc4bc352aee9449be4b295ad2f0a83"); // "Research - Visit" audio clip GUID
        boatActions.undockDestination = undock;
        boatActions.restDestination = rest;
        boatActions.researchDestination = research;
        return boatActions;
    }

    private static readonly Vector3 storageOffset = new Vector3(-0.1f, 0.32f, 0.3f);

    public static (StorageDestination, OverflowStorageDestination) CreateStorage(PrebuiltStorageDestination prebuilt, Transform parent)
    {
        var storageObject = new GameObject("Storage");
        storageObject.transform.SetParent(parent, false);
        storageObject.transform.localPosition = prebuilt.position;
        storageObject.transform.localEulerAngles = new Vector3(0, prebuilt.yRotation, 0);
        var lookAt = CreateLookAtTarget(storageOffset, storageObject.transform, "StorageLookAt");
        var vCam = CreateDockVirtualCamera(prebuilt.vCam, lookAt, storageObject.transform, "StorageVCam");
        var storageDestinationObject = new GameObject("StorageDestination");
        storageDestinationObject.transform.SetParent(storageObject.transform, false);
        storageDestinationObject.transform.localPosition = storageOffset;
        var visitSFX = new AssetReference("0bdaa49fd18583249be54b84e8da3f54"); // "Storage - Visit" audio clip GUID
        var storageDestination = storageDestinationObject.AddComponent<StorageDestination>();
        storageDestination.id = "destination.storage";
        storageDestination.vCam = vCam;
        storageDestination.icon = TextureUtil.GetSprite("StorageIcon");
        storageDestination.titleKey = LocalizationUtil.CreateReference("Strings", "title.storage");
        storageDestination.playerInventoryTabIndexesToShow = new List<int> { 0, 1, 2 };
        storageDestination.highlightConditions = new List<HighlightCondition>();
        storageDestination.speakerRootNodeOverride = string.Empty;
        storageDestination.visitSFX = visitSFX;
        var overflowStorageDestinationObject = new GameObject("OverflowStorageDestination");
        overflowStorageDestinationObject.transform.SetParent(storageDestinationObject.transform, false);
        overflowStorageDestinationObject.transform.localPosition = new Vector3(0, prebuilt.overflowHeight, 0);
        var overflowStorageDestination = overflowStorageDestinationObject.AddComponent<OverflowStorageDestination>();
        overflowStorageDestination.id = "destination.overflow-storage";
        overflowStorageDestination.vCam = vCam;
        overflowStorageDestination.icon = TextureUtil.GetSprite("StorageIcon");
        overflowStorageDestination.titleKey = LocalizationUtil.CreateReference("Strings", "title.overflow-storage");
        overflowStorageDestination.playerInventoryTabIndexesToShow = new List<int> { 1 };
        overflowStorageDestination.highlightConditions = new List<HighlightCondition> { new UnstructedHighlightCondition { alwaysHighlight = true } };
        overflowStorageDestination.speakerRootNodeOverride = string.Empty;
        overflowStorageDestination.visitSFX = visitSFX;
        var box = StorageBox.Instantiate(storageObject.transform, false);
        box.transform.localPosition = Vector3.zero;
        box.transform.localEulerAngles = new Vector3(0, 360, 0);
        box.transform.Find("StorageBox/StorageBoxes").gameObject.SetActive(prebuilt.hasBoxes);
        return (storageDestination, overflowStorageDestination);
    }

    public static SanityModifier CreateDockSanityModifier(DockSanityModifier dockSanityModifier, Transform parent)
    {
        var dockSanityModifierObject = new GameObject(nameof(DockSanityModifier));
        dockSanityModifierObject.transform.SetParent(parent, false);
        dockSanityModifierObject.transform.localPosition = dockSanityModifier.position;
        dockSanityModifierObject.layer = Layer.SanityModifier;

        var sanityModifier = dockSanityModifierObject.AddComponent<SanityModifier>();
        sanityModifier.fullValueDay = dockSanityModifier.fullValueDay;
        sanityModifier.fullValueNight = dockSanityModifier.fullValueNight;
        sanityModifier.fullValueRadius = dockSanityModifier.fullValueRadius;
        sanityModifier.partialValueMinDay = dockSanityModifier.partialValueMinDay;
        sanityModifier.partialValueMinNight = dockSanityModifier.partialValueMinNight;
        sanityModifier.partialValueRadius = dockSanityModifier.partialValueRadius;
        sanityModifier.ignoreTimescale = dockSanityModifier.ignoreTimescale;

        var sphereCollider = dockSanityModifierObject.AddComponent<SphereCollider>();
        sphereCollider.radius = dockSanityModifier.partialValueRadius;

        return sanityModifier;
    }

    public static SphereCollider CreateDockSafeZone(DockSafeZone dockSafeZone, Transform parent)
    {
        var safeZone = GameObject.CreatePrimitive(PrimitiveType.Sphere).FixPrimitive(false);
        safeZone.name = nameof(Layer.SafeZone);
        safeZone.layer = Layer.SafeZone;
        safeZone.transform.SetParent(parent, false);
        safeZone.transform.localPosition = dockSafeZone.position;
        safeZone.transform.localScale = Vector3.one * dockSafeZone.radius;
        return safeZone.GetComponent<SphereCollider>();
    }

    public static CinemachineVirtualCamera CreateDockVirtualCamera(Vector3 position, Transform lookAt, Transform parent, string name = "VCam", int priority = 13)
    {
        var vcamObject = new GameObject(name);
        vcamObject.transform.SetParent(parent);
        vcamObject.transform.localPosition = position;
        var vcam = vcamObject.AddComponent<CinemachineVirtualCamera>();
        vcam.enabled = false;
        vcam.LookAt = lookAt;
        vcam.Priority = priority;
        vcam.m_Transitions = new CinemachineVirtualCameraBase.TransitionParams
        {
            m_BlendHint = CinemachineVirtualCameraBase.BlendHint.CylindricalPosition
        };
        vcam.AddCinemachineComponent<CinemachineComposer>();
        return vcam;
    }
}
