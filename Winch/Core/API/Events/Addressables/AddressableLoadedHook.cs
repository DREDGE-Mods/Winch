using System;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Winch.Core.API.Events.Addressables;

public class AddressableLoadedHook<T>
{
    public event AddressableLoadedEventHandler<T>? Before;
    public event AddressableLoadedEventHandler<T>? On;

    public void Trigger(object sender, AsyncOperationHandle<T> handle, bool prefix)
    {
        WinchCore.Log.Debug($"Triggered {typeof(T)} type event: {handle.Result} (Prefix: {prefix})");
        try
        {
            var args = new AddressableLoadedEventArgs<T>(handle);
            if (prefix)
                Before?.Invoke(sender, args);
            else
                On?.Invoke(sender, args);
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to trigger {typeof(T)} type event: {ex}");
        }

    }
}
