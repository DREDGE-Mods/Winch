using System;
using System.Collections.Generic;
using HarmonyLib;
using JetBrains.Annotations;
using Winch.AbyssApi;
using Winch.AbyssApi.Extensions;
using Winch.AbyssApi.Internal;
using Winch.Core;
using Winch.Logging;

namespace Winch;

public abstract class DredgeMod : IModContent
{
    public DredgeModInfo Info { get; internal set; }

    /// <summary>
    /// The harmony instance for this mod, if <see cref="CreateHarmonyInstance"/> is false, it will be null
    /// </summary>
    public Harmony? HarmonyInstance { get; private set; }

    /// <summary>
    /// Called after the plugin is loaded by the initializer
    /// </summary>
    public virtual void Initialize()
    {
    }


    /// <summary>
    /// A virtual call for the typical Unity start method
    /// </summary>
    public virtual void Start()
    {
        foreach (var modContent in Content)
        {
            try
            {
                modContent.Register();
            }
            catch (Exception e)
            {
                WinchCore.Log.Error($"Failed to register {modContent.Id}");
                WinchCore.Log.Error(e);
                LoadErrors.Add($"Failed to register {modContent.Name}");

                foreach (var rollbackAction in modContent.RollbackActions)
                {
                    try
                    {
                        rollbackAction();
                    }
                    catch (Exception e2)
                    {
                        WinchCore.Log.Error($"Error while rolling back failed addition of {modContent.Id}");
                        WinchCore.Log.Error(e2);
                        break;
                    }
                }
            }
            finally
            {
                modContent.RollbackActions.Clear();
            }
        }
    }

    [UsedImplicitly]
    internal void InitDredgeMod()
    {
        ModContentInstances.AddInstance(GetType(), this);

        if (CreateHarmonyInstance)
        {
            HarmonyInstance = new Harmony(Info.GUID);
            if (HarmonyPatchAll)
            {
                AccessTools.GetTypesFromAssembly(this.GetAssembly()).Do(ApplyHarmonyPatches);
            }
        }

        try
        {
            ResourceHandler.LoadEmbeddedTextures(this);
            ResourceHandler.LoadEmbeddedBundles(this);
            ModContent.LoadModContent(this);
        }
        catch (Exception e)
        {
            WinchCore.Log.Error("Critical failure when loading resources for mod " + Info.Name);
            WinchCore.Log.Error(e);
        }

        Initialize();
    }

    /// <summary>
    /// Tries to apply all Harmony Patches defined within a type. Logs a warning and adds a load error if any fail.
    /// </summary>
    /// <param name="type"></param>
    public void ApplyHarmonyPatches(Type type)
    {
        try
        {
            HarmonyInstance!.CreateClassProcessor(type).Patch();
        }
        catch (Exception e)
        {
            WinchCore.Log.Warn(
                $"Failed to apply {Info.Name} patch(es) in {type.Name}: \"{e.InnerException?.Message ?? e.Message}\" " +
                $"The mod might not function correctly. This needs to be fixed by one of the plugin authors");

            LoadErrors.Add($"Failed to apply patch(es) in {type.Name}");
        }
    }


    /// <summary>
    /// Whether to create a Harmony instance for this mod
    /// </summary>
    public virtual bool CreateHarmonyInstance => true;

    /// <summary>
    /// Whether to automatically apply all Harmony patches in this mod
    /// </summary>
    public virtual bool HarmonyPatchAll => true;

    internal readonly List<string> LoadErrors = new();

    /// <summary>
    /// All ModContent in ths mod
    /// </summary>
    public IReadOnlyList<ModContent> Content { get; internal set; } = null!;

    /// <summary>
    /// The embedded resources (textures) of this mod
    /// </summary>
    public Dictionary<string, byte[]> Resources { get; internal set; } = null!;

    /// <summary>
    /// The prefix used for the IDs of towers, upgrades, etc for this mod to prevent conflicts with other mods
    /// </summary>
    public virtual string IDPrefix => this.GetAssembly().GetName().Name + "-";

    /// <summary>
    /// Signifies that the game shouldn't crash / the mod shouldn't stop loading if one of its patches fails
    /// </summary>
    public virtual bool OptionalPatches => true;
}