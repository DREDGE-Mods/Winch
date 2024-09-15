using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FullSerializer.Internal {
    internal class fsCyclicReferenceManager {
        // We use the default ReferenceEquals when comparing two objects because
        // custom objects may override equals methods. These overriden equals may
        // treat equals differently; we want to serialize/deserialize the object
        // graph *identically* to how it currently exists.
        class ObjectReferenceEqualityComparator : IEqualityComparer<object> {
            bool IEqualityComparer<object>.Equals(object x, object y) {
                return ReferenceEquals(x, y);
            }

            int IEqualityComparer<object>.GetHashCode(object obj) {
                return RuntimeHelpers.GetHashCode(obj);
            }

            internal static readonly IEqualityComparer<object> Instance = new ObjectReferenceEqualityComparator();
        }

        private Dictionary<object, int> _objectIds = new Dictionary<object, int>(ObjectReferenceEqualityComparator.Instance);
        private int _nextId;

        private Dictionary<int, object> _marked = new Dictionary<int, object>();
        private int _depth;

        internal void Enter() {
            _depth++;
        }

        internal bool Exit() {
            _depth--;

            if (_depth == 0) {
                _objectIds = new Dictionary<object, int>(ObjectReferenceEqualityComparator.Instance);
                _nextId = 0;
                _marked = new Dictionary<int, object>();
            }

            if (_depth < 0) {
                _depth = 0;
                throw new InvalidOperationException("Internal Error - Mismatched Enter/Exit");
            }

            return _depth == 0;
        }

        internal object GetReferenceObject(int id) {
            if (_marked.ContainsKey(id) == false) {
                throw new InvalidOperationException("Internal Deserialization Error - Object " +
                    "definition has not been encountered for object with id=" + id +
                    "; have you reordered or modified the serialized data? If this is an issue " +
                    "with an unmodified Full Serializer implementation and unmodified serialization " +
                    "data, please report an issue with an included test case.");
            }

            return _marked[id];
        }

        internal void AddReferenceWithId(int id, object reference) {
            _marked[id] = reference;
        }

        internal int GetReferenceId(object item) {
            int id;
            if (_objectIds.TryGetValue(item, out id) == false) {
                id = _nextId++;
                _objectIds[item] = id;
            }
            return id;
        }

        internal bool IsReference(object item) {
            return _marked.ContainsKey(GetReferenceId(item));
        }

        internal void MarkSerialized(object item) {
            int referenceId = GetReferenceId(item);

            if (_marked.ContainsKey(referenceId)) {
                throw new InvalidOperationException("Internal Error - " + item +
                    " has already been marked as serialized");
            }

            _marked[referenceId] = item;
        }
    }
}