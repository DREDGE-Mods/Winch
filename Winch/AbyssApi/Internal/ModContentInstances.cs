using System;
using System.Collections.Generic;
using System.Linq;
using Winch.Core;

namespace Winch.AbyssApi.Internal;

internal static class ModContentInstances
{
    static ModContentInstances()
    {
        Instances = new Dictionary<Type, List<IModContent>>();
        Actions = new Dictionary<Type, Action<List<IModContent>>>();
    }

    internal static Dictionary<Type, List<IModContent>> Instances { get; }

    internal static Dictionary<Type, Action<List<IModContent>>> Actions { get; }

    internal static void AddInstance(Type type, IModContent instance)
    {
        AddInstances(type, new List<IModContent> {instance});
    }

    internal static void AddInstances(Type type, IEnumerable<ModContent> instances)
    {
        AddInstances(type, instances.Cast<IModContent>().ToList());
    }

    internal static void AddInstances(Type type, IEnumerable<IModContent> instances)
    {
        if (typeof(IModContent).IsAssignableFrom(type))
        {
            if (!Instances.TryGetValue(type, out var list)) list = Instances[type] = [];
            list.AddRange(instances);
            if (Actions.TryGetValue(type, out var action))
            {
                action(Instances[type]);
            }
        }
        else
        {
            WinchCore.Log.Error($"Tried to add content instances of type {type.Name} that wasn't valid");
        }
    }
}

/// <summary>
/// Generic class that tracks Instances of ModContent
/// </summary>
/// <typeparam name="T"></typeparam>
internal static class ModContentInstance<T> where T : IModContent
{
    static ModContentInstance()
    {
        ModContentInstances.Actions[typeof(T)] = AddInstances;
        if (ModContentInstances.Instances.TryGetValue(typeof(T), out var instances))
        {
            AddInstances(instances);
        }
    }

    internal static T? Instance { get; private set; }

    internal static List<T>? Instances { get; private set; } = new();

    private static void AddInstances(IEnumerable<IModContent> instances)
    {
        Instances ??= new List<T>();
        Instances.AddRange(instances.Cast<T>());
        Instance ??= Instances[0];
    }
}