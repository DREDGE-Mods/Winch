﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Winch.Core;
using Winch.Serialization;
// ReSharper disable HeapView.PossibleBoxingAllocation

namespace Winch.Util;

public static class UtilHelpers
{
    public static Dictionary<string, object>? ParseMeta(string metaPath)
    {
        try
        {
            string metaFile = File.ReadAllText(metaPath);
            Dictionary<string, object>? meta = JsonConvert.DeserializeObject<Dictionary<string, object>>(metaFile);
            return meta;
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Unable to read meta file {metaPath}: {ex.Message}");
        }
        
        return null;
    }

    public static T GetScriptableObjectFromMeta<T>(Dictionary<string, object> meta, string metaPath) where T : ScriptableObject
    {
        string id = Path.GetFileNameWithoutExtension(metaPath);
        meta["id"] = id;
        T item = ScriptableObject.CreateInstance<T>();
        if (item == null) return null;
        item.name = id;
        UnityEngine.Object.DontDestroyOnLoad(item);
        return item;
    }

    public static T GetScriptableObjectWithID<T>(string id) where T : ScriptableObject
    {
        T item = ScriptableObject.CreateInstance<T>();
        if (item == null) return null;
        item.name = id;
        return item;
    }

    public static bool PopulateObjectFromMeta<T>(T item, Dictionary<string, object> meta, Dictionary<Type, IDredgeTypeConverter> converters)
    {
        if (item == null) throw new ArgumentNullException($"{nameof(item)} is null");
        var itemType = typeof(T);
        if (converters.TryGetValue(itemType, out var converter))
        {
            PopulateObjectFromMeta(item, meta, converter);
        }
        else
        {
            WinchCore.Log.Error($"No converter found for type {itemType}");
            return false;
        }
        return true;
    }

    public static bool PopulateObjectFromMeta<T>(T item, Dictionary<string, object> meta, IDredgeTypeConverter converter)
    {
        if (item == null) throw new ArgumentNullException($"{nameof(item)} is null");
        converter.PopulateFields(item, meta);
        return true;
    }
}
