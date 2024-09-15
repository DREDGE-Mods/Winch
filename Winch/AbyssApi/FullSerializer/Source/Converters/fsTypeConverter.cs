using System;

#if !UNITY_EDITOR && UNITY_WSA
// For System.Reflection.TypeExtensions
using System.Reflection;
#endif

namespace FullSerializer.Internal {
    internal class fsTypeConverter : fsConverter {
        internal override bool CanProcess(Type type) {
            return typeof(Type).IsAssignableFrom(type);
        }

        internal override bool RequestCycleSupport(Type type) {
            return false;
        }

        internal override bool RequestInheritanceSupport(Type type) {
            return false;
        }

        internal override fsResult TrySerialize(object instance, out fsData serialized, Type storageType) {
            var type = (Type)instance;
            serialized = new fsData(type.FullName);
            return fsResult.Success;
        }

        internal override fsResult TryDeserialize(fsData data, ref object instance, Type storageType) {
            if (data.IsString == false) {
                return fsResult.Fail("Type converter requires a string");
            }

            instance = fsTypeCache.GetType(data.AsString);
            if (instance == null) {
                return fsResult.Fail("Unable to find type " + data.AsString);
            }
            return fsResult.Success;
        }

        internal override object CreateInstance(fsData data, Type storageType) {
            return storageType;
        }
    }
}