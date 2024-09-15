using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Winch.Core.API.Events.Addressables;

public struct AddressableLoadedEventArgs<T>
{
    public AsyncOperationHandle<T> Handle;

    public AddressableLoadedEventArgs(AsyncOperationHandle<T> handle)
    {
        Handle = handle;
    }
}