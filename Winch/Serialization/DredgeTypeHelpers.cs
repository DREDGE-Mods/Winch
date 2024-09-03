using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Data;
using Winch.Data.GridConfig;
using Winch.Data.Item.Prerequisites;
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
}
