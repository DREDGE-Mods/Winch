using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Winch.AbyssApi.Extensions;
using Winch.AbyssApi.Internal;
using Winch.AbyssApi.Utilities;
using Winch.Core;

namespace Winch.AbyssApi;

/// <summary>
/// ModContent is the foundational class for all new content added in a mod
/// </summary>
[PublicAPI]
public abstract partial class ModContent : IModContent
{
    private const BindingFlags ConstructorFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    internal readonly Stack<Action> RollbackActions = new();

    /// <summary>
    /// The DredgeMod that this content was added by
    /// </summary>
    public DredgeMod? Mod {get; private set;} = null!;

    /// <summary>
    /// The name that will be at the end of the ID for this ModContent, default is the class name
    /// </summary>
    public virtual string Name => GetType().Name;

    /// <summary>
    /// The id that this ModContent will be given; a combination of the Mod's prefix and the name
    /// </summary>
    public string Id => GetId(Mod, Name);

    /// <summary>
    /// Used to allow some ModContent to Register before or after others, lower values register before higher ones
    /// </summary>
    /// <exclude />
    public virtual float RegistrationPriority => 0f;

    /// <summary>
    /// The order that the ModContent will be loaded/registered in, 0 is arbitrary
    /// </summary>
    protected virtual int Order => 0;

    /// <summary>
    /// Used for when you want to programmatically create multiple instances of a given ModContent
    /// </summary>
    public virtual IEnumerable<ModContent> Load()
    {
        yield return this;
    }

    /// <summary>
    /// Registers this ModContent into the game
    /// </summary>
    /// <exclude />
    public abstract void Register();

    internal static void LoadModContent(DredgeMod? mod)
    {
        if (mod != null)
            mod.Content = AccessTools.GetTypesFromAssembly(mod.GetAssembly())
                .Where(CanLoadType)
                .Select(type => CreateInstance(type, mod))
                .Where(content => content != null)
                .OrderBy(content => content!.RegistrationPriority)
                .ThenBy(content => content!.Order)
                .SelectMany(Load)
                .OrderBy(content => content.RegistrationPriority)
                .ThenBy(content => content.Order)
                .ToList();
    }

    private static bool CanLoadType(Type type) => type is { IsAbstract: false, ContainsGenericParameters: false } &&
        typeof(ModContent).IsAssignableFrom(type) &&
        type.GetConstructor(ConstructorFlags, null, Type.EmptyTypes, null) != null;

    private static ModContent? CreateInstance(Type type, DredgeMod? mod)
    {
        ModContent instance;
        try
        {
            instance = (ModContent) Activator.CreateInstance(type)!;
            instance.Mod = mod;
            ModContentInstances.AddInstance(type, instance);
        }
        catch (Exception e)
        {
            WinchCore.Log.Error($"Error creating default {type.Name}");
            WinchCore.Log.Error("A zero argument constructor is REQUIRED for all ModContent classes");
            WinchCore.Log.Error(e.ToString());
            return null;
        }

        return instance;
    }

    private static IEnumerable<ModContent> Load(ModContent? instance)
    {
        if (instance == null)
        {
            return Enumerable.Empty<ModContent>();
        }
        var type = instance.GetType();
        var content = new List<ModContent>();
        try
        {
            content.AddRange(instance.Load());
            var instances = new List<ModContent>();
            foreach (var modContent in content)
            {
                modContent.Mod = instance.Mod;
                if (instance.GetType().IsInstanceOfType(modContent))
                {
                    instances.Add(modContent);
                }
            }

            ModContentInstances.AddInstances(type, instances);
        }
        catch (Exception e)
        {
            WinchCore.Log.Error(
                $"Failed loading instances of type {type.Name} for mod {type.Assembly.GetName().Name}");
            WinchCore.Log.Error(e.ToString());
        }

        return content;
    }


    /// <summary>
    /// Gets all loaded ModContent objects that are T or a subclass of T
    /// </summary>
    /// <typeparam name="T">The modcontent type</typeparam>
    public static T[] GetContent<T>() where T : ModContent => AbyssUtils.DredgeMods
        .SelectMany(dredgeMod => dredgeMod.Content)
        .OfType<T>()
        .ToArray();
}