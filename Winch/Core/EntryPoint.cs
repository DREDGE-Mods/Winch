using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winch.Core
{
    internal static class EntryPoint
    {
        /// <summary>
        /// The main entrypoint, called from Doorstop.
        /// </summary>
        public static void Main()
        {
            // We set it to the current directory first as a fallback, but try to use the same location as the .exe file.
            var silentExceptionLog = $"preloader_{DateTime.Now:yyyyMMdd_HHmmss_fff}.log";

            try
            {
                var gamePath = Path.GetDirectoryName(EnvVars.DOORSTOP_PROCESS_PATH) ?? ".";
                silentExceptionLog = Path.Combine(gamePath, silentExceptionLog);

                WinchCore.Initialize();
            }
            catch (Exception ex)
            {
                File.WriteAllText(silentExceptionLog, ex.ToString());
            }
        }
    }
}
