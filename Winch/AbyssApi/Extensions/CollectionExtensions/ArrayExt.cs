using System;

namespace Winch.AbyssApi.Extensions.CollectionExtensions;

/// <summary>
/// Extensions for arrays
/// </summary>
public static class ArrayExt
{
    /// <summary>
    /// Retrieves all the elements that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="match"> The Predicate delegate that defines the conditions of the elements to search for.</param>
    /// <returns></returns>
    public static T[] FindAll<T>(this T[] array, Predicate<T> match) => Array.FindAll(array, match);
}