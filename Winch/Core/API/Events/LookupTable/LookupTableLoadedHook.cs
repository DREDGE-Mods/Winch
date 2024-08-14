using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Winch.Core.API.Events.LookupTable
{
    public class LookupTableLoadedHook<T>
    {
        public event LookupTableLoadedEventHandler<T>? Before;
        public event LookupTableLoadedEventHandler<T>? On;

        public virtual void Trigger(object sender, IDictionary<string, T> result, bool prefix)
        {
            WinchCore.Log.Debug($"Triggered {typeof(T)} type event: {result.Count} elements (Prefix: {prefix})");
            try
            {
                var args = new LookupTableLoadedEventArgs<T>(result);
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
}
