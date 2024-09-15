using System;
using System.Reflection;

namespace FullSerializer {
    // Global configuration options.
    internal static class fsGlobalConfig {
        /// <summary>
        /// Should deserialization be case sensitive? If this is false and the JSON has multiple members with the
        /// same keys only separated by case, then this results in undefined behavior.
        /// </summary>
        internal static bool IsCaseSensitive = true;

        /// <summary>
        /// If exceptions are allowed internally, then additional date formats can be deserialized.
        /// Note that the Full Serializer internal API will *not* throw exceptions with this enabled;
        /// errors will still be returned in a fsResult instance.
        /// </summary>
        internal static bool AllowInternalExceptions = true;

        /// <summary>
        /// This string will be used to prefix fields used internally by FullSerializer.
        /// </summary>
        internal static string InternalFieldPrefix = "$";
    }

    /// <summary>
    /// Enables some top-level customization of Full Serializer.
    /// </summary>
    internal class fsConfig {
        /// <summary>
        /// The attributes that will force a field or property to be serialized.
        /// </summary>
        internal Type[] SerializeAttributes = {
#if !NO_UNITY
            typeof(UnityEngine.SerializeField),
#endif
            typeof(fsPropertyAttribute)
        };

        /// <summary>
        /// The attributes that will force a field or property to *not* be serialized.
        /// </summary>
        internal Type[] IgnoreSerializeAttributes = { typeof(NonSerializedAttribute), typeof(fsIgnoreAttribute) };

        /// <summary>
        /// The default member serialization.
        /// </summary>
        internal fsMemberSerialization DefaultMemberSerialization = fsMemberSerialization.Default;

        /// <summary>
        /// Convert a C# field/property name into the key used for the JSON object. For example, you could
        /// force all JSON names to lowercase with:
        ///
        ///    fsConfig.GetJsonNameFromMemberName = (name, info) => name.ToLower();
        ///
        /// This will only be used when the name is not explicitly specified with fsProperty.
        /// </summary>
        internal Func<string, MemberInfo, string> GetJsonNameFromMemberName = (name, info) => name;

        /// <summary>
        /// If false, then *all* property serialization support will be disabled - even properties
        /// explicitly annotated with fsProperty or any other opt-in annotation.
        ///
        /// Setting this to false means that SerializeNonAutoProperties and
        /// SerializeNoninternalSetProperties will be completely ignored.
        /// </summary>
        internal bool EnablePropertySerialization = true;

        /// <summary>
        /// Should the default serialization behaviour include non-auto properties?
        /// </summary>
        internal bool SerializeNonAutoProperties = false;

        /// <summary>
        /// Should the default serialization behaviour include properties with non-internal setters?
        /// </summary>
        internal bool SerializeNoninternalSetProperties = true;

        /// <summary>
        /// If not null, this string format will be used for DateTime instead of the default one.
        /// </summary>
        internal string CustomDateTimeFormatString = null;

        /// <summary>
        /// Int64 and UInt64 will be serialized and deserialized as string for compatibility
        /// </summary>
        internal bool Serialize64BitIntegerAsString = false;

        /// <summary>
        /// Enums are serialized using their names by default. Setting this to true will serialize them as integers instead.
        /// </summary>
        internal bool SerializeEnumsAsInteger = false;
    }
}
