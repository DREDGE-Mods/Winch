using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;
using Winch.Util;

namespace Winch.Core;

internal class ModdedResourceLocation : ResourceLocationBase
{
    public Object Resource => AddressablesUtil.Resources.GetValueOrDefault(this);

    public ModdedResourceLocation(string location, System.Type resourceType) : base(location, location, typeof(ModdedResourceProvider).FullName, resourceType)
    {

    }
}
