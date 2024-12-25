using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WinchLauncher;

internal static class Launcher
{
    public static void Main(string[] args)
    {
        StartGame();

        // Keep the window open until the user presses a key
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Adapted from OWML https://github.com/ow-mods/owml/blob/master/src/OWML.Launcher/App.cs
    /// </summary>
    public static void StartGame()
    {
        string gamePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var dllPath = Path.Combine(gamePath, "DREDGE_Data/Managed/Assembly-CSharp.dll");

        void StartGameViaExe()
        {
            Console.WriteLine("Defaulting to running exe. If you bought DREDGE on Epic Games this will not work. Run the game from there directly");
            Process.Start(Path.Combine(gamePath, "DREDGE.exe"));
        }

        bool isEpic = false, isSteam = false;

        Assembly assembly = null;
        try
        {
            assembly = Assembly.LoadFrom(dllPath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to load assembly: " + e.Message);
            StartGameViaExe();
            return;
        }

        try
        {
            List<string> types;
            try
            {
                types = assembly.GetExportedTypes().Select(x => x.Name).ToList();
            }
            catch (ReflectionTypeLoadException ex)
            {
                // Apparently this can happen
                types = ex.Types.Where(x => x != null).Select(x => x.Name).ToList();
            }

            types.Sort();
            isEpic = types.Any(x => x == "EOSScreenshotStrategy");
            isSteam = types.Any(x => x == "SteamEntitlementStrategy");

            foreach (var type in types)
            {
                Console.WriteLine(type);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to load types from assembly: " + e.Message);
            StartGameViaExe();
            return;
        }

        try
        { 
            if (isEpic && !isSteam)
            {
                Console.WriteLine("Identified as Epic install");

                Process.Start(new ProcessStartInfo("com.epicgames.launcher://apps/8b454b47f5544fc6829cf0fed42ebae0%3Aeac6533129434f98a6b04a81cbcaf357%3A65c25644a2e0444d8766967a008b1d69?action=launch&silent=true") { UseShellExecute = true });
            }
            else if (!isEpic && isSteam)
            {
                Console.WriteLine("Identified as Steam install");

                Process.Start(new ProcessStartInfo("steam://rungameid/1562430") { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine("Couldn't identify vendor");

                StartGameViaExe();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to start process: " + e.Message);
            StartGameViaExe();
            return;
        }
    }
}
