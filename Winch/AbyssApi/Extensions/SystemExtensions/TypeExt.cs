using System;
using System.Reflection;

namespace Winch.AbyssApi.Extensions.SystemExtensions;

/// <summary>
/// Extensions for Type
/// </summary>
public static class TypeExt
{
    /// <summary>
    /// Get all methods with the specified method name
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <returns></returns>
    public static MethodInfo[] GetMethods(this Type type, string methodName)
    {
        return type.GetMethods().FindAll(method => method.Name == methodName);
    }
}