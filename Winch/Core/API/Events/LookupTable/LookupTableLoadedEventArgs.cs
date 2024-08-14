using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Winch.Core.API.Events.LookupTable
{
    public struct LookupTableLoadedEventArgs<T>
    {
        public IDictionary<string, T> Result;

        public LookupTableLoadedEventArgs(IDictionary<string, T> result)
        {
            Result = result;
        }
    }
}
