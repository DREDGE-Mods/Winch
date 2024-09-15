using System.Collections.Generic;
using UnityEngine;

namespace Winch.AbyssApi.Extensions;

/// <summary>
/// Adds deconstruct methods to various value types
/// </summary>
public static class DeconstructExt
{
    /// <summary>
    /// Deconstruct a Rect
    /// </summary>
    public static void Deconstruct(this Rect rect, out float x, out float y, out float width, out float height)
    {
        x = rect.x;
        y = rect.y;
        width = rect.width;
        height = rect.height;
    }

    /// <summary>
    /// Deconstruct a Vector2
    /// </summary>
    public static void Deconstruct(this Vector2 vector2, out float x, out float y)
    {
        x = vector2.x;
        y = vector2.y;
    }

    /// <summary>
    /// Deconstruct a KeyValuePair
    /// </summary>
    public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> kvp, out T1 t1, out T2 t2)
    {
        t1 = kvp.Key;
        t2 = kvp.Value;
    }
}