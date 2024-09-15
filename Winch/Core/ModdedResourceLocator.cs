using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using Winch.Core;
using Winch.Util;

namespace Winch.Core;

internal class ModdedResourceLocator : IResourceLocator
{
    public string LocatorId => "WinchModdedResourceLocator";
    public IEnumerable<object> Keys => AddressablesUtil.Locations.Keys;

    public bool Locate(object key, Type type, out IList<IResourceLocation> locations)
    {
        var skey = key.ToString();
        //WinchCore.Log.Debug(type != null ? $"{skey} [{type.FullName}]" : skey);

        if (!AddressablesUtil.Locations.ContainsKey(skey))
            goto failed;

        var list = AddressablesUtil.Locations[skey];
        if (type == null)
            goto success;

        int assignable = list.Count(location => type.IsAssignableFrom(location.ResourceType));
        if (assignable == 0)
            goto failed;
        else if (assignable == list.Count)
            goto success;
        else
            goto successTyped;

        success:
        locations = list;
        return true;

        successTyped:
        locations = new List<IResourceLocation>();
        foreach (IResourceLocation location in list)
        {
            if (type.IsAssignableFrom(location.ResourceType))
            {
                locations.Add(location);
            }
        }
        return true;

        failed:
        locations = null;
        return false;
    }
}