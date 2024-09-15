using System;

namespace FullSerializer.Internal {
    /// <summary>
    /// Simple option type. This is akin to nullable types.
    /// </summary>
    internal struct fsOption<T> {
        private bool _hasValue;
        private T _value;

        internal bool HasValue {
            get { return _hasValue; }
        }
        internal bool IsEmpty {
            get { return _hasValue == false; }
        }
        internal T Value {
            get {
                if (IsEmpty) throw new InvalidOperationException("fsOption is empty");
                return _value;
            }
        }

        internal fsOption(T value) {
            _hasValue = true;
            _value = value;
        }

        internal static fsOption<T> Empty;
    }

    internal static class fsOption {
        internal static fsOption<T> Just<T>(T value) {
            return new fsOption<T>(value);
        }
    }
}