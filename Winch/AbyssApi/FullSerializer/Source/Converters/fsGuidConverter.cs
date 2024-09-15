using System;

namespace FullSerializer.Internal {
    /// <summary>
    /// Serializes and deserializes guids.
    /// </summary>
    internal class fsGuidConverter : fsConverter {
        internal override bool CanProcess(Type type) {
            return type == typeof(Guid);
        }

        internal override bool RequestCycleSupport(Type storageType) {
            return false;
        }

        internal override bool RequestInheritanceSupport(Type storageType) {
            return false;
        }

        internal override fsResult TrySerialize(object instance, out fsData serialized, Type storageType) {
            var guid = (Guid)instance;
            serialized = new fsData(guid.ToString());
            return fsResult.Success;
        }

        internal override fsResult TryDeserialize(fsData data, ref object instance, Type storageType) {
            if (data.IsString) {
                instance = new Guid(data.AsString);
                return fsResult.Success;
            }

            return fsResult.Fail("fsGuidConverter encountered an unknown JSON data type");
        }

        internal override object CreateInstance(fsData data, Type storageType) {
            return new Guid();
        }
    }
}