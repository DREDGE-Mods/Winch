using System;

namespace FullSerializer {
    /// <summary>
    /// This allows you to forward serialization of an object to one of its members. For example,
    ///
    /// [fsForward("Values")]
    /// struct Wrapper {
    ///   internal int[] Values;
    /// }
    ///
    /// Then `Wrapper` will be serialized into a JSON array of integers. It will be as if `Wrapper`
    /// doesn't exist.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    internal sealed class fsForwardAttribute : Attribute {
        /// <summary>
        /// The name of the member we should serialize as.
        /// </summary>
        internal string MemberName;

        /// <summary>
        /// Forward object serialization to an instance member. See class comment.
        /// </summary>
        /// <param name="memberName">The name of the member that we should serialize this object as.</param>
        internal fsForwardAttribute(string memberName) {
            MemberName = memberName;
        }
    }
}

namespace FullSerializer.Internal {
    internal class fsForwardConverter : fsConverter {
        private string _memberName;

        internal fsForwardConverter(fsForwardAttribute attribute) {
            _memberName = attribute.MemberName;
        }

        internal override bool CanProcess(Type type) {
            throw new NotSupportedException("Please use the [fsForward(...)] attribute.");
        }

        private fsResult GetProperty(object instance, out fsMetaProperty property) {
            var properties = fsMetaType.Get(Serializer.Config, instance.GetType()).Properties;
            for (int i = 0; i < properties.Length; ++i) {
                if (properties[i].MemberName == _memberName) {
                    property = properties[i];
                    return fsResult.Success;
                }
            }

            property = default(fsMetaProperty);
            return fsResult.Fail("No property named \"" + _memberName + "\" on " + instance.GetType().CSharpName());
        }

        internal override fsResult TrySerialize(object instance, out fsData serialized, Type storageType) {
            serialized = fsData.Null;
            var result = fsResult.Success;

            fsMetaProperty property;
            if ((result += GetProperty(instance, out property)).Failed) return result;

            var actualInstance = property.Read(instance);
            return Serializer.TrySerialize(property.StorageType, actualInstance, out serialized);
        }

        internal override fsResult TryDeserialize(fsData data, ref object instance, Type storageType) {
            var result = fsResult.Success;

            fsMetaProperty property;
            if ((result += GetProperty(instance, out property)).Failed) return result;

            object actualInstance = null;
            if ((result += Serializer.TryDeserialize(data, property.StorageType, ref actualInstance)).Failed)
                return result;

            property.Write(instance, actualInstance);
            return result;
        }

        internal override object CreateInstance(fsData data, Type storageType) {
            return fsMetaType.Get(Serializer.Config, storageType).CreateInstance();
        }
    }
}