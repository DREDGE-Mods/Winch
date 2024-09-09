using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Winch.Core;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(UnityExtensions), nameof(UnityExtensions.GetFilteredTypeList))]
internal static class FilteredTypePatcher
{
    [HarmonyPrefix]
    public static bool Prefix(Type t, ref IEnumerable<Type> __result)
    {
        __result = typeof(UnityExtensions).Assembly.GetFilteredTypeList(t)
            .Concat(typeof(WinchCore).Assembly.GetFilteredTypeList(t));
        foreach (var modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
        {
            if (modAssembly.LoadedAssembly != null)
            {
                __result = __result.Concat(modAssembly.LoadedAssembly.GetFilteredTypeList(t));
            }
        }
        return false;
    }
}
