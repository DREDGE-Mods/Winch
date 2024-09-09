using System.Collections.Generic;
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
    /// IDs of advanced ability data linked to this ability
    /// </summary>
    public new string linkedAdvancedVersion = string.Empty;

    public new string primaryVibration = string.Empty;

    public new string secondaryVibration = string.Empty;

    /// <summary>
    /// IDs of item datas linked to this ability
    /// </summary>
    public new List<string> linkedItems = new List<string>();

    private ModdedAbilityData() => base.linkedItems = new ItemData[0];

    internal void Populate()
    {
        if (!string.IsNullOrWhiteSpace(linkedAdvancedVersion))
        {
            base.linkedAdvancedVersion = AbilityUtil.GetAbilityData(linkedAdvancedVersion);
        }
        if (!string.IsNullOrWhiteSpace(primaryVibration))
        {
            base.primaryVibration = VibrationUtil.GetVibrationData(primaryVibration);
        }
        if (!string.IsNullOrWhiteSpace(secondaryVibration))
        {
            base.secondaryVibration = VibrationUtil.GetVibrationData(secondaryVibration);
        }
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
