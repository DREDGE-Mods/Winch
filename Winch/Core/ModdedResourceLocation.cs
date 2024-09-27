using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;
using Winch.Util;

namespace Winch.Core;

internal class ModdedResourceLocation(string location, System.Type resourceType) : ResourceLocationBase(location, location, typeof(ModdedResourceProvider).FullName, resourceType)
{
    public Object Resource => AddressablesUtil.Resources.GetValueOrDefault(this);
}