using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Winch.Data;
using Winch.Data.GridConfig;
using Winch.Data.Item.Prerequisites;
using Winch.Data.POI.Dock;
using Winch.Data.POI.Dock.Destinations;
using Winch.Data.WorldEvent.Condition;
using Winch.Serialization.Vibration;
using Winch.Util;

namespace Winch.Serialization;

public static class DredgeTypeHelpers
{
    public static TEnum GetEnumValue<TEnum>(object value) where TEnum : Enum
    {
        if (EnumUtil.TryParse<TEnum>(value.ToString(), true, out TEnum enumValue))
            return enumValue;
        else
            throw new InvalidOperationException($"{value} is not a valid value of type {typeof(TEnum)}!\nValid values are [{string.Join(", ", EnumUtil.GetNames<TEnum>())}]");
    }

    public static List<TEnum> GetEnumValues<TEnum>(object value) where TEnum : Enum
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

    public static TEnum ParseFlagsEnum<TEnum>(object value) where TEnum : Enum
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

    public static TEnum GetFlagsFromEnumArray<TEnum>(TEnum[] array) where TEnum : Enum
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
        var meta = cellGroupConfiguration.ToObject<Dictionary<string, object>>();
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
        var meta = condition.ToObject<Dictionary<string, object>>();
        var net = bool.Parse(meta?.GetValueOrDefault("net", "false").ToString());
        var type = GetEnumValue<InventoryConditionType>(meta.GetValueOrDefault("type"));
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
            var position = dockSlot["position"];
            var rotation = dockSlot["rotation"];
            parsed.Add(new DockSlot
            {
                position = position != null ? ParseVector3(position) : Vector3.zero,
                rotation = rotation != null ? ParseVector3(rotation) : Vector3.zero,
            });
        }
        return parsed;
    }

    public static DockPOICollider ParseDockCollider(JToken o)
    {
        var colliderType = o["colliderType"];
        var center = o["center"];
        var radius = o["radius"];
        var size = o["size"];
        return new DockPOICollider
        {
            colliderType = colliderType != null ? GetEnumValue<ColliderType>(colliderType) : ColliderType.SPHERE,
            center = center != null ? ParseVector3(center) : Vector3.zero,
            radius = radius != null ? float.Parse(radius.ToString()) : 3.54f,
            size = size != null ? ParseVector3(size) : new Vector3(5, 2, 5),
        };
    }

    public static CustomStorageDestination ParsePrebuiltStorageDestination(JToken o)
    {
        if (o.IsNullOrEmpty()) return new CustomStorageDestination();

        var enabled = o["enabled"];
        var position = o["position"];
        var yRotation = o["yRotation"];
        var vCam = o["vCam"];
        var hasOverflow = o["hasOverflow"];
        var overflowHeight = o["overflowHeight"];
        var hasBoxes = o["hasBoxes"];
        return new CustomStorageDestination
        {
            enabled = enabled != null ? bool.Parse(enabled.ToString()) : true,
            position = position != null ? ParseVector3(position) : new Vector3(1.65f, 0.55f, -0.45f),
            yRotation = yRotation != null ? float.Parse(yRotation.ToString()) : 0,
            vCam = vCam != null ? ParseVector3(vCam) : new Vector3(4.5f, 3.45f, 6.75f),
            hasOverflow = hasOverflow != null ? bool.Parse(hasOverflow.ToString()) : false,
            overflowHeight = overflowHeight != null ? float.Parse(overflowHeight.ToString()) : 0.6f,
            hasBoxes = hasBoxes != null ? bool.Parse(hasBoxes.ToString()) : true,
        };
    }

    public static DockSanityModifier ParseDockSanityModifier(JToken o)
    {
        if (o.IsNullOrEmpty()) return new DockSanityModifier();

        var position = o["position"];
        var fullValueDay = o["fullValueDay"];
        var fullValueNight = o["fullValueNight"];
        var fullValueRadius = o["fullValueRadius"];
        var partialValueMinDay = o["partialValueMinDay"];
        var partialValueMinNight = o["partialValueMinNight"];
        var partialValueRadius = o["partialValueRadius"];
        var ignoreTimescale = o["ignoreTimescale"];
        return new DockSanityModifier
        {
            position = position != null ? ParseVector3(position) : Vector3.zero,
            fullValueDay = fullValueDay != null ? float.Parse(fullValueDay.ToString()) : 0,
            fullValueNight = fullValueNight != null ? float.Parse(fullValueNight.ToString()) : 1,
            fullValueRadius = fullValueRadius != null ? float.Parse(fullValueRadius.ToString()) : 3,
            partialValueMinDay = partialValueMinDay != null ? float.Parse(partialValueMinDay.ToString()) : 0,
            partialValueMinNight = partialValueMinNight != null ? float.Parse(partialValueMinNight.ToString()) : 0,
            partialValueRadius = partialValueRadius != null ? float.Parse(partialValueRadius.ToString()) : 6,
            ignoreTimescale = ignoreTimescale != null ? bool.Parse(ignoreTimescale.ToString()) : false,
        };
    }

    public static DockSafeZone ParseDockSafeZone(JToken o)
    {
        if (o.IsNullOrEmpty()) return new DockSafeZone();

        var position = o["position"];
        var radius = o["radius"];
        return new DockSafeZone
        {
            position = position != null ? ParseVector3(position) : Vector3.zero,
            radius = radius != null ? float.Parse(radius.ToString()) : 15f,
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

    public static AssetReferenceOverride ParseAssetReferenceOverride(JToken o)
    {
        if (o.IsNullOrEmpty()) return new AssetReferenceOverride();

        var assetReference = o["assetReference"];
        var nodesVisited = o["nodesVisited"];
        var boolValues = o["boolValues"];
        var tirWorldPhase = o["tirWorldPhase"];
        return new AssetReferenceOverride
        {
            assetReference = assetReference != null ? ParseAssetReference(assetReference.ToString()) : AddressablesUtil.EmptyAssetReference,
            nodesVisited = nodesVisited != null ? ParseStringList((JArray)nodesVisited) : new List<string>(),
            boolValues = boolValues != null ? ParseStringList((JArray)boolValues) : new List<string>(),
            tirWorldPhase = tirWorldPhase != null ? int.Parse(tirWorldPhase.ToString()) : 0,
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

    public static AssetReferenceOverride ParseAudioReferenceOverride(JToken o)
    {
        if (o.IsNullOrEmpty()) return new AssetReferenceOverride();

        var assetReference = o["assetReference"];
        var nodesVisited = o["nodesVisited"];
        var boolValues = o["boolValues"];
        var tirWorldPhase = o["tirWorldPhase"];
        return new AssetReferenceOverride
        {
            assetReference = assetReference != null ? ParseAudioReference(assetReference.ToString()) : AddressablesUtil.EmptyAssetReference,
            nodesVisited = nodesVisited != null ? ParseStringList((JArray)nodesVisited) : new List<string>(),
            boolValues = boolValues != null ? ParseStringList((JArray)boolValues) : new List<string>(),
            tirWorldPhase = tirWorldPhase != null ? int.Parse(tirWorldPhase.ToString()) : 0,
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
}
