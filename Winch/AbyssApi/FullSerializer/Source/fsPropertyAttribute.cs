using System;

namespace FullSerializer {
    /// <summary>
    /// Explicitly mark a property to be serialized. This can also be used to give the name that the
    /// property should use during serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal sealed class fsPropertyAttribute : Attribute {
        /// <summary>
        /// The name of that the property will use in JSON serialization.
        /// </summary>
        internal string Name;

        /// <summary>
        /// Use a custom converter for the given type. Specify the converter to use using typeof.
        /// </summary>
        internal Type Converter;

        internal fsPropertyAttribute()
            : this(string.Empty) {
        }

        internal fsPropertyAttribute(string name) {
            Name = name;
        }
    }
}