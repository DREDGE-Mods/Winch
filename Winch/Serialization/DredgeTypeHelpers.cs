﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Winch.Serialization;

public static class DredgeTypeHelpers
{
    public static TEnum GetEnumValue<TEnum>(object value) where TEnum : Enum
    {
        return (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
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
}
