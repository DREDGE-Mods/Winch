using System.Collections.Generic;
using System.IO;
using System.Linq;
using Winch.AbyssApi.Extensions;
using Winch.AbyssApi.Internal;
using Winch.Core;

namespace Winch.AbyssApi.Utilities;

/// <summary>
///
/// </summary>
public static class AbyssUtils
{
    private static readonly IEnumerable<DredgeMod>? _dredgeMods;

    /// <summary>
    /// Active mods that are of type DredgeMod
    /// </summary>
    public static readonly IEnumerable<DredgeMod> DredgeMods = _dredgeMods;

    /// <summary>
    /// Gets a DredgeMod by its name, or returns null if none are loaded with that name
    /// </summary>
    public static DredgeMod? GetMod(string name)
    {
        return DredgeMods.FirstOrDefault(dredgeMod => dredgeMod.GetName() == name);
    }

    /// <summary>
    /// Gets the instance of a specific DredgeMod by its type
    /// </summary>
    public static T GetMod<T>() where T : DredgeMod => (T) ModContentInstances.Instances[typeof(T)][0];

    /// <summary>
    /// Returns whether a mod with the given name is installed
    /// </summary>
    public static bool HasMod(string name) => GetMod(name) != null;

    /// <summary>
    /// Returns whether a mod with the given name is installed, and pass it to the out param if it is
    /// </summary>
    public static bool HasMod(string name, out DredgeMod? dredgeMod)
    {
        dredgeMod = GetMod(name);
        return dredgeMod != null;
    }
}