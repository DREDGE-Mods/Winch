using System.Collections.Generic;

namespace Winch.Data;

public class UnityObjectComparer : IEqualityComparer<UnityEngine.Object>, IComparer<UnityEngine.Object>
{
    private static readonly UnityObjectComparer<UnityEngine.Object> instance = new UnityObjectComparer<UnityEngine.Object>();

    public static UnityObjectComparer<UnityEngine.Object> Instance => instance;

    public bool Equals(UnityEngine.Object x, UnityEngine.Object y)
    {
        return x == y;
    }

    public int GetHashCode(UnityEngine.Object obj)
    {
        return obj.GetInstanceID();
    }

    public int Compare(UnityEngine.Object x, UnityEngine.Object y)
    {
        return x.GetInstanceID().CompareTo(y.GetInstanceID());
    }
}

public class UnityObjectComparer<T> : UnityObjectComparer, IEqualityComparer<T>, IComparer<T> where T : UnityEngine.Object
{
    private static readonly UnityObjectComparer<T> instance = new UnityObjectComparer<T>();

    public static new UnityObjectComparer<T> Instance => instance;

    public bool Equals(T x, T y)
    {
        return base.Equals(x, y);
    }

    public int GetHashCode(T obj)
    {
        return base.GetHashCode(obj);
    }

    public int Compare(T x, T y)
    {
        return base.Compare(x, y);
    }
}