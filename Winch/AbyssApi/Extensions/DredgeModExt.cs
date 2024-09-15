using System.IO;
using System.Reflection;

namespace Winch.AbyssApi.Extensions;

/// <summary>
/// Extensions for DredgeMods
/// </summary>
public static class DredgeModExt
{
    /// <summary>
    /// Gets the assembly of this plugin
    /// </summary>
    public static Assembly GetAssembly(this DredgeMod mod) => mod.GetType().Assembly;


    /// <summary>
    /// Gets the file name of this plugin's assembly
    /// </summary>
    public static string FileName(this DredgeMod mod) => Path.GetFileName(mod.Info.Location);

    /// <summary>
    /// Get the name of this mod from it's dll name
    /// </summary>
    public static string GetName(this DredgeMod? dredgeMod)
    {
        if(dredgeMod == null)
            return "null";
        return dredgeMod.GetAssembly()?.GetName().Name ?? dredgeMod.Info.Name;
    }
}