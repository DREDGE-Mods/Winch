using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Winch.Util;

namespace Winch.Core;

internal class ModdedResourceProvider : ResourceProviderBase
{
    public override System.Type GetDefaultType(IResourceLocation location) => typeof(Object);

    public override bool CanProvide(System.Type t, IResourceLocation location) => AddressablesUtil.Resources.ContainsKey(location) && base.CanProvide(t, location);

    public override void Provide(ProvideHandle provideHandle)
    {
        try
        {
            string file = provideHandle.Location.InternalId;
            if (AddressablesUtil.Resources.TryGetValue(provideHandle.Location, out var resource))
                provideHandle.Complete<Object>(resource, true, null);
            else
                throw new System.Exception($"Resource \"{file}\" cannot be found.");
        }
        catch (System.Exception ex)
        {
            WinchCore.Log.Error(ex);
            provideHandle.Complete<Object>(null, false, ex);
        }
    }
}
