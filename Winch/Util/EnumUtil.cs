﻿using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Winch.Config;
using Winch.Core;

namespace Winch.Util;

/// <summary>
/// An utility class to help with Enums
/// </summary>
public static class EnumUtil
{
    private static readonly Random Rng = new Random();

    internal static void Initialize(Harmony harmony)
    {
        harmony.Patch(AccessTools.Method(typeof(System.Enum), "GetCachedValuesAndNames"), transpiler: new HarmonyMethod(AccessTools.Method(typeof(EnumInfoPatch), nameof(EnumInfoPatch.Transpiler))));
        JSONConfig.AddDynamicConverter(new CustomStringEnumConverter());
        WinchCore.Log.Debug("EnumUtil initialized.");
    }

    private static class EnumInfoPatch
    {
        public static void FixEnum(object type, ref ulong[] oldValues, ref string[] oldNames)
        {
            var enumType = type as Type;
            if (TryGetRawPatch(enumType, out var patch))
            {
                var pairs = patch.GetPairs();

                List<ulong> newValues = new List<ulong>(oldValues);
                List<string> newNames = new List<string>(oldNames);

                foreach (var pair in pairs)
                {
                    newValues.Add(pair.Key);
                    newNames.Add(pair.Value);
                }

                oldValues = newValues.ToArray();
                oldNames = newNames.ToArray();

                Array.Sort(oldValues, oldNames, Comparer<ulong>.Default);
            }
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            using (var enumerator = instructions.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var v = enumerator.Current;
                    if (v.operand is MethodInfo me && me.Name == "Sort")
                    {
                        yield return v;
                        enumerator.MoveNext();
                        v = enumerator.Current;
                        var labels = v.labels;
                        v.labels = new List<Label>();
                        yield return new CodeInstruction(OpCodes.Ldarg_0) { labels = labels };
                        yield return new CodeInstruction(OpCodes.Ldloca, 1);
                        yield return new CodeInstruction(OpCodes.Ldloca, 2);
                        yield return new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(EnumInfoPatch), "FixEnum"));
                        yield return v;
                    }
                    else
                    {
                        yield return v;
                    }
                }
            }
        }
    }


    private static Dictionary<Type, EnumPatch> patches = new Dictionary<Type, EnumPatch>();


    private static FieldInfo cache = AccessTools.Field(AccessTools.TypeByName("System.RuntimeType"), "GenericCache");
    private static void ClearEnumCache(Type enumType) => cache.SetValue(enumType, null);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name) where T : Enum => (T)Create(typeof(T), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, T value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, short value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, ushort value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, int value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, uint value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, long value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, ulong value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, byte value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(string name, sbyte value) where T : Enum => Create<T>(value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(short value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(ushort value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(int value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(uint value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(long value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(ulong value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(byte value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(sbyte value, string name) where T : Enum => Create<T>(Enum.ToObject(typeof(T), value), name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static T Create<T>(object value, string name) where T : Enum
    {
        Create(typeof(T), value, name);
        return (T)value;
    }

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns>The created enum value</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static object Create(Type enumType, string name)
    {
        var newVal = GetFirstFreeValue(enumType);
        Create(enumType, GetFirstFreeValue(enumType), name);
        return newVal;
    }

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <param name="value">Value of the enum</param>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static void Create(Type enumType, string name, object value) => Create(enumType, value, name);

    /// <summary>
    /// Creates an actual enum value associated with a name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    /// <exception cref="Exception">The enum already has a value with the same name</exception>
    public static void Create(Type enumType, object value, string name)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        if (AlreadyHasName(enumType, name) || IsDefined(enumType, name)) throw new Exception($"The enum ({enumType.FullName}) already has a value with the name \"{name}\"");

        if (!TryGetRawPatch(enumType, out var patch))
        {
            patch = new EnumPatch(enumType);
            patches.Add(enumType, patch);
        }

        patch.AddValue(value.ToFriendlyValue(), name);

        // Clear enum cache
        ClearEnumCache(enumType);
    }

    internal static ulong ToFriendlyValue<T>(this T value) where T : Enum => (ulong)Convert.ToInt64(value, CultureInfo.InvariantCulture);
    internal static ulong ToFriendlyValue(this object value) => (ulong)Convert.ToInt64(value, CultureInfo.InvariantCulture);

    /// <summary>
    /// Removes a custom enum value from being associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    public static void Remove<T>(string name) where T : Enum => Remove(typeof(T), name);

    /// <summary>
    /// Removes a custom enum value from being associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to remove</param>
    public static void Remove<T>(T value) where T : Enum => Remove(typeof(T), value);

    /// <summary>
    /// Removes a custom enum value from being associated with a name
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to remove</param>
    public static void Remove<T>(object value) where T : Enum => Remove(typeof(T), value);

    /// <summary>
    /// Removes a custom enum value from being associated with a name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static void Remove(Type enumType, string name)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        if (TryGetRawPatch(enumType, out EnumPatch patch) && patch.HasName(name))
        {
            patch.RemoveValue(name);

            // Clear enum cache
            ClearEnumCache(enumType);
        }
    }

    /// <summary>
    /// Removes a custom enum value from being associated with a name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value of the enum</param>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static void Remove(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        ulong uvalue = value.ToFriendlyValue();
        if (TryGetRawPatch(enumType, out EnumPatch patch) && patch.HasValue(uvalue))
        {
            patch.RemoveValue(uvalue);

            // Clear enum cache
            ClearEnumCache(enumType);
        }
    }

    /// <summary>
    /// Check if it is a custom enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    public static bool IsDynamic<T>(string name) where T : Enum => IsDynamic(typeof(T), name);

    /// <summary>
    /// Check if it is a custom enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to check</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    public static bool IsDynamic<T>(this T value) where T : Enum => IsDynamic(typeof(T), value);

    /// <summary>
    /// Check if it is a custom enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to check</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    public static bool IsDynamic<T>(object value) where T : Enum => IsDynamic(typeof(T), value);

    /// <summary>
    /// Check if it is a custom enum name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDynamic(Type enumType, string name)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);

        return TryGetRawPatch(enumType, out EnumPatch patch) && patch.HasName(name);
    }

    /// <summary>
    /// Check if it is a custom enum value
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value of the enum</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDynamic(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);

        ulong uvalue = value.ToFriendlyValue();
        return TryGetRawPatch(enumType, out EnumPatch patch) && !patch.HasOriginalValue(uvalue);
    }

    /// <summary>
    /// Check if it is <b>not</b> a custom enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="name">Name of the enum value</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    public static bool IsStatic<T>(string name) where T : Enum => IsStatic(typeof(T), name);

    /// <summary>
    /// Check if it is <b>not</b> a custom enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to check</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    public static bool IsStatic<T>(this T value) where T : Enum => IsStatic(typeof(T), value);

    /// <summary>
    /// Check if it is <b>not</b> a custom enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to check</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    public static bool IsStatic<T>(object value) where T : Enum => IsStatic(typeof(T), value);

    /// <summary>
    /// Check if it is <b>not</b> a custom enum name
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="name">Name of the enum value</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsStatic(Type enumType, string name)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);

        return TryGetRawPatch(enumType, out EnumPatch patch) && patch.HasOriginalName(name);
    }

    /// <summary>
    /// Check if it is <b>not</b> a custom enum value
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value of the enum</param>
    /// <returns><see langword="true"/> if it is, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsStatic(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);

        ulong uvalue = value.ToFriendlyValue();
        return TryGetRawPatch(enumType, out EnumPatch patch) && patch.HasOriginalValue(uvalue);
    }

    private static bool TryAsNumber(this object value, Type type, out object result)
    {
        if (type.IsSubclassOf(typeof(IConvertible)))
            throw new ArgumentException("The type must inherit the IConvertible interface", "type");
        result = null;
        if (type.IsInstanceOfType(value))
        {
            result = value;
            return true;
        }
        if (value is IConvertible convertible)
        {
            if (type.IsEnum)
            {
                result = Enum.ToObject(type, value);
                return true;
            }
            var format = NumberFormatInfo.CurrentInfo;
            result = convertible.ToType(type, format);
            return true;
        }
        return false;
    }

    private static bool IsPowerOfTwo(this ulong x)
    {
        return x > 0 && (x & (x - 1)) == 0;
    }

    /// <summary>
    /// Does this enum use power of twos?
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns><see langword="true"/> if it does, <see langword="false"/> if not.</returns>
    public static bool IsPowerOfTwoEnum<T>() where T : Enum => IsFlagsEnum<T>();

    /// <summary>
    /// Does this enum use power of twos?
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns><see langword="true"/> if it does, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsPowerOfTwoEnum(Type enumType) => IsFlagsEnum(enumType);

    /// <summary>
    /// Does this enum have the flags attribute?
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns><see langword="true"/> if it does, <see langword="false"/> if not.</returns>
    public static bool IsFlagsEnum<T>() where T : Enum => typeof(T).IsDefined(typeof(FlagsAttribute), false);

    /// <summary>
    /// Does this enum have the flags attribute?
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns><see langword="true"/> if it does, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsFlagsEnum(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return enumType.IsDefined(typeof(FlagsAttribute), false);
    }

    /// <summary>
    /// Get first undefined value in an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The first undefined enum value</returns>
    /// <exception cref="Exception">No unused values in the enum</exception>
    public static T GetFirstFreeValue<T>() where T : Enum => (T)GetFirstFreeValue(typeof(T));

    /// <summary>
    /// Get first undefined value in an enum
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>The first undefined enum value</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    /// <exception cref="Exception">No unused values in the enum</exception>
    public static object GetFirstFreeValue(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);

        var vals = Enum.GetValues(enumType);
        var usesPowerOfTwo = IsPowerOfTwoEnum(enumType);
        long l = 0;
        for (ulong i = 0; i <= ulong.MaxValue; i++)
        {
            if (usesPowerOfTwo && !IsPowerOfTwo(i)) continue;
            if (!i.TryAsNumber(enumType, out var v))
                break;
            for (; l < vals.LongLength; l++)
                if (vals.GetValue(l).Equals(v))
                    goto skip;
            return v;
        skip:;
        }
        if (usesPowerOfTwo) goto no_negatives;
        for (long i = -1; i >= long.MinValue; i--)
        {
            if (!i.TryAsNumber(enumType, out var v))
                break;
            for (; l < vals.LongLength; l++)
                if (vals.GetValue(l).Equals(v))
                    goto skip;
            return v;
        skip:;
        }
    no_negatives:
        throw new Exception((usesPowerOfTwo ? "No unused values in power of two enum " : "No unused values in enum ") + enumType.FullName);
    }

    private static bool TryGetRawPatch<T>(out EnumPatch patch) where T : Enum => TryGetRawPatch(typeof(T), out patch);

    private static bool TryGetRawPatch(Type enumType, out EnumPatch patch)
    {
        return patches.TryGetValue(enumType, out patch);
    }

    private static bool AlreadyHasName(Type enumType, string name)
    {
        if (TryGetRawPatch(enumType, out EnumPatch patch))
            return patch.HasName(name);
        return false;
    }

    private class EnumPatch
    {
        private Dictionary<ulong, string[]> originalValues = new Dictionary<ulong, string[]>();
        private Dictionary<ulong, List<string>> values = new Dictionary<ulong, List<string>>();

        public EnumPatch(Type enumType)
        {
            if (enumType == null) throw new ArgumentNullException("enumType");
            if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
            originalValues = GetValues(enumType).ToDictionary(value => value.ToFriendlyValue(), value => GetSynonyms(enumType, value));
        }

        public List<KeyValuePair<ulong, string>> GetPairs()
        {
            List<KeyValuePair<ulong, string>> pairs = new List<KeyValuePair<ulong, string>>();
            foreach (KeyValuePair<ulong, List<string>> pair in values)
            {
                foreach (string value in pair.Value)
                    pairs.Add(new KeyValuePair<ulong, string>(pair.Key, value));
            }
            return pairs;
        }

        public bool HasOriginalValue(ulong value)
        {
            return originalValues.Keys.Contains(value);
        }

        public bool HasValue(ulong value)
        {
            return values.Keys.Contains(value);
        }

        public bool HasOriginalName(string name)
        {
            foreach (string enumName in this.originalValues.Values.SelectMany(l => l))
            {
                if (name.Equals(enumName))
                    return true;
            }
            return false;
        }

        public bool HasName(string name)
        {
            foreach (string enumName in this.values.Values.SelectMany(l => l))
            {
                if (name.Equals(enumName))
                    return true;
            }
            return false;
        }

        public void AddValue(ulong enumValue, string name)
        {
            if (values.ContainsKey(enumValue))
                values[enumValue].Add(name);
            else
                values.Add(enumValue, new List<string> { name });
        }

        public void RemoveValue(ulong enumValue) => values.Remove(enumValue);

        public void RemoveValue(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            foreach (var pair in values) pair.Value.Remove(name);
        }
    }

    /// <summary>
    /// Register all classes in an assembly with the Enum Holder attribute.
    /// </summary>
    /// <param name="assembly">The assembly to register enum holders in</param>
    internal static void RegisterAllEnumHolders(Assembly assembly)
    {
        var enumHolders = assembly.GetTypes().Where(type => type.IsDefined(typeof(EnumHolderAttribute), true)).ToList();
        if (enumHolders.Count > 0)
        {
            WinchCore.Log.Debug($"Registering enum holders for {assembly.GetName().Name}");
            foreach (var type in enumHolders)
            {
                foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if (!field.FieldType.IsEnum) continue;

                    if (Convert.ToInt64(field.GetValue(null)) == 0)
                    {
                        field.SetValue(null, Create(field.FieldType, field.Name));
                    }
                    else
                        Create(field.FieldType, field.GetValue(null), field.Name);
                }
            }
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to parse</param>
    /// <returns>The parsed enum on success, null on failure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object Parse(Type enumType, string value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        try
        {
            return System.Enum.Parse(enumType, value);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to parse</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <returns>The parsed enum on success, null on failure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object Parse(Type enumType, string value, bool ignoreCase)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        try
        {
            return System.Enum.Parse(enumType, value, ignoreCase);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to parse</param>
    /// <param name="result">The parsed enum if successful.</param>
    /// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool TryParse(Type enumType, string value, out object result)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        try
        {
            result = Enum.Parse(enumType, value);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to parse</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <param name="result">The parsed enum if successful.</param>
    /// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool TryParse(Type enumType, string value, bool ignoreCase, out object result)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        try
        {
            result = Enum.Parse(enumType, value, ignoreCase);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    /// <summary>
    /// Converts a number to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts a <see cref="sbyte"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, sbyte value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts a <see cref="byte"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, byte value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts a <see cref="short"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, short value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts an <see cref="ushort"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, ushort value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts an <see cref="int"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, int value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts an <see cref="uint"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, uint value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts a <see cref="long"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, long value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Converts an <see cref="ulong"/> to an enum.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object FromObject(Type enumType, ulong value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.ToObject(enumType, value);
    }

    /// <summary>
    /// Gets the underlying type of an enum type.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>The underlying type of <paramref name="enumType"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static Type GetUnderlyingType(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.GetUnderlyingType(enumType);
    }

    /// <summary>
    /// Get the name of an enum value
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to get the name of</param>
    /// <returns>The name of the enum value</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static string GetName(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.GetName(enumType, value);
    }

    /// <summary>
    /// Gets all names in an enum
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>An array of the names in the enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static string[] GetNames(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.GetNames(enumType);
    }

    /// <summary>
    /// Gets all values in an enum
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>An array of the values in the enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object[] GetValues(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return System.Enum.GetValues(enumType).Cast<object>().Distinct().ToArray();
    }

    /// <summary>
    /// Gets all names of all values that are the equal to the given value.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">The value to search for synonyms of</param>
    /// <returns>The list of names that have the same value as <paramref name="value"/>. (the list includes <paramref name="value"/>)</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static string[] GetSynonyms(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return GetNames(enumType).Where(n => Parse(enumType, n).Equals(value)).ToArray();
    }

    /// <summary>
    /// Counts the number of enums values contained in a given enum type.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>The number of enum values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static int Count(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return GetValues(enumType).Length;
    }

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, object value)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        try
        {
            return System.Enum.IsDefined(enumType, value);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, sbyte value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, byte value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, short value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, ushort value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, int value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, uint value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, long value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, ulong value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static bool IsDefined(Type enumType, string value) => IsDefined(enumType, (object)value);

    /// <summary>
    /// Gets the minimum value in the enum
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>the minimum value in the enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object GetMinValue(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return GetValues(enumType).Min();
    }

    /// <summary>
    /// Gets the maximum value in the enum
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>the maximum value in the enum</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="enumType"/> is not an enum</exception>
    public static object GetMaxValue(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        return GetValues(enumType).Max();
    }

    /// <summary>
    /// Gets a random value from an enum
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <returns>A randomly selected enum value from the given enum type</returns>
    public static object GetRandom(Type enumType)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        var values = Enum.GetValues(enumType);
        var item = Rng.Next(0, values.Length);
        return values.GetValue(item);
    }

    /// <summary>
    /// Gets a random value from an enum with exclusions
    /// </summary>
    /// <param name="enumType">Type of the enum</param>
    /// <param name="excluded">Enums to exclude from the randomization</param>
    /// <returns>A randomly selected enum value from the given enum type</returns>
    public static object GetRandom(Type enumType, params object[] excluded)
    {
        if (enumType == null) throw new ArgumentNullException("enumType");
        if (!enumType.IsEnum) throw new NotAnEnumException(enumType);
        if (excluded == null) throw new ArgumentNullException("excluded");
        var values = GetValues(enumType).Where(v => !excluded.Contains(v)).ToArray();
        var item = Rng.Next(0, values.Length);
        return values.GetValue(item);
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to parse</param>
    /// <param name="errorReturn">What to return if the parse fails.</param>
    /// <returns>The parsed enum on success, <paramref name="errorReturn"/> on failure.</returns>
    public static T Parse<T>(string value, T errorReturn = default) where T : Enum
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        catch
        {
            return errorReturn;
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to parse</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <param name="errorReturn">What to return if the parse fails.</param>
    /// <returns>The parsed enum on success, <paramref name="errorReturn"/> on failure.</returns>
    public static T Parse<T>(string value, bool ignoreCase, T errorReturn = default) where T : Enum
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
        catch
        {
            return errorReturn;
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to parse</param>
    /// <param name="result">The parsed enum if successful.</param>
    /// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
    public static bool TryParse<T>(string value, out T result) where T : Enum
    {
        try
        {
            result = (T)Enum.Parse(typeof(T), value);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Parses an enum in a easier way
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to parse</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <param name="result">The parsed enum if successful.</param>
    /// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
    public static bool TryParse<T>(string value, bool ignoreCase, out T result) where T : Enum
    {
        try
        {
            result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Converts a number to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(object value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts a <see cref="sbyte"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(sbyte value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts a <see cref="byte"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(byte value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts a <see cref="short"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(short value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts an <see cref="ushort"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(ushort value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts an <see cref="int"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(int value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts an <see cref="uint"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(uint value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts a <see cref="long"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(long value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Converts an <see cref="ulong"/> to an enum.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to convert</param>
    /// <returns>The number as an enum</returns>
    public static T FromObject<T>(ulong value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    /// <summary>
    /// Gets the underlying type of an enum type.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The underlying type of <typeparamref name="T"/></returns>
    public static Type GetUnderlyingType<T>() where T : Enum => Enum.GetUnderlyingType(typeof(T));

    /// <summary>
    /// Get the name of an enum value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to get the name of</param>
    /// <returns>The name of the enum value</returns>
    public static string GetName<T>(this T value) where T : Enum => Enum.GetName(typeof(T), value);

    /// <summary>
    /// Gets all names in an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The list of names in the enum</returns>
    public static string[] GetNames<T>() where T : Enum => Enum.GetNames(typeof(T));

    /// <summary>
    /// Gets all names in an enum, skipping the first (usually default,none) value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The list of all names (excluding the first value) in the enum</returns>
    public static string[] GetNamesWithoutFirst<T>() where T : Enum => Enum.GetNames(typeof(T)).Skip(1).ToArray();

    /// <summary>
    /// Gets all names in an enum with exclusions
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="excluded">Enums to exclude from the randomization</param>
    /// <returns>The list of names in the enum</returns>
    public static string[] GetNames<T>(params T[] excluded) where T : Enum => GetValues<T>(excluded).Select(GetName).ToArray();

    /// <summary>
    /// Gets all enum values in an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The list of all values in the enum</returns>
    public static T[] GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>().Distinct().ToArray();

    /// <summary>
    /// Gets all enum values in an enum, skipping the first (usually default,none) value
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The list of all values (excluding the first value) in the enum</returns>
    public static T[] GetValuesWithoutFirst<T>() where T : Enum => GetValues<T>().Skip(1).ToArray();

    /// <summary>
    /// Gets all enum values in an enum with exclusions
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="excluded">Enums to exclude from the randomization</param>
    /// <returns>The list of all values in the enum</returns>
    public static T[] GetValues<T>(params T[] excluded) where T : Enum => GetValues<T>().Where(v => !excluded.Contains(v)).ToArray();

    /// <summary>
    /// Gets all dynamic (custom) enum values in an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The list of all dynamic values in the enum</returns>
    public static T[] GetDynamicValues<T>() where T : Enum => GetValues<T>().Where(IsDynamic).ToArray();

    /// <summary>
    /// Gets all static (non-custom) enum values in an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The list of all static values in the enum</returns>
    public static T[] GetStaticValues<T>() where T : Enum => GetValues<T>().Where(IsStatic).ToArray();

    /// <summary>
    /// Gets all names of all values that are the equal to the given value.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The value to search for synonyms of</param>
    /// <returns>The list of names that have the same value as <paramref name="value"/>. (the list includes <paramref name="value"/>)</returns>
    public static string[] GetSynonyms<T>(this T value) where T : Enum => GetNames<T>().Where(n => Parse<T>(n).Equals(value)).ToArray();

    /// <summary>
    /// Counts the number of enums values contained in a given enum type.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>The number of enum values.</returns>
    public static int Count<T>() where T : Enum => GetValues<T>().Length;

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(object value) where T : Enum
    {
        try
        {
            return Enum.IsDefined(typeof(T), value);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(sbyte value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(byte value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(short value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(ushort value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(int value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(uint value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(long value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(ulong value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(string value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Checks if an enum is defined.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">Value to check</param>
    /// <returns><see langword="true"/> if defined, <see langword="false"/> if not.</returns>
    public static bool IsDefined<T>(this T value) where T : Enum => IsDefined<T>((object)value);

    /// <summary>
    /// Gets the minimum value in the enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>the minimum value in the enum</returns>
    public static T GetMinValue<T>() where T : Enum => GetValues<T>().Min();

    /// <summary>
    /// Gets the maximum value in the enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>the maximum value in the enum</returns>
    public static T GetMaxValue<T>() where T : Enum => GetValues<T>().Max();

    /// <summary>
    /// Converts the enum <paramref name="value"/> to its string representation according to the given format.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="value">The enum value to convert.</param>
    /// <param name="format">The output format to use.</param>
    /// <returns>The underlying type of <typeparamref name="T"/></returns>
    public static string Format<T>(this T value, string format) where T : Enum => Enum.Format(typeof(T), value, format);

    /// <summary>
    /// Gets a random value from an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>A randomly selected enum value from the given enum type</returns>
    public static T GetRandom<T>() where T : Enum
    {
        var values = GetValues<T>();
        var item = Rng.Next(0, values.Length);
        return (T)values.GetValue(item);
    }

    /// <summary>
    /// Gets a random value from an enum with exclusions
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="excluded">Enums to exclude from the randomization</param>
    /// <returns>A randomly selected enum value from the given enum type</returns>
    public static T GetRandom<T>(params T[] excluded) where T : Enum
    {
        var values = GetValues<T>(excluded);
        var item = Rng.Next(0, values.Length);
        return (T)values.GetValue(item);
    }

    /// <summary>
    /// Gets a random name from an enum
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>A randomly selected enum name from the given enum type</returns>
    public static string GetRandomName<T>() where T : Enum
    {
        var names = GetNames<T>();
        var item = Rng.Next(0, names.Length);
        return (string)names.GetValue(item);
    }

    /// <summary>
    /// Gets a random name from an enum with exclusions
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="excluded">Enums to exclude from the randomization</param>
    /// <returns>A randomly selected enum name from the given enum type</returns>
    public static string GetRandomName<T>(params T[] excluded) where T : Enum
    {
        var names = GetNames<T>(excluded);
        var item = Rng.Next(0, names.Length);
        return (string)names.GetValue(item);
    }

    /// <summary>
    /// Returns all enums with their descriptions in a dictionary.
    /// <see cref="DescriptionAttribute"/> needs to be applied on enum values to set a description text.
    /// </summary>
    /// <typeparam name="T">Type of the enum</typeparam>
    /// <returns>Dictionary of enum-to-description mappings.</returns>
    public static IDictionary<T, string> GetDescriptions<T>() where T : Enum
    {
        var type = typeof(T);
        var dictionary = new Dictionary<T, string>();

        foreach (var key in GetValues<T>())
        {
            var field = type.GetField($"{key}");
            string description = string.Empty;
            if (field != null && Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                description = attribute.Description;
            }

            dictionary.Add(key, description);
        }

        return dictionary;
    }

    /// <summary>
    /// Throws a <see cref="NotAnEnumException"/> if <paramref name="type"/> is not an enum.
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/></exception>
    /// <exception cref="NotAnEnumException"><paramref name="type"/> is not an enum</exception>
    public static void ThrowIfNotEnum(Type type)
    {
        if (type == null) throw new ArgumentNullException("type");
        if (!type.IsEnum) throw new NotAnEnumException(type);
    }

    /// <summary>
    /// Throws a <see cref="NotAnEnumException"/> if <typeparamref name="T"/> is not an enum.
    /// </summary>
    /// <typeparam name="T">Type to check</typeparam>
    /// <exception cref="NotAnEnumException"><typeparamref name="T"/> is not an enum</exception>
    public static void ThrowIfNotEnum<T>()
    {
        if (!typeof(T).IsEnum) throw new NotAnEnumException(typeof(T));
    }

    /// <summary>
    /// Casts an Enum to a specific type
    /// </summary>
    public static T EnumCast<T>(this Enum value) where T : Enum
    {
        if (value.GetType() != typeof(T))
            throw new InvalidCastException("Enums are not of the same type");
        return (T)(object)value;
    }

    /// <summary>
    /// Casts an Enum to a specific type
    /// </summary>
    public static IEnumerable<T> EnumCast<T>(this IEnumerable<Enum> values) where T : Enum => values.Select(e => e.EnumCast<T>());

    /// <inheritdoc cref="Enum.HasFlag(Enum)"/>
    public static bool HasFlag<T>(this T flags, T flag) where T : Enum
        => flags.HasFlag(flag);

    /// <summary>
    /// Sets a flag bit to 0 or 1
    /// </summary>
    public static T SetFlag<T>(this T flags, T flag, bool setBit) where T : Enum
        => setBit ? AddFlag(flags, flag) : RemoveFlag(flags, flag);

    /// <summary>
    /// Adds a flag to an enum
    /// </summary>
    public static T AddFlag<T>(this T flags, T flag) where T : Enum
        => FromObject<T>(flags.ToFriendlyValue() | flag.ToFriendlyValue());

    /// <summary>
    /// Removes a flag from an enum
    /// </summary>
    public static T RemoveFlag<T>(this T flags, T flag) where T : Enum
        => FromObject<T>(flags.ToFriendlyValue() & ~flag.ToFriendlyValue());

    /// <summary>
    /// Toggles a flag in an enum
    /// </summary>
    public static T ToggleFlag<T>(this T flags, T flag) where T : Enum
        => FromObject<T>(flags.ToFriendlyValue() ^ flag.ToFriendlyValue());

    /// <summary>
    /// 1 &lt;&lt; <paramref name="index"/>
    /// </summary>
    public static T GetFlagsValue<T>(int index) where T : Enum
        => FromObject<T>(1 << index);

    /// <summary>
    /// 0
    /// </summary>
    public static T GetNoFlags<T>() where T : Enum
        => FromObject<T>(0);

    /// <summary>
    /// ~0
    /// </summary>
    public static T GetAllFlags<T>() where T : Enum
        => FromObject<T>(~0);

    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="flags">The value to get the flags from.</param>
    /// <returns>All the flags that the value had.</returns>
    /// <exception cref="ArgumentException">When the enum doesn't have the flags attribute.</exception>
    public static T[] GetFlagsValues<T>(this T flags) where T : Enum
    {
        if (!IsFlagsEnum<T>())
            throw new ArgumentException(string.Format("The type '{0}' must have an attribute '{1}'.", typeof(T), typeof(FlagsAttribute)));

        Type underlyingType = GetUnderlyingType<T>();

        ulong num = flags.ToFriendlyValue();
        var enumNameValues = GetValues<T>().Select(ToFriendlyValue).Where(IsPowerOfTwo);
        IList<T> selectedFlagsValues = new List<T>();

        foreach (ulong enumNameValue in enumNameValues)
        {
            if ((num & enumNameValue) == enumNameValue && enumNameValue != 0)
            {
                selectedFlagsValues.Add((T)Convert.ChangeType(enumNameValue, underlyingType, CultureInfo.CurrentCulture));
            }
        }

        if (selectedFlagsValues.Count == 0 && enumNameValues.SingleOrDefault(v => v == 0) != 0)
        {
            selectedFlagsValues.Add(default(T));
        }

        return selectedFlagsValues.ToArray();
    }

    /// <typeparam name="T">Type of the enum</typeparam>
    /// <param name="values"></param>
    /// <returns>All the flags values combined into one enum value.</returns>
    /// <exception cref="ArgumentException">When the enum doesn't have the flags attribute.</exception>
    public static T CombineFlagsValues<T>(this T[] values) where T : struct, Enum
    {
        if (!IsFlagsEnum<T>())
            throw new ArgumentException(string.Format("The type '{0}' must have an attribute '{1}'.", typeof(T), typeof(FlagsAttribute)));

        T combined = default(T);
        if (values != null && values.Length > 0)
        {
            foreach (var value in values)
            {
                combined = combined.AddFlag<T>(value);
            }
        }
        return combined;
    }
}

/// <summary>
/// Add this attribute to a class, and any static enum fields will have an enum value created with the name of the field.
/// </summary>
public class EnumHolderAttribute : Attribute { }

/// <summary>
/// The exception that is thrown when an enum type is needed but the given type is not an enum.
/// </summary>
public class NotAnEnumException : Exception
{
    private Type _type;

    /// <summary>
    /// The type that is not an enum
    /// </summary>
    public Type Type => _type;

    /// <summary>
    /// Initializes a new instance of the NotAnEnumException class with a type that is not an enum.
    /// </summary>
    /// <param name="type">The type that is not an enum</param>
    public NotAnEnumException(Type type) : base($"The given type isn't an enum ({type.FullName} isn't an Enum)")
    {
        _type = type;
    }

    /// <summary>
    /// Initializes a new instance of the NotAnEnumException class with a type that is not an enum and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="type">The type that is not an enum</param>
    /// <param name="innerException">The exception caused the current exception</param>
    public NotAnEnumException(Type type, Exception innerException) : base($"The given type isn't an enum ({type.FullName} isn't an Enum)", innerException)
    {
        _type = type;
    }
}

public class CustomStringEnumConverter : StringEnumConverter
{
    public CustomStringEnumConverter()
    {
        AllowIntegerValues = true;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }
        Enum @enum = (Enum)value;
        string name = EnumUtil.GetName(@enum.GetType(), @enum);
        if (!string.IsNullOrWhiteSpace(name))
        {
            writer.WriteValue(name);
            return;
        }
        if (!AllowIntegerValues)
        {
            throw Create(null, writer.Path, string.Format(CultureInfo.InvariantCulture, "Integer value {0} is not allowed.", @enum.ToString("D")));
        }
        writer.WriteValue(value);
    }

    public static bool IsNullable(Type t)
    {
        if (t == null) throw new ArgumentNullException("t");
        return !t.IsValueType || IsNullableType(t);
    }
    public static bool IsNullableType(Type t)
    {
        if (t == null) throw new ArgumentNullException("t");
        return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
    public static Type GetObjectType(object? v)
    {
        if (v == null) throw new ArgumentNullException("v");
        return v.GetType();
    }

    private static string FormatWith(string format, IFormatProvider provider, params object[] args)
    {
        if (format == null) throw new ArgumentNullException("format");
        return string.Format(provider, format, args);
    }

    public static string ToString(object? value)
    {
        if (value == null)
        {
            return "{null}";
        }
        string? text = value as string;
        if (text == null)
        {
            return value.ToString();
        }
        return "\"" + text + "\"";
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType != JsonToken.Null)
        {
            bool nullable = IsNullableType(objectType);
            Type type = (nullable ? Nullable.GetUnderlyingType(objectType) : objectType);
            try
            {
                object? value = reader.Value;
                string svalue = value?.ToString() ?? string.Empty;
                if ((value == null || string.IsNullOrWhiteSpace(svalue)) && nullable) return null;
                if (EnumUtil.TryParse(type, svalue, out object result)) return result;
            }
            catch (Exception ex)
            {
                throw Create(reader, string.Format(CultureInfo.InvariantCulture, "Error converting value {0} to type '{1}'.", ToString(reader.Value), objectType), ex);
            }
            throw Create(reader, string.Format(CultureInfo.InvariantCulture, "Unexpected token {0} when parsing enum.", reader.TokenType));
        }
        if (!IsNullableType(objectType))
        {
            throw Create(reader, string.Format(CultureInfo.InvariantCulture, "Cannot convert null value to {0}.", objectType));
        }
        return null;
    }

    internal static string FormatMessage(IJsonLineInfo? lineInfo, string path, string message)
    {
        if (!message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
        {
            message = message.Trim();
            if (!message.EndsWith("."))
            {
                message += ".";
            }
            message += " ";
        }
        message += string.Format(CultureInfo.InvariantCulture, "Path '{0}'", path);
        if (lineInfo != null && lineInfo.HasLineInfo())
        {
            message += string.Format(CultureInfo.InvariantCulture, ", line {0}, position {1}", lineInfo.LineNumber, lineInfo.LinePosition);
        }
        message += ".";
        return message;
    }

    internal static JsonSerializationException Create(JsonReader reader, string message) => Create(reader as IJsonLineInfo, reader.Path, message);

    internal static JsonSerializationException Create(JsonReader reader, string message, Exception ex) => Create(reader as IJsonLineInfo, reader.Path, message, ex);

    internal static JsonSerializationException Create(IJsonLineInfo? lineInfo, string path, string message) => Create(lineInfo, path, message, null);

    internal static JsonSerializationException Create(IJsonLineInfo? lineInfo, string path, string message, Exception? ex)
    {
        message = FormatMessage(lineInfo, path, message);
        int lineNumber;
        int linePosition;
        if (lineInfo != null && lineInfo.HasLineInfo())
        {
            lineNumber = lineInfo.LineNumber;
            linePosition = lineInfo.LinePosition;
        }
        else
        {
            lineNumber = 0;
            linePosition = 0;
        }
        return new JsonSerializationException(message, path, lineNumber, linePosition, ex);
    }
}