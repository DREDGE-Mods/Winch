using Mono.Cecil;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Winch.Core;
using CsvHelper;

namespace Winch.Util
{
    public static class ReflectionUtil
    {
        public static string GetAssemblyDirectoryPath(Assembly assembly)
        {
            return Path.GetDirectoryName(assembly.Location);
        }

        public static string GetAssemblyDirectoryName(Assembly assembly)
        {
            return Path.GetFileName(GetAssemblyDirectoryPath(assembly));
        }

        /// <summary>
        /// Gets the relevant mod assembly
        /// </summary>
        public static Assembly GetRelevantAssembly()
        {
            StackTrace trace = new StackTrace();

            var frames = trace.GetFrames();
            try
            {
                foreach (var frame in frames)
                {
                    var assembly = frame.GetMethod().DeclaringType.Assembly;
                    if (ModAssemblyLoader.GetAssemblies().Contains(assembly))
                        return assembly;
                }
            }
            catch { }

            return WinchCore.WinchAssembly;
        }

        internal static ModAssembly GetRelevantModAssembly()
        {
            StackTrace trace = new StackTrace();

            var frames = trace.GetFrames();
            try
            {
                foreach (var frame in frames)
                {
                    var assembly = frame.GetMethod().DeclaringType.Assembly;
                    var modAssembly = ModAssemblyLoader.GetModForAssembly(assembly);
                    if (modAssembly != null)
                        return modAssembly;
                }
            }
            catch { }

            return null;
        }


        public static string GetTypeName(this Type t, TypeNameAssemblyFormatHandling assemblyFormat)
        {
            string fullyQualifiedTypeName = ReflectionUtil.GetFullyQualifiedTypeName(t);
            if (assemblyFormat == TypeNameAssemblyFormatHandling.Simple)
            {
                return ReflectionUtil.RemoveAssemblyDetails(fullyQualifiedTypeName);
            }
            if (assemblyFormat != TypeNameAssemblyFormatHandling.Full)
            {
                throw new ArgumentOutOfRangeException();
            }
            return fullyQualifiedTypeName;
        }

        private static string GetFullyQualifiedTypeName(Type t)
        {
            return t.AssemblyQualifiedName;
        }

        private static string RemoveAssemblyDetails(string fullyQualifiedTypeName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            bool flag2 = false;
            foreach (char c in fullyQualifiedTypeName)
            {
                if (c != ',')
                {
                    if (c == '[' || c == ']')
                    {
                        flag = false;
                        flag2 = false;
                        stringBuilder.Append(c);
                    }
                    else if (!flag2)
                    {
                        stringBuilder.Append(c);
                    }
                }
                else if (!flag)
                {
                    flag = true;
                    stringBuilder.Append(c);
                }
                else
                {
                    flag2 = true;
                }
            }
            return stringBuilder.ToString();
        }

        public static Type GetMemberUnderlyingType(this MemberInfo member)
        {
            if (member == null) throw new ArgumentNullException("member");

            MemberTypes memberTypes = member.MemberType;
            if (memberTypes <= MemberTypes.Field)
            {
                if (memberTypes == MemberTypes.Event)
                {
                    return ((EventInfo)member).EventHandlerType;
                }
                if (memberTypes == MemberTypes.Field)
                {
                    return ((FieldInfo)member).FieldType;
                }
            }
            else
            {
                if (memberTypes == MemberTypes.Method)
                {
                    return ((MethodInfo)member).ReturnType;
                }
                if (memberTypes == MemberTypes.Property)
                {
                    return ((PropertyInfo)member).PropertyType;
                }
            }
            throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo, EventInfo or MethodInfo", "member");
        }
    }
}
