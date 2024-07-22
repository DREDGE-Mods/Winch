using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Data.Abilities;

/// <summary>
/// The base class for all custom abilities
/// </summary>
public class ModdedAbilityData : AbilityData
{
    /// <summary>
    /// ID of this ability
    /// </summary>
    public string id = string.Empty;

    /// <summary>
    /// Should this ability be unlocked by default
    /// </summary>
    public bool autoUnlock = true;

    /// <summary>
    /// IDs of item datas linked to this ability
    /// </summary>
    public new List<string> linkedItems = new List<string>();

    private ModdedAbilityData() => base.linkedItems = new ItemData[0];

    internal void Populate()
    {
        if (linkedItems != null)
        {
            List<ItemData> items = new List<ItemData>();
            foreach (var item in linkedItems)
            {
                if (!string.IsNullOrWhiteSpace(item) && ItemUtil.AllItemDataDict.TryGetValue(item, out var itemData))
                {
                    items.Add(itemData);
                }
            }
            base.linkedItems = items.ToArray();
        }
    }
}