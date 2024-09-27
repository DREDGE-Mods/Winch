using System.Collections.Generic;

namespace Winch.Core.API.Events.LookupTable;

public struct LookupTableLoadedEventArgs<T>
{
    public IDictionary<string, T> Result;

    public LookupTableLoadedEventArgs(IDictionary<string, T> result)
    {
        Result = result;
    }
}
