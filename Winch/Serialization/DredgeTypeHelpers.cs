using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Winch.Data;
using Winch.Data.Character;
using Winch.Data.GridConfig;
using Winch.Data.Item.Prerequisites;
using Winch.Data.POI.Dock;
using Winch.Data.POI.Dock.Destinations;
using Winch.Data.Quest.Grid.Condition;
using Winch.Data.Shop;
using Winch.Data.WorldEvent.Condition;
using Winch.Serialization.Vibration;
using Winch.Serialization.WorldEvent.Condition;
using Winch.Util;
using static ShopData;

namespace Winch.Serialization;

public static class DredgeTypeHelpers
{
    public static TEnum GetEnumValue<TEnum>(object? value) where TEnum : struct, Enum
    {
        if (value == null)
            throw new InvalidOperationException($"Invalid value of type {typeof(TEnum)}!\nValid values are [{string.Join(", ", EnumUtil.GetNames<TEnum>())}]");

        if (EnumUtil.TryParse<TEnum>(value.ToString(), true, out TEnum enumValue))
            return enumValue;
        else
            throw new InvalidOperationException($"{value} is not a valid value of type {typeof(TEnum)}!\nValid values are [{string.Join(", ", EnumUtil.GetNames<TEnum>())}]");
    }

    public static List<TEnum> GetEnumValues<TEnum>(object value) where TEnum : struct, Enum
    {
        if (value is JArray values)
        {
            List<TEnum> types = new();
            foreach (object type in values)
            {
                types.Add(GetEnumValue<TEnum>(type));
            };
            return types;
        }
        else
            return new List<TEnum> { GetEnumValue<TEnum>(value) };
    }

    public static TEnum ParseFlagsEnum<TEnum>(object value) where TEnum : struct, Enum
    {
        if (value is JArray values)
        {
            List<TEnum> types = new();
            foreach (object type in values)
            {
                types.Add(GetEnumValue<TEnum>(type));
            };
            return GetFlagsFromEnumArray(types.ToArray());
        }
        else
            return GetEnumValue<TEnum>(value);
    }

    public static TEnum GetFlagsFromEnumArray<TEnum>(TEnum[] array) where TEnum : struct, Enum
    {
        TEnum merged = default(TEnum);
        if (array != null)
        {
            var or = Operator<TEnum>.Or;
            foreach (var value in array)
            {
                merged = or(merged, value);
            }
        }
        return (TEnum)(object)merged;
    }

    private static class Operator<T>
    {
        public static readonly Func<T, T, T> Or;

        static Operator()
        {
            var dn = new DynamicMethod("or", typeof(T),
                new[] { typeof(T), typeof(T) }, typeof(DredgeTypeHelpers));
            var il = dn.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Or);
            il.Emit(OpCodes.Ret);
            Or = (Func<T, T, T>)dn.CreateDelegate(typeof(Func<T, T, T>));
        }

    }

    public static List<string> ParseStringList(JArray jArray)
    {
        var list = new List<string>();
        foreach (var item in jArray)
        {
            list.Add(item.ToString());
        }
        return list;
    }

    public static List<int> ParseIntList(JArray jArray)
    {
        var list = new List<int>();
        foreach (var num in jArray)
        {
            list.Add(int.Parse(num.ToString()));
        }
        return list;
    }

    public static Color GetColorFromJsonObject(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse color.");
        return GetColorFromJsonDictionary(jsonDict);
    }

    private static Color GetColorFromJsonDictionary(Dictionary<string, int> color)
    {
        int r = 0, g = 0, b = 0, a = 255;
        if (color.TryGetValue("r", out var value0)) r = value0;
        if (color.TryGetValue("g", out var value1)) g = value1;
        if (color.TryGetValue("b", out var value2)) b = value2;
        if (color.TryGetValue("a", out var value3)) a = value3;
        return new Color(r/255f, g/255f, b/255f, a/255f);
    }

    public static Vector3 ParseVector3(object inVal)
    {
        var position = JsonConvert.DeserializeObject<Dictionary<string, float>>(inVal.ToString()) ?? throw new InvalidOperationException("Unable to parse position.");
        float x=0, y=0, z=0;
        if (position.TryGetValue("x", out var value1)) x = value1;
        if (position.TryGetValue("y", out var value2)) y = value2;
        if (position.TryGetValue("z", out var value3)) z = value3;

        return new Vector3(x, y, z);
    }

    public static List<Vector3> ParseVector3Array(JArray vector3s)
    {
        var parsed = new List<Vector3>();
        foreach (var vector3 in vector3s)
        {
            parsed.Add(ParseVector3(vector3));
        }
        return parsed;
    }

    public static List<Vector2Int> ParseDimensions(JArray dimensions)
    {
        var parsed = new List<Vector2Int>();
        for (int y = 0; y < dimensions.Count; y++)
        {
            string line = dimensions[y].ToString();
            for (int x = 0; x < line.Length; x++)
            {
                char pos = line[x];
                if (pos != ' ')
                    parsed.Add(new Vector2Int(x, y));
            }
        }

        return parsed;
    }

    public static List<Vector2Int> ParseItemDimensions(JArray dimensions)
    {
        var parsed = ParseDimensions(dimensions);

        if (!parsed.Contains(new Vector2Int(0, 0)))
        {
            throw new InvalidOperationException("Failed to create item. Dimensions require the upper-left cell to be filled.");
        }

        return parsed;
    }

    public static Vector2 ParseVector2(object inVal)
    {
        var position = JsonConvert.DeserializeObject<Dictionary<string, float>>(inVal.ToString()) ?? throw new InvalidOperationException("Unable to parse position.");
        float x = 0, y = 0;
        if (position.TryGetValue("x", out var value1)) x = value1;
        if (position.TryGetValue("y", out var value2)) y = value2;

        return new Vector2(x, y);
    }

    public static HarvestableType[] ParseHarvestableTypes(JArray values)
    {
        List<HarvestableType> types = new();
        foreach (object type in values)
        {
            types.Add(DredgeTypeHelpers.GetEnumValue<HarvestableType>(type));
        };
        return types.ToArray();
    }

    public static CellGroupConfiguration ParseCellGroupConfiguration(JToken cellGroupConfiguration)
    {
        var config = new UnstructedCellGroupConfiguration();
        var meta = cellGroupConfiguration.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        GridConfigUtil.PopulateCellGroupConfigFromMetaWithConverter(config, meta);
        return config;
    }

    public static List<CellGroupConfiguration> ParseCellGroupConfigurations(JArray cellGroupConfigurations)
    {
        var parsed = new List<CellGroupConfiguration>();

        foreach (var cellGroupConfiguration in cellGroupConfigurations)
        {
            parsed.Add(ParseCellGroupConfiguration(cellGroupConfiguration));
        }

        return parsed;
    }

    public static Dictionary<TKey,TValue> ParseDictionary<TKey, TValue>(object inVal, Func<object, TKey> keyParser, Func<object, TValue> valueParser)
    {
        var parsed = new Dictionary<TKey, TValue>();

        var dictionary = JsonConvert.DeserializeObject<Dictionary<object, object>>(inVal.ToString()) ?? throw new InvalidOperationException("Unable to parse dictionary.");
        foreach (var kvp in dictionary)
        {
            parsed.Add(keyParser(kvp.Key), valueParser(kvp.Value));
        }

        return parsed;
    }

    internal static InventoryCondition ParseInventoryCondition(JToken condition)
    {
        var meta = condition.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        var net = bool.Parse(meta.GetValueOrDefault("net", "false").ToString());
        var type = GetEnumValue<InventoryConditionType>(meta.GetValueOrDefault("type", string.Empty).ToString());
        switch (type)
        {
            case InventoryConditionType.AnyOfItem:
            default:
                InventoryCondition acondition = net ? new AnyOfItemNetCondition() : new AnyOfItemCondition();
                UtilHelpers.PopulateObjectFromMeta(acondition, meta, new AnyOfItemConditionConverter());
                return acondition;
            case InventoryConditionType.NumOfItem:
                InventoryCondition ncondition = net ? new NumOfItemNetCondition() : new NumOfItemCondition();
                UtilHelpers.PopulateObjectFromMeta(ncondition, meta, new NumOfItemConditionConverter());
                return ncondition;
            case InventoryConditionType.NumItemsOfType:
                InventoryCondition ntcondition = net ? new NumItemsOfTypeNetCondition() : new NumItemsOfTypeCondition();
                UtilHelpers.PopulateObjectFromMeta(ntcondition, meta, new NumItemsOfTypeConditionConverter());
                return ntcondition;
            case InventoryConditionType.NumItemsOfSizeAndType:
                InventoryCondition nstcondition = net ? new NumItemsOfSizeAndTypeNetCondition() : new NumItemsOfSizeAndTypeCondition();
                UtilHelpers.PopulateObjectFromMeta(nstcondition, meta, new NumItemsOfSizeAndTypeConditionConverter());
                return nstcondition;
        }
    }

    internal static List<InventoryCondition> ParseInventoryConditions(JArray conditions)
    {
        var parsed = new List<InventoryCondition>();
        foreach (var condition in conditions)
        {
            parsed.Add(ParseInventoryCondition(condition));
        }
        return parsed;
    }

    internal static List<OwnedItemResearchablePrerequisite> ParseOwnedItemResearchablePrerequisites(JArray prerequisites)
    {
        var parsed = new List<OwnedItemResearchablePrerequisite>();
        foreach (var prerequisite in ParseStringList(prerequisites))
        {
            parsed.Add(ParseOwnedPrerequisite(prerequisite));
        }
        return parsed;
    }

    internal static OwnedItemResearchablePrerequisite ParseOwnedPrerequisite(string prerequisite)
    {
        return new ModdedOwnedItemResearchablePrerequisite
        {
            itemId = prerequisite
        };
    }

    internal static List<ResearchedItemResearchablePrerequisite> ParseResearchedItemResearchablePrerequisites(JArray prerequisites)
    {
        var parsed = new List<ResearchedItemResearchablePrerequisite>();
        foreach (var prerequisite in ParseStringList(prerequisites))
        {
            parsed.Add(ParseResearchedPrerequisite(prerequisite));
        }
        return parsed;
    }

    internal static ResearchedItemResearchablePrerequisite ParseResearchedPrerequisite(string prerequisite)
    {
        return new ModdedResearchedItemResearchablePrerequisite
        {
            itemId = prerequisite
        };
    }

    internal static List<VibrationParams> ParseVibrationParamsList(JArray o)
    {
        var parsed = new List<VibrationParams>();
        foreach (var vibrationParams in o)
        {
            var obj = vibrationParams.ToObject<CustomVibrationParams>();
            if (obj != null) parsed.Add(obj);
        }
        return parsed;
    }

    internal static List<DockSlot> ParseDockSlots(JArray o)
    {
        var parsed = new List<DockSlot>();
        foreach (var dockSlot in o)
        {
            var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(dockSlot.ToString()) ?? throw new InvalidOperationException("Unable to parse dock slot.");
            parsed.Add(new DockSlot
            {
                position = jsonDict.TryGetValue("position", out object position) ? ParseVector3(position) : Vector3.zero,
                rotation = jsonDict.TryGetValue("rotation", out object rotation) ? ParseVector3(rotation) : Vector3.zero
            });
        }
        return parsed;
    }

    public static DockPOICollider ParseDockCollider(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse dock POI collider.");
        return new DockPOICollider
        {
            colliderType = jsonDict.TryGetValue("colliderType", out object colliderType) ? GetEnumValue<ColliderType>(colliderType) : ColliderType.SPHERE,
            center = jsonDict.TryGetValue("center", out object center) ? ParseVector3(center) : Vector3.zero,
            radius = jsonDict.TryGetValue("radius", out object radius) ? float.Parse(radius.ToString()) : 3.54f,
            size = jsonDict.TryGetValue("size", out object size) ? ParseVector3(size) : new Vector3(5, 2, 5),
        };
    }

    public static CustomStorageDestination ParsePrebuiltStorageDestination(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse storage destination.");
        return new CustomStorageDestination
        {
            enabled = jsonDict.TryGetValue("enabled", out object enabled) ? bool.Parse(enabled.ToString()) : true,
            position = jsonDict.TryGetValue("position", out object position) ? ParseVector3(position) : new Vector3(1.65f, 0.55f, -0.45f),
            yRotation = jsonDict.TryGetValue("yRotation", out object yRotation) ? float.Parse(yRotation.ToString()) : 0,
            vCam = jsonDict.TryGetValue("vCam", out object vCam) ? ParseVector3(vCam) : new Vector3(4.5f, 3.45f, 6.75f),
            hasOverflow = jsonDict.TryGetValue("hasOverflow", out object hasOverflow) ? bool.Parse(hasOverflow.ToString()) : false,
            overflowHeight = jsonDict.TryGetValue("overflowHeight", out object overflowHeight) ? float.Parse(overflowHeight.ToString()) : 0.6f,
            isIndoors = jsonDict.TryGetValue("isIndoors", out object isIndoors) ? bool.Parse(isIndoors.ToString()) : false,
            hasChest = jsonDict.TryGetValue("hasChest", out object hasChest) ? bool.Parse(hasChest.ToString()) : true,
            hasBoxes = jsonDict.TryGetValue("hasBoxes", out object hasBoxes) ? bool.Parse(hasBoxes.ToString()) : true,
        };
    }

    public static DockSanityModifier ParseDockSanityModifier(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse dock sanity modifier.");
        return new DockSanityModifier
        {
            position = jsonDict.TryGetValue("position", out object position) ? ParseVector3(position) : Vector3.zero,
            fullValueDay = jsonDict.TryGetValue("fullValueDay", out object fullValueDay) ? float.Parse(fullValueDay.ToString()) : 0,
            fullValueNight = jsonDict.TryGetValue("fullValueNight", out object fullValueNight) ? float.Parse(fullValueNight.ToString()) : 1,
            fullValueRadius = jsonDict.TryGetValue("fullValueRadius", out object fullValueRadius) ? float.Parse(fullValueRadius.ToString()) : 3,
            partialValueMinDay = jsonDict.TryGetValue("partialValueMinDay", out object partialValueMinDay) ? float.Parse(partialValueMinDay.ToString()) : 0,
            partialValueMinNight = jsonDict.TryGetValue("partialValueMinNight", out object partialValueMinNight) ? float.Parse(partialValueMinNight.ToString()) : 0,
            partialValueRadius = jsonDict.TryGetValue("partialValueRadius", out object partialValueRadius) ? float.Parse(partialValueRadius.ToString()) : 6,
            ignoreTimescale = jsonDict.TryGetValue("ignoreTimescale", out object ignoreTimescale) ? bool.Parse(ignoreTimescale.ToString()) : false,
        };
    }

    public static DockSafeZone ParseDockSafeZone(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse dock safe zone.");
        return new DockSafeZone
        {
            position = jsonDict.TryGetValue("position", out object position) ? ParseVector3(position) : Vector3.zero,
            radius = jsonDict.TryGetValue("radius", out object radius) ? float.Parse(radius.ToString()) : 15f
        };
    }

    public static AssetReference ParseAssetReference(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return AddressablesUtil.EmptyAssetReference;

        if (Guid.TryParse(s, out _)) return new AssetReference(s);

        if (AddressablesUtil.TryGetAssetGUID(s, out string guid))
            return new AssetReference(guid);

        if (AddressablesUtil.TryGetIdenticalLocationKey(s, out string identical))
            return new AssetReference(identical);

        return AddressablesUtil.EmptyAssetReference;
    }

    public static List<AssetReference> ParseAssetReferences(JArray o)
    {
        var parsed = new List<AssetReference>();
        foreach (var s in ParseStringList(o))
        {
            parsed.Add(ParseAssetReference(s));
        }
        return parsed;
    }

    public static AssetReferenceT<TObject> ParseAssetReference<TObject>(string s) where TObject : UnityEngine.Object
    {
        if (string.IsNullOrWhiteSpace(s)) return new AssetReferenceT<TObject>(string.Empty);

        if (Guid.TryParse(s, out _)) return new AssetReferenceT<TObject>(s);

        if (AddressablesUtil.TryGetAssetGUID(s, out string guid))
            return new AssetReferenceT<TObject>(guid);

        if (AddressablesUtil.TryGetIdenticalLocationKey<TObject>(s, out string identical))
            return new AssetReferenceT<TObject>(identical);

        return new AssetReferenceT<TObject>(string.Empty);
    }

    public static List<AssetReference> ParseAssetReferences<TObject>(JArray o) where TObject : UnityEngine.Object
    {
        var parsed = new List<AssetReference>();
        foreach (var s in ParseStringList(o))
        {
            parsed.Add(ParseAssetReference<TObject>(s));
        }
        return parsed;
    }

    public static AssetReferenceOverride ParseAssetReferenceOverride(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse asset reference override.");
        return new AssetReferenceOverride
        {
            assetReference = jsonDict.TryGetValue("assetReference", out object assetReference) ? ParseAssetReference(assetReference.ToString()) : AddressablesUtil.EmptyAssetReference,
            nodesVisited = jsonDict.TryGetValue("nodesVisited", out object nodesVisited) ? ParseStringList((JArray)nodesVisited) : new List<string>(),
            boolValues = jsonDict.TryGetValue("boolValues", out object boolValues) ? ParseStringList((JArray)boolValues) : new List<string>(),
            tirWorldPhase = jsonDict.TryGetValue("tirWorldPhase", out object tirWorldPhase) ? int.Parse(tirWorldPhase.ToString()) : 0,
        };
    }

    public static List<AssetReferenceOverride> ParseAssetReferenceOverrides(JArray o)
    {
        var parsed = new List<AssetReferenceOverride>();
        foreach (var refOverride in o)
        {
            parsed.Add(ParseAssetReferenceOverride(refOverride));
        }
        return parsed;
    }

    public static AssetReference ParseAudioReference(string o)
    {
        return ParseAssetReference<AudioClip>(o);
    }

    public static List<AssetReference> ParseAudioReferences(JArray o)
    {
        var parsed = new List<AssetReference>();
        foreach (var s in ParseStringList(o))
        {
            parsed.Add(ParseAudioReference(s));
        }
        return parsed;
    }

    public static AssetReferenceOverride ParseAudioReferenceOverride(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse audio reference override.");
        return new AssetReferenceOverride
        {
            assetReference = jsonDict.TryGetValue("assetReference", out object assetReference) ? ParseAudioReference(assetReference.ToString()) : AddressablesUtil.EmptyAssetReference,
            nodesVisited = jsonDict.TryGetValue("nodesVisited", out object nodesVisited) ? ParseStringList((JArray)nodesVisited) : new List<string>(),
            boolValues = jsonDict.TryGetValue("boolValues", out object boolValues) ? ParseStringList((JArray)boolValues) : new List<string>(),
            tirWorldPhase = jsonDict.TryGetValue("tirWorldPhase", out object tirWorldPhase) ? int.Parse(tirWorldPhase.ToString()) : 0,
        };
    }

    public static List<AssetReferenceOverride> ParseAudioReferenceOverrides(JArray o)
    {
        var parsed = new List<AssetReferenceOverride>();
        foreach (var refOverride in o)
        {
            parsed.Add(ParseAudioReferenceOverride(refOverride));
        }
        return parsed;
    }

    private static MarketTabConfig ParseMarketTabConfig(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse market tab.");
        return new MarketTabConfig
        {
            gridKey = jsonDict.TryGetValue("gridKey", out object gridKey) ? GetEnumValue<GridKey>(gridKey) : GridKey.NONE,
            tabSprite = jsonDict.TryGetValue("tabSprite", out object tabSprite) ? TextureUtil.GetSprite(tabSprite.ToString()) : TextureUtil.GetSprite("EmptyIcon"),
            titleKey = jsonDict.TryGetValue("titleKey", out object titleKey) ? LocalizationUtil.CreateStringsReference(titleKey.ToString()) : LocalizationUtil.Empty,
            isUnlockedBasedOnDialogue = jsonDict.TryGetValue("isUnlockedBasedOnDialogue", out object isUnlockedBasedOnDialogue) ? bool.Parse(isUnlockedBasedOnDialogue.ToString()) : false,
            unlockDialogueNodes = jsonDict.TryGetValue("unlockDialogueNodes", out object unlockDialogueNodes) ? ParseStringList((JArray)unlockDialogueNodes) : new List<string>(),
        };
    }

    public static List<MarketTabConfig> ParseMarketTabConfigList(JArray o)
    {
        var parsed = new List<MarketTabConfig>();
        foreach (var marketTabConfig in o)
        {
            parsed.Add(ParseMarketTabConfig(marketTabConfig));
        }
        return parsed;
    }

    public static Dictionary<string, SpeakerVCam> GetSpeakerVCamsFromJsonObject(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse speaker cameras.");
        return GetSpeakerVCamsDictionary(jsonDict);
    }

    private static Dictionary<string, SpeakerVCam> GetSpeakerVCamsDictionary(Dictionary<string, object> vcams)
    {
        var parsed = new Dictionary<string, SpeakerVCam>();
        foreach (var kvp in vcams)
        {
            parsed.Add(kvp.Key, ParseSpeakerVCam(kvp.Value));
        }
        return parsed;
    }

    private static SpeakerVCam ParseSpeakerVCam(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse speaker camera.");
        return new SpeakerVCam
        {
            position = jsonDict.TryGetValue("position", out object position) ? ParseVector3(position) : Vector3.zero,
            vCam = jsonDict.TryGetValue("vCam", out object vCam) ? ParseVector3(vCam) : Vector3.one,
            lookAtTarget = jsonDict.TryGetValue("lookAtTarget", out object lookAtTarget) ? ParseVector3(lookAtTarget) : Vector3.zero
        };
    }

    internal static List<AdvancedPortraitOverride> ParsePortraitOverrides(JArray o)
    {
        var parsed = new List<AdvancedPortraitOverride>();
        foreach (var portraitOverride in o)
        {
            parsed.Add(ParsePortraitOverride(portraitOverride));
        }
        return parsed;
    }

    private static AdvancedPortraitOverride ParsePortraitOverride(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse portrait override.");
        return new AdvancedPortraitOverride
        {
            portraitSprite = jsonDict.TryGetValue("portraitSprite", out object portraitSprite) ? TextureUtil.GetSprite(portraitSprite.ToString()) : TextureUtil.GetSprite("EmptyPortrait"),
            smallPortraitSprite = jsonDict.TryGetValue("smallPortraitSprite", out object smallPortraitSprite) ? TextureUtil.GetSprite(smallPortraitSprite.ToString()) : null,
            useManualState = jsonDict.TryGetValue("useManualState", out object useManualState) ? bool.Parse(useManualState.ToString()) : false,
            stateName = jsonDict.TryGetValue("stateName", out object stateName) ? stateName.ToString() : string.Empty,
            stateValue = jsonDict.TryGetValue("stateValue", out object stateValue) ? int.Parse(stateValue.ToString()) : 0,
            nodesVisited = jsonDict.TryGetValue("nodesVisited", out object nodesVisited) ? ParseStringList((JArray)nodesVisited) : new List<string>(),
        };
    }

    public static Dictionary<ParalinguisticType, List<AssetReference>> GetParalinguisticsFromJsonObject(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse paralinguistics.");
        return GetParalinguisticsDictionary(jsonDict);
    }

    private static Dictionary<ParalinguisticType, List<AssetReference>> GetParalinguisticsDictionary(Dictionary<string, object> paralinguistics)
    {
        var parsed = new Dictionary<ParalinguisticType, List<AssetReference>>();
        foreach (var kvp in paralinguistics)
        {
            parsed.Add(GetEnumValue<ParalinguisticType>(kvp.Key), ParseAudioReferences((JArray)kvp.Value));
        }
        return parsed;
    }

    internal static List<ParalinguisticOverride> ParseParalinguisticsOverrides(JArray o)
    {
        var parsed = new List<ParalinguisticOverride>();
        foreach (var portraitOverride in o)
        {
            parsed.Add(ParseParalinguisticOverride(portraitOverride));
        }
        return parsed;
    }

    private static ParalinguisticOverride ParseParalinguisticOverride(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse paralinguistic override.");
        var config = ScriptableObject.CreateInstance<SpeakerParalinguisticConfig>().DontDestroyOnLoad();
        config.paralinguistics = jsonDict.TryGetValue("paralinguistics", out object paralinguistics) ? GetParalinguisticsFromJsonObject(paralinguistics) : new Dictionary<ParalinguisticType, List<AssetReference>>();
        return new ParalinguisticOverride
        {
            config = config,
            nodesVisited = jsonDict.TryGetValue("nodesVisited", out object nodesVisited) ? ParseStringList((JArray)nodesVisited) : new List<string>(),
        };
    }

    internal static List<HighlightCondition> ParseHighlightConditions(JArray o)
    {
        var parsed = new List<HighlightCondition>();
        foreach (var highlightCondition in o)
        {
            parsed.Add(ParseHighlightCondition(highlightCondition));
        }
        return parsed;
    }

    private static HighlightCondition ParseHighlightCondition(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse highlight condition.");
        return new UnstructedHighlightCondition
        {
            alwaysHighlight = jsonDict.TryGetValue("alwaysHighlight", out object alwaysHighlight) ? bool.Parse(alwaysHighlight.ToString()) : false,
            highlightIfNodesUnvisited = jsonDict.TryGetValue("highlightIfNodesUnvisited", out object highlightIfNodesUnvisited) ? ParseStringList((JArray)highlightIfNodesUnvisited) : new List<string>(),
            andTheseNodesVisited = jsonDict.TryGetValue("andTheseNodesVisited", out object andTheseNodesVisited) ? ParseStringList((JArray)andTheseNodesVisited) : new List<string>(),
            // TODO: implement the other fields
        };
    }

    internal static List<NameKeyOverride> ParseNameKeyOverrides(JArray o)
    {
        var parsed = new List<NameKeyOverride>();
        foreach (var nameKeyOverride in o)
        {
            parsed.Add(ParseNameKeyOverride(nameKeyOverride));
        }
        return parsed;
    }

    private static NameKeyOverride ParseNameKeyOverride(object value)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString()) ?? throw new InvalidOperationException("Unable to parse name key override.");
        return new NameKeyOverride
        {
            speakerNameKey = jsonDict.TryGetValue("speakerNameKey", out object speakerNameKey) ? speakerNameKey.ToString() : string.Empty,
            nodesVisited = jsonDict.TryGetValue("nodesVisited", out object nodesVisited) ? ParseStringList((JArray)nodesVisited) : new List<string>(),
        };
    }

    public static CustomCharacterDestination ParseCharacterDestination(JToken destination)
    {
        var config = new CustomCharacterDestination();
        var meta = destination.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        DockUtil.PopulateDestinationFromMetaWithConverters(config, meta);
        return config;
    }

    public static List<CustomCharacterDestination> ParseCharacterDestinations(JArray destinations)
    {
        var parsed = new List<CustomCharacterDestination>();
        foreach (var destination in destinations)
        {
            parsed.Add(ParseCharacterDestination(destination));
        }
        return parsed;
    }

    public static CustomConstructableDestination ParseConstructableDestination(JToken destination)
    {
        var config = new CustomConstructableDestination();
        var meta = destination.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        DockUtil.PopulateDestinationFromMetaWithConverters(config, meta);
        return config;
    }

    public static List<CustomConstructableDestination> ParseConstructableDestinations(JArray destinations)
    {
        var parsed = new List<CustomConstructableDestination>();
        foreach (var destination in destinations)
        {
            parsed.Add(ParseConstructableDestination(destination));
        }
        return parsed;
    }

    public static CustomMarketDestination ParseMarketDestination(JToken destination)
    {
        var config = new CustomMarketDestination();
        var meta = destination.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        DockUtil.PopulateDestinationFromMetaWithConverters(config, meta);
        return config;
    }

    public static List<CustomMarketDestination> ParseMarketDestinations(JArray destinations)
    {
        var parsed = new List<CustomMarketDestination>();
        foreach (var destination in destinations)
        {
            parsed.Add(ParseMarketDestination(destination));
        }
        return parsed;
    }

    public static CustomShipyardDestination ParseShipyardDestination(JToken destination)
    {
        var config = new CustomShipyardDestination();
        var meta = destination.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        DockUtil.PopulateDestinationFromMetaWithConverters(config, meta);
        return config;
    }

    public static List<CustomShipyardDestination> ParseShipyardDestinations(JArray destinations)
    {
        var parsed = new List<CustomShipyardDestination>();
        foreach (var destination in destinations)
        {
            parsed.Add(ParseShipyardDestination(destination));
        }
        return parsed;
    }

    public static CustomUpgradeDestination ParseUpgradeDestination(JToken destination)
    {
        var config = new CustomUpgradeDestination();
        var meta = destination.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        DockUtil.PopulateDestinationFromMetaWithConverters(config, meta);
        return config;
    }

    public static List<CustomUpgradeDestination> ParseUpgradeDestinations(JArray destinations)
    {
        var parsed = new List<CustomUpgradeDestination>();
        foreach (var destination in destinations)
        {
            parsed.Add(ParseUpgradeDestination(destination));
        }
        return parsed;
    }

    public static ModdedShopItemData ParseShopItemData(JToken shopItemData)
    {
        var config = new ModdedShopItemData();
        var meta = shopItemData.Type == JTokenType.String
            ? new Dictionary<string, object> { { "itemData", shopItemData.ToString() } }
            : shopItemData.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        ShopUtil.PopulateShopItemDataFromMetaWithConverter(config, meta);
        return config;
    }

    internal static List<ShopItemData> ParseShopItemDataList(JArray o)
    {
        var parsed = new List<ShopItemData>();
        foreach (var shopItemData in o)
        {
            parsed.Add(ParseShopItemData(shopItemData));
        }
        return parsed;
    }

    public static PhaseLinkedShopData ParsePhaseLinkedShopData(JToken shopData)
    {
        var config = new PhaseLinkedShopData();
        var meta = shopData.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        ShopUtil.PopulatePhaseLinkedShopDataFromMetaWithConverter(config, meta);
        return config;
    }

    internal static List<PhaseLinkedShopData> ParsePhaseLinkedShopDataList(JArray o)
    {
        var parsed = new List<PhaseLinkedShopData>();
        foreach (var shopItemData in o)
        {
            parsed.Add(ParsePhaseLinkedShopData(shopItemData));
        }
        return parsed;
    }

    public static DialogueLinkedShopData ParseDialogueLinkedShopData(JToken shopData)
    {
        var config = new DialogueLinkedShopData();
        var meta = shopData.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        ShopUtil.PopulateDialogueLinkedShopDataFromMetaWithConverter(config, meta);
        return config;
    }

    internal static List<DialogueLinkedShopData> ParseDialogueLinkedShopDataList(JArray o)
    {
        var parsed = new List<DialogueLinkedShopData>();
        foreach (var shopItemData in o)
        {
            parsed.Add(ParseDialogueLinkedShopData(shopItemData));
        }
        return parsed;
    }

    internal static SerializableGrid ParseSerializableGrid(object value)
        => JsonConvert.DeserializeObject<SerializableGrid>(value.ToString())
        ?? throw new InvalidOperationException("Unable to parse grid.");

    internal static CompletedGridCondition ParseCompletedGridCondition(JToken condition)
    {
        var meta = condition.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        var type = GetEnumValue<CompletedGridConditionType>(meta.GetValueOrDefault("type", string.Empty).ToString());
        switch (type)
        {
            case CompletedGridConditionType.Full:
            default:
                return new FullCondition();
            case CompletedGridConditionType.Empty:
                return new EmptyCondition();
            case CompletedGridConditionType.ItemCount:
                DeferredItemCountCondition iccondition = new DeferredItemCountCondition();
                UtilHelpers.PopulateObjectFromMeta(iccondition, meta, new ItemCountConditionConverter());
                return iccondition;
            case CompletedGridConditionType.AberrationCount:
                AberrationCountCondition accondition = new AberrationCountCondition();
                UtilHelpers.PopulateObjectFromMeta(accondition, meta, new AberrationCountConditionConverter());
                return accondition;
            case CompletedGridConditionType.ExactCountOfItemTypeAndSubtype:
                ExactCountOfItemTypeAndSubtypeCondition eccondition = new ExactCountOfItemTypeAndSubtypeCondition();
                UtilHelpers.PopulateObjectFromMeta(eccondition, meta, new ExactCountOfItemTypeAndSubtypeConditionConverter());
                return eccondition;
            case CompletedGridConditionType.CellCountOfItemTypeAndSubtype:
                CellCountOfItemTypeAndSubtypeCondition cccondition = new CellCountOfItemTypeAndSubtypeCondition();
                UtilHelpers.PopulateObjectFromMeta(cccondition, meta, new CellCountOfItemTypeAndSubtypeConditionConverter());
                return cccondition;
        }
    }


    internal static List<CompletedGridCondition> ParseCompletedGridConditions(JArray o)
    {
        var parsed = new List<CompletedGridCondition>();
        foreach (var completedGridCondition in o)
        {
            parsed.Add(ParseCompletedGridCondition(completedGridCondition));
        }
        return parsed;
    }

    //TODO: implement
    internal static QuestStepCondition ParseQuestStepCondition(JToken questStepCondition) => throw new NotImplementedException();
    internal static List<QuestStepCondition> ParseQuestStepConditions(JArray o)
    {
        var parsed = new List<QuestStepCondition>();
        foreach (var questStepCondition in o)
        {
            parsed.Add(ParseQuestStepCondition(questStepCondition));
        }
        return parsed;
    }

    //TODO: implement
    internal static QuestStepEvent ParseQuestStepEvent(JToken questStepEvent) => throw new NotImplementedException();
    internal static List<QuestStepEvent> ParseQuestStepEvents(JArray o)
    {
        var parsed = new List<QuestStepEvent>();
        foreach (var questStepEvent in o)
        {
            parsed.Add(ParseQuestStepEvent(questStepEvent));
        }
        return parsed;
    }
}
