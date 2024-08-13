using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Winch.Core;

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
    }
}
