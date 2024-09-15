using System;
using System.Collections.Generic;
using System.Reflection;

namespace FullSerializer.Internal {
    internal class fsKeyValuePairConverter : fsConverter {
        internal override bool CanProcess(Type type) {
            return
                type.Resolve().IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);
        }

        internal override bool RequestCycleSupport(Type storageType) {
            return false;
        }

        internal override bool RequestInheritanceSupport(Type storageType) {
            return false;
        }

        internal override fsResult TryDeserialize(fsData data, ref object instance, Type storageType) {
            var result = fsResult.Success;

            fsData keyData, valueData;
            if ((result += CheckKey(data, "Key", out keyData)).Failed) return result;
            if ((result += CheckKey(data, "Value", out valueData)).Failed) return result;

            var genericArguments = storageType.GetGenericArguments();
            Type keyType = genericArguments[0], valueType = genericArguments[1];

            object keyObject = null, valueObject = null;
            result.AddMessages(Serializer.TryDeserialize(keyData, keyType, ref keyObject));
            result.AddMessages(Serializer.TryDeserialize(valueData, valueType, ref valueObject));

            instance = Activator.CreateInstance(storageType, keyObject, valueObject);
            return result;
        }

        internal override fsResult TrySerialize(object instance, out fsData serialized, Type storageType) {
            PropertyInfo keyProperty = storageType.GetDeclaredProperty("Key");
            PropertyInfo valueProperty = storageType.GetDeclaredProperty("Value");

            object keyObject = keyProperty.GetValue(instance, null);
            object valueObject = valueProperty.GetValue(instance, null);

            var genericArguments = storageType.GetGenericArguments();
            Type keyType = genericArguments[0], valueType = genericArguments[1];

            var result = fsResult.Success;

            fsData keyData, valueData;
            result.AddMessages(Serializer.TrySerialize(keyType, keyObject, out keyData));
            result.AddMessages(Serializer.TrySerialize(valueType, valueObject, out valueData));

            serialized = fsData.CreateDictionary();
            if (keyData != null) serialized.AsDictionary["Key"] = keyData;
            if (valueData != null) serialized.AsDictionary["Value"] = valueData;

            return result;
        }
    }
}