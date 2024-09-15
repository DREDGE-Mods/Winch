#if !NO_UNITY
using System;
using UnityEngine;
using UnityEngine.Events;

namespace FullSerializer {
    partial class fsConverterRegistrar {
        internal static Internal.Converters.UnityEvent_Converter Register_UnityEvent_Converter;
    }
}

namespace FullSerializer.Internal.Converters {
    // The standard FS reflection converter has started causing Unity to crash when processing
    // UnityEvent. We can send the serialization through JsonUtility which appears to work correctly
    // instead.
    //
    // We have to support legacy serialization formats so importing works as expected.
    internal class UnityEvent_Converter : fsConverter {
        internal override bool CanProcess(Type type) {
            return typeof(UnityEvent).Resolve().IsAssignableFrom(type) && type.IsGenericType == false;
        }

        internal override bool RequestCycleSupport(Type storageType) {
            return false;
        }

        internal override fsResult TryDeserialize(fsData data, ref object instance, Type storageType) {
            Type objectType = (Type)instance;

            fsResult result = fsResult.Success;
            instance = JsonUtility.FromJson(fsJsonPrinter.CompressedJson(data), objectType);
            return result;
        }

        internal override fsResult TrySerialize(object instance, out fsData serialized, Type storageType) {
            fsResult result = fsResult.Success;
            serialized = fsJsonParser.Parse(JsonUtility.ToJson(instance));
            return result;
        }
    }
}
#endif