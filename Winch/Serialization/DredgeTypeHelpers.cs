using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Serialization.GridConfig;
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

    public static List<Vector2Int> ParseDimensions(JArray dimensions)
    {
        var parsed = new List<Vector2Int>();
        for(int y = 0; y < dimensions.Count; y++)
        {
            string line = dimensions[y].ToString();
            for(int x = 0; x < line.Length; x++)
            {
                char pos = line[x];
                if (pos != ' ')
                    parsed.Add(new Vector2Int(x, y));
            }
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
}
