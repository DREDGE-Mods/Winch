using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.AbyssApi.Generators;
using Winch.Core;

namespace Winch.AbyssApi.Patches.AdressablesLoaded;


[HarmonyPatch]
internal static class AddressablesLoadedMethods
{
    [HarmonyTargetMethods]
    [UsedImplicitly]
    private static IEnumerable<MethodBase> TargetMethods()
    {
        foreach (var methodInfo in AccessTools.GetDeclaredMethods(typeof(DataLoader)).Where(method => method.Name.StartsWith("On") && method.Name.EndsWith("AddressablesLoaded"))) yield return methodInfo;
        yield return AccessTools.Method(typeof(AchievementManager), "OnAchievementDataAddressablesLoaded");
        yield return AccessTools.Method(typeof(ItemManager), "OnItemDataAddressablesLoaded");
        yield return AccessTools.Method(typeof(UpgradeManager), "OnUpgradeDataAddressablesLoaded");
    }

    [HarmonyPostfix]
    private static void Postfix(dynamic handle)
    {
        try
        {
            if(handle.Status != AsyncOperationStatus.Succeeded)
                return;

            foreach(var t in handle.Result)
            {
                ClassGenerator.Export(t);
            }

            var method = typeof(AbyssEvents).GetMethod("Invoke" + handle.Result.GetType().GenericTypeArguments[0].Name + "Loaded", AccessTools.all) as MethodInfo;
            if (method != null)
            {
                try
                {
                    method.Invoke(null, new object[] {handle.Result});
                }
                catch (Exception e)
                {
                    WinchCore.Log.Error(e.ToString());
                }
            }
            else
            {
                WinchCore.Log.Error("Could not find Invoke" + handle.Result.GetType().GenericTypeArguments[0].Name + "Loaded in AbyssEvents");
            }
        }
        catch (Exception e)
        {
            WinchCore.Log.Error(e.ToString());
            throw;
        }
    }
}
