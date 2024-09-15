using System;

namespace FullSerializer {
    /// <summary>
    /// The given property or field annotated with [JsonIgnore] will not be serialized.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal sealed class fsIgnoreAttribute : Attribute {
    }
}