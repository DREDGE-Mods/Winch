using Coffee.UIExtensions;
using HarmonyLib;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityAsyncAwaitUtil;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Winch.Components;
using Winch.Core;
using Winch.Data.Abilities;
using Winch.Data.Character;
using Winch.Data.Item;
using Winch.Data.WorldEvent;
using Winch.Util;
using static ActiveAbilityInfoPanel;

public static class WinchExtensions
{
    #region DREDGE
    /// <summary>
    /// Check if the object is modded
    /// </summary>
    /// <returns>Whether this object is modded or not</returns>
    public static bool IsModded(this ItemData item) => ItemUtil.ModdedItemDataDict.ContainsKey(item.id);
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this GridConfiguration gridConfiguration) => GridConfigUtil.ModdedGridConfigDict.ContainsKey(gridConfiguration.name);
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this SpeakerData speakerData) => speakerData is AdvancedSpeakerData;
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this Ability ability) => ability is ModdedAbility || ability.AbilityData.IsModded();
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this AbilityData ability) => ability is ModdedAbilityData;
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this WorldEvent worldEvent) => worldEvent is ModdedWorldEvent || worldEvent.worldEventData.IsModded();
    /// <inheritdoc cref="IsModded(ItemData)"/>
    public static bool IsModded(this WorldEventData worldEvent) => worldEvent is ModdedWorldEventData;

    /// <summary>
    /// Check if the object is vanilla
    /// </summary>
    /// <returns>Whether this object is vanilla or not</returns>
    public static bool IsVanilla(this ItemData item) => !item.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this GridConfiguration gridConfiguration) => !gridConfiguration.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this SpeakerData speakerData) => !speakerData.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this Ability ability) => !ability.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this AbilityData ability) => !ability.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this WorldEvent worldEvent) => !worldEvent.IsModded();
    /// <inheritdoc cref="IsVanilla(ItemData)"/>
    public static bool IsVanilla(this WorldEventData worldEvent) => !worldEvent.IsModded();

    /// <summary>
    /// Converts a spatial item instances to a spatial item data.
    /// </summary>
    public static SpatialItemData ToItemData(this SpatialItemInstance instance) => instance.GetItemData<SpatialItemData>();
    /// <summary>
    /// Converts a collection of spatial item instances to a collection of their spatial item datas.
    /// </summary>
    public static IEnumerable<SpatialItemData> ToItemData(this IEnumerable<SpatialItemInstance> instances) => instances.Select(ToItemData);

    /// <summary>
    /// Gets the number of cells this item data takes up.
    /// </summary>
    public static int GetNumberOfCells(this SpatialItemData itemData) => itemData.dimensions.Count;
    /// <summary>
    /// Gets the number of cells this item data takes up.
    /// </summary>
    public static int GetNumberOfCells(this SpatialItemInstance instance) => instance.ToItemData().GetNumberOfCells();
    /// <summary>
    /// Gets the number of cells these item datas take up.
    /// </summary>
    public static int GetNumberOfCells(this IEnumerable<SpatialItemData> itemDatas) => itemDatas.Aggregate(0, (int acc, SpatialItemData itemData) => acc + itemData.GetNumberOfCells());
    /// <summary>
    /// Gets the number of cells these item instances take up.
    /// </summary>
    public static int GetNumberOfCells(this IEnumerable<SpatialItemInstance> instances) => instances.ToItemData().GetNumberOfCells();

    /// <summary>
    /// Check whether this item's durability is 0
    /// </summary>
    public static bool IsBroken(this SpatialItemInstance instance) => instance.durability <= 0f;
    /// <summary>
    /// Check whether this is a <see cref="DurableItemData"/> and not thawable
    /// </summary>
    public static bool IsDurable(this SpatialItemData itemData) => itemData is DurableItemData && !itemData.IsThawable();
    /// <summary>
    /// Check whether this item data is a <see cref="DurableItemData"/> and not thawable
    /// </summary>
    public static bool IsDurable(this SpatialItemInstance instance) => instance.ToItemData().IsDurable();
    /// <summary>
    /// Check whether this item thawable (slows down rotting of fish in your inventory)
    /// </summary>
    public static bool IsThawable(this SpatialItemData itemData) => (itemData is DurableItemData && itemData.id.StartsWith("ice-block")) || itemData is ThawableItemData;
    /// <summary>
    /// Check whether this item thawable (slows down rotting of fish in your inventory)
    /// </summary>
    public static bool IsThawable(this SpatialItemInstance instance) => instance.ToItemData().IsThawable();

    /// <summary>
    /// Restocks the item point of interest to 1 (cannot go any higher)
    /// </summary>
    public static void AddStock(this ItemPOI itemPoi)
    {
        if (itemPoi.Stock == 0)
        {
            itemPoi.Harvestable.AddStock(1, false);
            itemPoi.OnStockUpdated();
        }
    }

    /// <summary>
    /// Retrieves the color currently selected for this enum by the player in their settings.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The player set color</returns>
    public static Color GetColor(this DredgeColorTypeEnum colorType) => GameManager.Instance.LanguageManager.GetColor(colorType);
    /// <summary>
    /// Retrieves the html color code currently selected for this enum by the player in their settings.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The player set color code</returns>
    public static string GetColorCode(this DredgeColorTypeEnum colorType) => GameManager.Instance.LanguageManager.GetColorCode(colorType);
    /// <summary>
    /// Returns the original default color for this enum from before any player customization.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The original color</returns>
    public static Color GetDefaultColor(this DredgeColorTypeEnum colorType) => GameManager.Instance.GameConfigData.Colors[(int)colorType];
    /// <summary>
    /// Returns the original default html color code for this enum from before any player customization.
    /// </summary>
    /// <param name="colorType">The color type</param>
    /// <returns>The original color code</returns>
    public static string GetDefaultColorCode(this DredgeColorTypeEnum colorType) => ColorUtility.ToHtmlStringRGB(GetDefaultColor(colorType));

    public static void AddColorType(this LanguageManager languageManager, DredgeColorTypeEnum colorType)
    {
        languageManager.colors.SafeAdd(colorType.GetDefaultColor());
        languageManager.colorCodes.SafeAdd(colorType.GetDefaultColorCode());
    }

    public static void ShowNotificationWithColor(this UIController UI, NotificationType notificationType, string key, string colorCode, object[] arguments)
    {
        LocalizationSettings.StringDatabase.GetLocalizedStringAsync(LanguageManager.STRING_TABLE, key, null, FallbackBehavior.UseProjectSettings, arguments).Completed += delegate (AsyncOperationHandle<string> op)
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                GameEvents.Instance.TriggerNotification(notificationType, string.Concat(new string[] { "<color=#", colorCode, ">", op.Result, "</color>" }));
            }
        };
    }

    public static void ShowMoneyNotification(this UIController UI, decimal value)
    {
        if (value < 0)
        {
            UI.ShowNotification(NotificationType.MONEY_LOST, "notification.funds-removed", new object[]
            {
                string.Concat(new string[]
                {
                    "<color=#",
                    GameManager.Instance.LanguageManager.GetColorCode(DredgeColorTypeEnum.NEGATIVE),
                    ">-$",
                    (-value).ToString("n2", LocalizationSettings.SelectedLocale.Formatter),
                    "</color>"
                })
            });
        }
        else
        {
            UI.ShowNotification(NotificationType.MONEY_GAINED, "notification.funds-added", new object[]
            {
                string.Concat(new string[]
                {
                    "<color=#",
                    GameManager.Instance.LanguageManager.GetColorCode(DredgeColorTypeEnum.POSITIVE),
                    ">$",
                    value.ToString("n2", LocalizationSettings.SelectedLocale.Formatter),
                    "</color>"
                })
            });
        }
    }

    public static void ShowNotificationWithItemName(this UIController UI, NotificationType notificationType, string notificationKey, LocalizedString itemNameKey, DredgeColorTypeEnum itemNameColor)
    {
        LocalizationSettings.StringDatabase.GetLocalizedStringAsync(itemNameKey.TableReference, itemNameKey.TableEntryReference, null, FallbackBehavior.UseProjectSettings, Array.Empty<object>()).Completed += delegate (AsyncOperationHandle<string> op)
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                GameManager.Instance.UI.ShowNotification(notificationType, notificationKey, new object[] { string.Concat(new string[]
                {
                    "<color=#",
                    GameManager.Instance.LanguageManager.GetColorCode(itemNameColor),
                    ">",
                    op.Result,
                    "</color>"
                }) });
            }
        };
    }

    public static Vector2 GetCurrentMapPivot(this MapWindow mapWindow)
    {
        return mapWindow.mapContents.pivot;
    }

    public static Vector2 GetMapPivotFromWorldPosition(this MapWindow mapWindow, Vector2 position)
    {
        Vector2 worldPositionAsMapPosition = mapWindow.GetMapPositionFromWorldPosition(position.x, position.y);
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromMapPosition(worldPositionAsMapPosition.x, worldPositionAsMapPosition.y);
        return mapPivotFromMapPosition;
    }

    public static Vector2 GetMapPivotFromWorldPosition(this MapWindow mapWindow, Vector3 position)
    {
        Vector2 worldPositionAsMapPosition = mapWindow.GetMapPositionFromWorldPosition(position.x, position.z);
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromMapPosition(worldPositionAsMapPosition.x, worldPositionAsMapPosition.y);
        return mapPivotFromMapPosition;
    }

    public static void CenterMapOnWorldPosition(this MapWindow mapWindow, Vector2 position)
    {
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromWorldPosition(position);
        mapWindow.MoveMapTo(mapPivotFromMapPosition.x, mapPivotFromMapPosition.y);
    }

    public static void CenterMapOnWorldPosition(this MapWindow mapWindow, Vector3 position)
    {
        Vector2 mapPivotFromMapPosition = mapWindow.GetMapPivotFromWorldPosition(position);
        mapWindow.MoveMapTo(mapPivotFromMapPosition.x, mapPivotFromMapPosition.y);
    }

    public static NetType GetNetTypeFromItemData(this DeployableItemData data)
    {
        if (data is TrawlNetItemData netData)
            return netData.netType;
        else if(data.id == "tir-net1")
            return NetType.SIPHON;
        else if (data.id == "tir-net2")
            return NetType.MATERIAL;
        else
            return NetType.REGULAR;
    }

    public static PotType GetPotTypeFromItemData(this DeployableItemData data)
    {
        if (data is CrabPotItemData potData)
            return potData.potType;
        else if (data.id == "tir-pot1")
            return PotType.MATERIAL;
        else
            return PotType.CRAB;
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromPotType(this GameSceneInitializer gameSceneInitializer, PotType type)
    {
        switch (type)
        {
            case PotType.MATERIAL:
                return gameSceneInitializer.placedMaterialPOIPrefab;
            case PotType.CRAB:
            default:
                return gameSceneInitializer.placedPOIPrefab;
        }
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromPotItemData(this GameSceneInitializer gameSceneInitializer, DeployableItemData data)
    {
        return gameSceneInitializer.GetPlacedHarvestPOIPrefabFromPotType(data.GetPotTypeFromItemData());
    }

    public static GameObject GetPlacedHarvestPOIPrefabFromPotItemData(this GameSceneInitializer gameSceneInitializer, string id)
    {
        return gameSceneInitializer.GetPlacedHarvestPOIPrefabFromPotItemData(GameManager.Instance.ItemManager.GetItemDataById<DeployableItemData>(id));
    }

    public static Sprite GetSpriteForAbilityMode(this ActiveAbilityInfoPanel activeAbilityInfoPanel, AbilityMode mode)
    {
        switch (mode)
        {
            case AbilityMode.POT:
                return activeAbilityInfoPanel.potQualityIcon;
            case AbilityMode.POT_MATERIAL:
                return activeAbilityInfoPanel.materialQualityIcon;
            case AbilityMode.BAIT:
                return activeAbilityInfoPanel.baitRegularQualityIcon;
            case AbilityMode.BAIT_ABERRATED:
                return activeAbilityInfoPanel.baitAberratedQualityIcon;
            case AbilityMode.BAIT_EXOTIC:
                return activeAbilityInfoPanel.baitExoticQualityIcon;
            case AbilityMode.BAIT_CRAB:
                return activeAbilityInfoPanel.baitCrabQualityIcon;
            case AbilityMode.TRAWL:
                return activeAbilityInfoPanel.trawlQualityIcon;
            case AbilityMode.TRAWL_OOZE:
                return activeAbilityInfoPanel.oozeQualityIcon;
            case AbilityMode.TRAWL_MATERIAL:
                return activeAbilityInfoPanel.materialQualityIcon;
            default:
                return TextureUtil.GetSprite(string.Join(string.Empty, mode.GetName().Split('_').Select(word => word.ToLowerInvariant().ToTitleCase())) + "QualityIcon");
        }
    }

    public static void PlaceTrawlItemAtGridPos(this TrawlNetAbility trawlNetAbility, HarvestableItemData harvestableItemData, Vector3Int gridPos)
    {
        if (harvestableItemData is FishItemData fishItemData)
        {
            FishSizeGenerationMode sizeGenerationMode = FishSizeGenerationMode.NO_BIG_TROPHY;
            float aberrationBonusMultiplier = 1f;
            if (!fishItemData.canBeCaughtByPot && !fishItemData.canBeCaughtByRod)
            {
                sizeGenerationMode = FishSizeGenerationMode.ANY;
                aberrationBonusMultiplier = 2f;
            }
            FishItemInstance fishItemInstance = GameManager.Instance.ItemManager.CreateFishItem(fishItemData.id, FishAberrationGenerationMode.RANDOM_CHANCE, false, sizeGenerationMode, aberrationBonusMultiplier);
            GameManager.Instance.SaveData.TrawlNet.AddObjectToGridData(fishItemInstance, gridPos, true, null);
            GameManager.Instance.ItemManager.SetItemSeen(fishItemInstance);
            GameEvents.Instance.TriggerFishCaught();
            GameManager.Instance.VibrationManager.Vibrate(trawlNetAbility.fishAddedVibrationData, VibrationRegion.WholeBody, true).Run();
        }
        else
        {
            SpatialItemInstance spatialItemInstance = GameManager.Instance.ItemManager.CreateItem<SpatialItemInstance>(harvestableItemData);
            GameManager.Instance.SaveData.TrawlNet.AddObjectToGridData(spatialItemInstance, gridPos, true, null);
            GameManager.Instance.ItemManager.SetItemSeen(spatialItemInstance);
            GameManager.Instance.VibrationManager.Vibrate(trawlNetAbility.materialAddedVibrationData, VibrationRegion.WholeBody, true).Run();
        }
    }

    public static int GetFilledCells(this SerializableGrid serializableGrid) => serializableGrid.GetFilledCells(ItemSubtype.ALL);
    public static float GetFillProportional(this SerializableGrid serializableGrid) => (float)serializableGrid.GetFilledCells() / (float)serializableGrid.GetCountNonHiddenCells();

    public static bool TryGetParalinguisticsFromNameKey(this IDictionary<string, SpeakerData> lookupTable, ParalinguisticsNameKey nameKey, out Dictionary<ParalinguisticType, List<AssetReference>> paralinguistics)
    {
        var stringNameKey = nameKey.ToString();
        switch (nameKey)
        {
            case ParalinguisticsNameKey.NONE:
                break;
            case ParalinguisticsNameKey.COLLECTOR_REVEALED:
                if (lookupTable.TryGetValue("COLLECTOR_NAME_KEY", out SpeakerData collectorData))
                {
                    paralinguistics = collectorData.paralinguisticOverrideConditions.First().config.paralinguistics;
                    return true;
                }
                break;
            case ParalinguisticsNameKey.HOODED_FIGURE:
                stringNameKey += "_1";
                goto default;
            case ParalinguisticsNameKey.SOUL:
                stringNameKey += "_MIDDLE";
                goto default;
            default:
                if (lookupTable.TryGetValue(stringNameKey + "_NAME_KEY", out SpeakerData data))
                {
                    paralinguistics = data.paralinguistics;
                    return true;
                }
                break;
        }
        paralinguistics = null;
        return false;
    }

    public static void DeactivateButtonEffects(this BasicButtonWrapper buttonWrapper)
    {
        buttonWrapper.transitionEffect.duration = 0;
        buttonWrapper.DoTransitionIn();
        buttonWrapper.GetComponent<UITransitionEffect>().enabled = false;
        buttonWrapper.GetComponent<Mask>().enabled = false;
    }
    #endregion

    #region Reflection
    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeFields" />
    public static FieldInfo[] GetRuntimeFieldsIncludingBase(this Type type)
    {
        Dictionary<string, FieldInfo> fields = new Dictionary<string, FieldInfo>();
        while (type != null)
        {
            foreach (var field in type.GetRuntimeFields())
            {
                fields.SafeAdd(field.Name, field);
            }
            type = type.BaseType;
        }
        return fields.Values.ToArray();
    }

    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeProperties" />
    public static PropertyInfo[] GetRuntimePropertiesIncludingBase(this Type type)
    {
        Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
        while (type != null)
        {
            foreach (var property in type.GetRuntimeProperties())
            {
                properties.SafeAdd(property.Name, property);
            }
            type = type.BaseType;
        }
        return properties.Values.ToArray();
    }

    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeMethods" />
    public static MethodInfo[] GetRuntimeMethodsIncludingBase(this Type type)
    {
        Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();
        while (type != null)
        {
            foreach (var method in type.GetRuntimeMethods())
            {
                methods.SafeAdd(method.Name, method);
            }
            type = type.BaseType;
        }
        return methods.Values.ToArray();
    }

    /// <inheritdoc cref="RuntimeReflectionExtensions.GetRuntimeEvents" />
    public static EventInfo[] GetRuntimeEventsIncludingBase(this Type type)
    {
        Dictionary<string, EventInfo> events = new Dictionary<string, EventInfo>();
        while (type != null)
        {
            foreach (var @event in type.GetRuntimeEvents())
            {
                events.SafeAdd(@event.Name, @event);
            }
            type = type.BaseType;
        }
        return events.Values.ToArray();
    }

    /// <summary>
    /// Gets the bytes for an embedded resource with the given name (found with endsWith), or null if no matches
    /// </summary>
    public static Stream? GetEmbeddedResource(this Assembly assembly, string endsWith)
    {
        var resource = Array.Find(assembly.GetManifestResourceNames(), s => s.EndsWith(endsWith));
        return resource != null ? assembly.GetManifestResourceStream(resource) : null;
    }

    /// <inheritdoc cref="GetEmbeddedResource" />
    public static bool TryGetEmbeddedResource(this Assembly assembly, string endsWith, out Stream? stream)
    {
        stream = GetEmbeddedResource(assembly, endsWith);
        return stream != null;
    }

    public static IEnumerable<Type> GetFilteredTypeList(this Type baseType) => UnityExtensions.GetFilteredTypeList(baseType);

    public static IEnumerable<Type> GetFilteredTypeList(this Assembly assembly, Type baseType)
    {
        return from type in assembly.GetTypes()
               where !type.IsAbstract
               where baseType.IsAssignableFrom(type)
               select type;
    }
    #endregion

    #region Stream
    /// <summary>
    /// Synchronously gets the full array of bytes from any stream, disposing with the Stream afterwards
    /// </summary>
    public static byte[]? GetByteArray(this Stream? stream)
    {
        if (stream == null)
        {
            return null;
        }

        try
        {
            using (stream)
            {
                if (stream is MemoryStream memoryStream)
                {
                    return memoryStream.ToArray();
                }

                using (memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region String
    public static string SplitCamelCase(this string s) => Regex.Replace(s, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2").Spaced();

    /// <summary>
    /// Puts spaces between capitalized words within a string. Accounts for acronyms like VR.
    /// </summary>
    /// <param name="s">The string to search for a match.</param>
    public static string Spaced(this string s) => Regex.Replace(s, @"(\p{Ll})(\P{Ll})", "$1 $2");

    /// <summary>
    /// Returns null if a string is empty / whitespace, otherwise just returns back the string
    /// </summary>
    public static string? NullIfEmpty(this string s) => string.IsNullOrWhiteSpace(s) ? null : s;

    /// <inheritdoc cref="Regex.Replace(string,string,string)" />
    public static string RegexReplace(this string input, string pattern, string replacement) =>
        Regex.Replace(input, pattern, replacement);

    public static bool TryMatch(this Regex regex, string input, out Match? match)
    {
        match = regex.Match(input);
        if (match.Success)
        {
            return true;
        }
        else
        {
            match = null;
            return false;
        }
    }
    #endregion

    #region Harmony
    public static CodeMatcher LogInstructions(this CodeMatcher matcher, string prefix)
    {
        matcher.InstructionEnumeration().LogInstructions(prefix + " at " + matcher.Pos);
        return matcher;
    }

    public static IEnumerable<CodeInstruction> LogInstructions(this IEnumerable<CodeInstruction> instructions, string prefix)
    {
        var message = prefix;
        int i = 0;
        foreach (var instruction in instructions)
            message += $"\n{i++} | {instruction}";
        WinchCore.Log.Error(message);
        return instructions;
    }
    #endregion

    #region Events
    /// <summary>
    /// Invokes each delegate, printing an error if an invocation fails. If an invocation fails, the other delegates will still be invoked.
    /// </summary>
    /// <param name="multicast">The MulticastDelegate to invoke.</param>
    /// <param name="args">The arguments to pass to each invocation.</param>
    public static void SafeInvoke(this MulticastDelegate multicast, params object[] args)
    {
        foreach (var del in multicast.GetInvocationList())
        {
            try
            {
                del.DynamicInvoke(args);
            }
            catch (TargetInvocationException ex)
            {
                WinchCore.Log.Error($"Error invoking delegate! {ex.InnerException}");
            }
        }
    }

    /// <summary>
    /// Raises an event in an instance by it's name.
    /// </summary>
    /// <typeparam name="T">The type of the instance.</typeparam>
    /// <param name="instance">The instance to raise the event in.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="args">The arguments to be passed to the event.</param>
    public static void RaiseEvent<T>(this T instance, string eventName, params object[] args)
    {
        const BindingFlags flags = BindingFlags.Instance
                                   | BindingFlags.Static
                                   | BindingFlags.Public
                                   | BindingFlags.NonPublic
                                   | BindingFlags.DeclaredOnly;
        if (typeof(T)
                .GetField(eventName, flags)?
                .GetValue(instance) is not MulticastDelegate multiDelegate)
        {
            return;
        }

        multiDelegate.SafeInvoke(args);
    }
    #endregion

    #region Collections
    /// <summary>
    /// Deconstruct a KeyValuePair
    /// </summary>
    public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> kvp, out T1 t1, out T2 t2)
    {
        t1 = kvp.Key;
        t2 = kvp.Value;
    }

    /// <summary>
    /// Add an item to an array
    /// </summary>
    /// <param name="array">The array to add to.</param>
    /// <param name="item">The item to add.</param>
    /// <returns>An array with <paramref name="item"/> added.</returns>
    public static T[] Add<T>(this T[] array, T item)
        => array.Concat(new T[] { item }).ToArray();

    /// <summary>
    /// Add items to an array
    /// </summary>
    /// <param name="array">The array to add to.</param>
    /// <param name="items">The items to add.</param>
    /// <returns>An array with <paramref name="items"/> added.</returns>
    public static T[] AddRange<T>(this T[] array, T[] items)
        => array.Concat(items).ToArray();

    /// <summary>
    /// Remove an item from an array
    /// </summary>
    /// <param name="array">The array to remove from.</param>
    /// <param name="item">The item to remove.</param>
    /// <returns>An array with <paramref name="item"/> removed.</returns>
    public static T[] Remove<T>(this T[] array, T item)
        => Remove(array, item, out bool _);

    /// <summary>
    /// Remove an item from an array
    /// </summary>
    /// <param name="array">The array to remove from.</param>
    /// <param name="item">The item to remove.</param>
    /// <param name="removed">Whether the item was removed or not.</param>
    /// <returns>An array with <paramref name="item"/> removed.</returns>
    public static T[] Remove<T>(this T[] array, T item, out bool removed)
    {
        var list = new List<T>(array);
        removed = list.Remove(item);
        return list.ToArray();
    }

    /// <summary>
    /// Retrieves all the elements that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="match"> The Predicate delegate that defines the conditions of the elements to search for.</param>
    /// <returns></returns>
    public static T[] FindAll<T>(this T[] array, Predicate<T> match) => Array.FindAll(array, match);

    /// <summary>Performs the specified action on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <param name="action">The <see cref="T:System.Action`1" /> delegate to perform on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="action" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.InvalidOperationException">An element in the collection has been modified.</exception>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (action == null) throw new ArgumentNullException("action");

        foreach (TSource item in source)
            action(item);
    }

    /// <summary>Performs the specified action on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <param name="action">The <see cref="T:System.Action`2" /> delegate to perform on each element of the <see cref="T:System.Collections.Generic.IEnumerable`1" />.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="action" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.InvalidOperationException">An element in the collection has been modified.</exception>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (action == null) throw new ArgumentNullException("action");

        int num = 0;
        foreach (TSource item in source)
            action(item, num++);
    }

    /// <summary>Searches for a sequence and returns the index of its first value that matches the condition.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to search.</param>
    /// <param name="predicate">The condition used to locate the index in <paramref name="source" />.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The zero-based index of the first value that matches the condition in the entire <paramref name="source" />, if found; otherwise, -1.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="predicate"/> is <see langword="null" />.</exception>
    public static int IndexOf<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (predicate == null) throw new ArgumentNullException("predicate");

        var index = 0;
        using IEnumerator<TSource> enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (predicate(enumerator.Current))
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    /// <summary>Filters a sequence of values by testing if they match a specified type.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type to filter and return.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that are the type <typeparamref name="TResult"/>.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static IEnumerable<TResult> WhereType<TSource, TResult>(this IEnumerable<TSource> source)
        => source.Where(item => item is TResult).Cast<TResult>();

    /// <summary>Filters a sequence of values by testing if they don't match a specified type.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TNot">The type to filter out.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence without any of the type <typeparamref name="TNot"/>.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static IEnumerable<TSource> WhereNotType<TSource, TNot>(this IEnumerable<TSource> source)
        => source.Where(item => item is not TNot);

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
    {
        foreach (var item in source)
        {
            if (item is object)
            {
                yield return item;
            }
        }
    }

    /// <summary>Applies an accumulator function over a sequence.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to aggregate over.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="initialValue">The initial accumulator value.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <returns>The final accumulator value.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="func" /> is <see langword="null" />.</exception>
    public static TAccumulate Reduce<TSource, TAccumulate>(this IEnumerable<TSource> source, Func<TAccumulate, TSource, TAccumulate> func, TAccumulate initialValue = default)
        => source.Aggregate(initialValue, func);

    /// <summary>Projects each element of a sequence into a new form.</summary>
    /// <param name="source">A sequence of values to invoke a transform function on.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector" />.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> whose elements are the result of invoking the transform function on each element of <paramref name="source" />.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="selector" /> is <see langword="null" />.</exception>
    public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        => source.Select(selector);

    /// <summary>Filters a sequence of values based on a predicate.</summary>
    /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that satisfy the condition.</returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is <see langword="null" />.</exception>
    public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        => source.Where(new Func<TSource, bool>(predicate));

    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default) => dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;

    public static TKey KeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, TKey defaultValue = default) => KeyByValue(dictionary, value, defaultValue);
    public static TKey GetKeyOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, TKey defaultValue = default)
    {
        foreach (KeyValuePair<TKey, TValue> pair in dictionary)
        {
            if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
                return pair.Key;
        }
        return defaultValue;
    }

    public static TKey KeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer, TKey defaultValue = default) => KeyByValue(dictionary, value, comparer, defaultValue);
    public static TKey GetKeyOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer, TKey defaultValue = default)
    {
        foreach (KeyValuePair<TKey, TValue> pair in dictionary)
        {
            if (comparer.Equals(pair.Value, value))
                return pair.Key;
        }
        return defaultValue;
    }

    public static bool SafeAdd<T>(this IList<T> list, T value)
    {
        if (!list.Contains(value))
        {
            list.Add(value);
            return true;
        }
        return false;
    }

    public static bool SafeAdd<T, K>(this IDictionary<T, K> dict, T key, K value)
    {
        if (!dict.ContainsKey(key))
        {
            dict.Add(key, value);
            return true;
        }
        return false;
    }

    public static void AddOrChange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary.ContainsKey(key))
            dictionary[key] = value;
        else
            dictionary.Add(key, value);
    }

    public static bool QuickRemove<T>(this IList<T> list, T item)
    {
        int num = list.IndexOf(item);
        if (num >= 0)
        {
            list.QuickRemoveAt(num);
            return true;
        }
        return false;
    }

    public static void QuickRemoveAt<T>(this IList<T> list, int index)
    {
        list[index] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
    }
    #endregion

    #region Unity
    internal static Transform? prefabParent;
    internal static Transform PrefabParent
    {
        get
        {
            if (prefabParent == null)
            {
                var prefabParentObj = new GameObject("PrefabParent");
                prefabParentObj.Deactivate();
                prefabParentObj.DontDestroyOnLoad();
                prefabParent = prefabParentObj.transform;
            }
            return prefabParent;
        }
    }

    /// <summary>
    /// Parent the given object to an inactive don't destroy on load object.
    /// </summary>
    public static GameObject Prefabitize(this GameObject obj)
    {
        obj.transform.SetParent(PrefabParent, false);
        return obj;
    }

    /// <summary>
    /// Copies an object and prefabitizes that copy.
    /// </summary>
    public static GameObject CopyPrefab(this GameObject original) => original.Instantiate(PrefabParent, false).Rename(original.name);

    /// <summary>
    /// Activates the game object.
    /// </summary>
    public static void Activate(this GameObject obj) => obj.SetActive(true);

    /// <summary>
    /// Deactivates the game object.
    /// </summary>
    public static void Deactivate(this GameObject obj) => obj.SetActive(false);

    /// <summary>
    /// Deconstruct a Rect
    /// </summary>
    public static void Deconstruct(this Rect rect, out float x, out float y, out float width, out float height)
    {
        x = rect.x;
        y = rect.y;
        width = rect.width;
        height = rect.height;
    }

    /// <summary>
    /// Deconstruct a Vector2
    /// </summary>
    public static void Deconstruct(this Vector2 vector2, out float x, out float y)
    {
        x = vector2.x;
        y = vector2.y;
    }

    public static Texture2D ToTexture2D(this RenderTexture rTex)
    {
        Texture2D texture2D = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        texture2D.ReadPixels(new Rect(0f, 0f, (float)rTex.width, (float)rTex.height), 0, 0);
        texture2D.Apply();
        return texture2D;
    }

    public static string GetPath(this Transform current)
    {
        if (current.parent == null) return current.name;
        return current.parent.GetPath() + "/" + current.name;
    }

    public static GameObject FindChild(this GameObject go, string childPath) =>
        go.transform.Find(childPath)?.gameObject;

    public static Component[] GetComponents(this GameObject go) => go.GetComponents<Component>().Where(c => c != null).ToArray();

    public static void RemoveComponent<T>(this GameObject go) where T : Component => UnityEngine.Object.Destroy(go.GetComponent<T>());
    public static void RemoveComponentImmediate<T>(this GameObject go) where T : Component => UnityEngine.Object.DestroyImmediate(go.GetComponent<T>());
    public static void RemoveComponent<T>(this GameObject go, T component) where T : Component => UnityEngine.Object.Destroy(component);
    public static void RemoveComponentImmediate<T>(this GameObject go, T component) where T : Component => UnityEngine.Object.DestroyImmediate(component);

    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null) t = go.AddComponent<T>();
        return t;
    }

    public static T GetOrAddComponent<T>(this Component component) where T : Component => component.gameObject.GetOrAddComponent<T>();

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="go">Object to test</param>
    /// <param name="type">The type of component</param>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent(this GameObject go, System.Type type)
    {
        return go.GetComponent(type) != null;
    }

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="go">Object to test</param>
    /// <param name="comp">The component if found, null if not</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this GameObject go, out T comp) where T : Component
    {
        comp = go.GetComponent<T>();

        return comp != null;
    }

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="go">Object to test</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this GameObject go) where T : Component
    {
        return go.GetComponent<T>() != null;
    }

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="component">Object to test</param>
    /// <param name="comp">The component if found, null if not</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this Component component, out T comp) where T : Component => component.gameObject.HasComponent(out comp);

    /// <summary>
    /// Is the component present in the object?
    /// </summary>
    /// <param name="component">Object to test</param>
    /// <typeparam name="T">The type of component</typeparam>
    /// <returns><see langword="true"/> if the component is found, <see langword="false"/> otherwise</returns>
    public static bool HasComponent<T>(this Component component) where T : Component => component.gameObject.HasComponent<T>();

    public static GameObject InstantiateInactive(this GameObject original)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static GameObject InstantiateInactive(this GameObject original, Transform parent, bool worldPositionStays)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original, parent, worldPositionStays);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static GameObject InstantiateInactive(this GameObject original, Vector3 position, Quaternion rotation)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original, position, rotation);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static GameObject InstantiateInactive(this GameObject original, Vector3 position, Quaternion rotation, Transform parent)
    {
        var active = original.activeSelf;
        if (active) original.SetActive(false);
        var copy = UnityEngine.Object.Instantiate(original, position, rotation, parent);
        copy.Rename(original.name);
        if (active) original.SetActive(true);
        return copy;
    }

    public static T Instantiate<T>(this T original) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original);
        copy.Rename(original.name);
        return copy;
    }

    public static T Instantiate<T>(this T original, Transform parent, bool worldPositionStays) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original, parent, worldPositionStays);
        copy.Rename(original.name);
        return copy;
    }

    public static T Instantiate<T>(this T original, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original, position, rotation);
        copy.Rename(original.name);
        return copy;
    }

    public static T Instantiate<T>(this T original, Vector3 position, Quaternion rotation, Transform parent) where T : UnityEngine.Object
    {
        var copy = UnityEngine.Object.Instantiate(original, position, rotation, parent);
        copy.Rename(original.name);
        return copy;
    }

    public static T DontDestroyOnLoad<T>(this T target) where T : UnityEngine.Object
    {
        UnityEngine.Object.DontDestroyOnLoad(target);
        return target;
    }

    public static T Rename<T>(this T target, string name) where T : UnityEngine.Object
    {
        target.name = name;
        return target;
    }

    public static void Destroy<T>(this T target) where T : UnityEngine.Object => UnityEngine.Object.Destroy(target);
    public static void DestroyImmediate<T>(this T target) where T : UnityEngine.Object => UnityEngine.Object.DestroyImmediate(target);

    public static void SmoothLookDir(this GameObject go, Vector3 direction, float dt, float angularVelocity)
    {
        var start = go.transform.rotation;
        var end = Quaternion.FromToRotation(Vector3.forward, direction);

        var angle = Quaternion.Angle(start, end);

        go.transform.rotation = Quaternion.Slerp(start, end, (angularVelocity / angle) * dt);
    }

    public static void LookDir(this GameObject go, Vector3 direction)
    {
        go.transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
    }

    public static GameObject FindChildWithExactName(this GameObject parent, string name)
    {
        var parentTransform = parent.transform;
        for (int i = parentTransform.childCount - 1; i >= 0; i--)
        {
            var childTransform = parentTransform.GetChild(i);
            if (childTransform.name == name)
                return childTransform.gameObject;
        }
        return null;
    }

    public static Transform FindChildWithExactName(this Transform parent, string name)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            var childTransform = parent.GetChild(i);
            if (childTransform.name == name)
                return childTransform;
        }
        return null;
    }

    public static void DestroyAllComponents<T>(this GameObject obj) where T : Component
    {
        foreach (var component in obj.GetComponents<T>())
        {
            GameObject.Destroy(component);
        }
    }

    public static void DestroyAllComponentsImmediate<T>(this GameObject obj) where T : Component
    {
        foreach (var component in obj.GetComponents<T>())
        {
            GameObject.DestroyImmediate(component);
        }
    }

    public static void DestroyAllChildren(this Transform t)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(t.GetChild(i).gameObject);
        }
        t.DetachChildren();
    }

    public static void DestroyAllChildrenImmediate(this Transform t)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(t.GetChild(i).gameObject);
        }
        t.DetachChildren();
    }

    public static void DestroyAllChildren(this Transform t, int skipIndex)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            if (i == skipIndex) continue;
            GameObject.Destroy(t.GetChild(i).gameObject);
        }
    }

    public static void DestroyAllChildrenImmediate(this Transform t, int skipIndex)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            if (i == skipIndex) continue;
            GameObject.DestroyImmediate(t.GetChild(i).gameObject);
        }
    }

    public static void SetLocalPositionX(this Transform trans, float x)
    {
        Vector3 localPosition = trans.localPosition;
        localPosition.x = x;
        trans.localPosition = localPosition;
    }

    public static void SetLocalPositionY(this Transform trans, float y)
    {
        Vector3 localPosition = trans.localPosition;
        localPosition.y = y;
        trans.localPosition = localPosition;
    }

    public static void SetLocalPositionZ(this Transform trans, float z)
    {
        Vector3 localPosition = trans.localPosition;
        localPosition.z = z;
        trans.localPosition = localPosition;
    }

    public static Quaternion InverseTransformRotation(this Transform t, Quaternion q)
    {
        return Quaternion.Inverse(t.rotation) * q;
    }

    public static StringTableEntry GetEntry(
      this StringTable stringTable,
      long keyId,
      string key)
    {
        if (keyId != 0L)
            return stringTable.GetEntry(keyId);
        else if (!string.IsNullOrWhiteSpace(key))
            return stringTable.GetEntry(key);

        return null;
    }

    #region Coroutines
    public static void FireOnNextUpdate(this MonoBehaviour component, Action action) =>
        component.FireInNUpdates(action, 1);

    public static void FireInNUpdates(this MonoBehaviour component, Action action, int n) =>
        component.StartCoroutine(WaitForFrames(action, n));

    public static void RunWhen(this MonoBehaviour component, Func<bool> predicate, Action action) =>
        component.StartCoroutine(WaitUntil(predicate, action));

    private static IEnumerator WaitForFrames(Action action, int n)
    {
        for (var i = 0; i < n; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        action.Invoke();
    }

    private static IEnumerator WaitUntil(Func<bool> predicate, Action action)
    {
        yield return new WaitUntil(predicate);
        action();
    }
    #endregion

    #region RectTransform
    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }

    public static void SetWidth(this RectTransform rt, float width)
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }

    public static void SetHeight(this RectTransform rt, float height)
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

    public static void SetPosX(this RectTransform rt, float posX)
    {
        rt.localPosition = new Vector3(posX, rt.localPosition.y, rt.localPosition.z);
    }

    public static void SetPosY(this RectTransform rt, float posY)
    {
        rt.localPosition = new Vector3(rt.localPosition.x, posY, rt.localPosition.z);
    }

    public static void SetAnchoredPosX(this RectTransform rt, float posX)
    {
        rt.anchoredPosition = new Vector3(posX, rt.anchoredPosition.y);
    }

    public static void SetAnchoredPosY(this RectTransform rt, float posY)
    {
        rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, posY);
    }
    #endregion
    #endregion
}