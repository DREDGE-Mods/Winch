using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FullSerializer;
using HarmonyLib;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Core;

namespace Winch.AbyssApi.Generators;

internal class ClassGenerator
{
    internal static readonly fsSerializer Serializer = new();

    //generate a c# class source file (with already filled-in values) from a scriptableobject
    private static string Generate<T>(T obj, Type baseType, string @namespace) where T : ScriptableObject
    {
        try
        {
            var type = typeof(T);

            var objname = obj.name.Replace(" ", "_").Replace("-", "_").Replace(".", "_").Replace("(", "_").Replace(")", "_");

            var sb = new StringBuilder();

            sb.AppendLine($"namespace {@namespace};");

            sb.AppendLine($"public static class {objname}");

            sb.AppendLine("{");

            var instanceName = objname + "Instance";

            sb.AppendLine("    public static " + typeof(T).FullName + " " + instanceName + " = " +
                          $"({typeof(T).FullName})" +
                          $"System.Linq.Enumerable.First(ScriptableObjectInstances.{baseType.Name}s, x => x.name == \"{objname}\");");

            foreach (var field in type.GetFields(AccessTools.all))
            {
                var fieldVal = field.GetValue(obj);
                string value = string.Empty;

                if (IsNumericType(field.FieldType) || field.FieldType.IsPrimitive)
                {
                    value = fieldVal.ToString().ToLowerInvariant();
                    if (field.FieldType == typeof(float))
                        value += "f";
                    if (field.FieldType == typeof(decimal))
                        value += "m";
                    if (field.FieldType == typeof(double))
                        value += "d";
                }
                else if (field.FieldType.IsEnum)
                {
                    var enumVal = (Enum)fieldVal;

                    value = field.FieldType.CSharpName() + "." + Enum.Format(field.FieldType, fieldVal, "G");

                    if (!Enum.GetNames(field.FieldType).Contains(Enum.Format(field.FieldType, fieldVal, "G")))
                    {
                        value = "(" + field.FieldType.CSharpName() + ")" + Enum.Format(field.FieldType, fieldVal, "G");
                    }

                    //make the enum use the | operator if it has flags
                    if (field.FieldType.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
                    {
                        var added = new List<string>();
                        foreach (object enumval in Enum.GetValues(field.FieldType))
                        {
                            string name = enumval.ToString();
                            if (added.Contains(name))
                                continue;
                            if (enumVal.HasFlag((Enum)enumval))
                            {
                                added.Add(field.FieldType.CSharpName() + "." + name);
                            }
                        }

                        value = string.Join(" | ", added);
                    }
                }

                if (field.FieldType == typeof(string))
                    value = $"\"{value}\"";

                if (field.FieldType == typeof(Vector3))
                {
                    var vector3 = (Vector3)fieldVal;
                    value = $"new UnityEngine.Vector3({vector3.x}f, {vector3.y}f, {vector3.z}f)";
                }

                if (field.FieldType == typeof(Vector2))
                {
                    var vector2 = (Vector2)fieldVal;
                    value = $"new UnityEngine.Vector2({vector2.x}f, {vector2.y}f)";
                }

                if (field.FieldType == typeof(Color))
                {
                    var color = (Color)fieldVal;
                    value = $"new UnityEngine.Color({color.r}f, {color.g}f, {color.b}f, {color.a}f)";
                }

                if (field.FieldType.IsClass && field.FieldType != typeof(string))
                {
                    sb.AppendLine("     ///<json>");


                    if (fieldVal is UnityEngine.Object and not MonoBehaviour and not ScriptableObject)
                    {
                        sb.AppendLine("     /// Serialization does not support this type.");

                        sb.AppendLine("     /// </json>");
                        sb.AppendLine(
                            $"    public static {field.FieldType.CSharpName(true)} {field.Name} = {instanceName}.{field.Name};");
                        continue;
                    }

                    if (fieldVal is null)
                    {
                        sb.AppendLine("     /// null");
                        sb.AppendLine("     /// </json>");
                        sb.AppendLine($"    public static {field.FieldType.CSharpName(true)} {field.Name} = null;");
                        continue;
                    }

                    string json;
                    try
                    {
                        Serializer.TrySerialize(fieldVal, out var data).AssertSuccessWithoutWarnings();

                        // emit the data via JSON

                        json = fsJsonPrinter.PrettyJson(data);
                    }
                    catch (Exception e)
                    {
                        sb.AppendLine("     /// Serialization does not support this type.");
                        sb.AppendLine("     /// Exception: " + e.Message);
                        sb.AppendLine("     /// </json>");
                        sb.AppendLine(
                            $"    public static {field.FieldType.CSharpName(true)} {field.Name} = {instanceName}.{field.Name};");
                        continue;
                    }

                    json = "     /// " + json;

                    json = json.Replace("\n", "\n     ///");

                    sb.AppendLine(json);

                    sb.AppendLine("     ///</json>");
                    sb.AppendLine(
                        $"    public static {field.FieldType.CSharpName(true)} {field.Name} = {instanceName}.{field.Name};");

                    continue;
                }


                sb.AppendLine($"    public static {field.FieldType.CSharpName(true)} {field.Name} = {value};");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
        catch (Exception e)
        {
            WinchCore.Log.Error(e.ToString());
            throw;
        }
    }

    private static readonly HashSet<Type> NumericTypes = new()
    {
        typeof(int),
        typeof(uint),
        typeof(double),
        typeof(decimal),
        typeof(float),
        typeof(long),
        typeof(ulong),
        typeof(short),
        typeof(ushort),
        typeof(byte),
        typeof(sbyte),
    };

    private static bool IsNumericType(Type type)
    {
        return NumericTypes.Contains(type) || NumericTypes.Contains(Nullable.GetUnderlyingType(type));
    }

    public static IEnumerable<Type> GetInheritanceHierarchy
        (Type type)
    {
        for (var current = type; current != null; current = current.BaseType)
            yield return current;
    }

    internal static void Export<T>(T obj) where T : ScriptableObject
    {
        try
        {
            var typeHierarchy = new StringBuilder();

            var inheritanceHierarchy = GetInheritanceHierarchy(typeof(T)).Where(x=> x.IsSubclassOf(typeof(SerializedScriptableObject))).Reverse().ToList();

            if(inheritanceHierarchy.Count == 0)
                inheritanceHierarchy = GetInheritanceHierarchy(typeof(T))
                    .Where(x => x.IsSubclassOf(typeof(ScriptableObject))).Reverse().ToList();

            if (inheritanceHierarchy.Count == 0)
                throw new InvalidDataException($"Type {typeof(T).FullName} does not inherit from ScriptableObject or SerializedScriptableObject");

            var baseType = inheritanceHierarchy[0];

            for (var i = 0; i < inheritanceHierarchy.Count; i++)
            {
                var type = inheritanceHierarchy[i];
                typeHierarchy.Append(type.Name + 's');
                if (i != inheritanceHierarchy.Count - 1)
                    typeHierarchy.Append(@"\");
            }

            var dir = Path.Combine(@"C:\Users\gjguz\source\repos\DREDGE\Winch\Winch\AbyssApi\GameReferences\", typeHierarchy.ToString());
            Directory.CreateDirectory(dir);
            File.WriteAllText(Path.Combine(dir, $"{obj.name}.cs"),
                Generate(obj, baseType, "Winch.AbyssApi.GameReferences." + typeHierarchy.ToString().Replace(@"\", ".")));
        }
        catch (Exception e)
        {
            WinchCore.Log.Error(e.ToString());
            throw;
        }
    }
}