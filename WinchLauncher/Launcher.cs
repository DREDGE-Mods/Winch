using System;
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
    }

    /// <summary>
    /// Adapted from OWML https://github.com/ow-mods/owml/blob/master/src/OWML.Launcher/App.cs
    /// </summary>
    /// <param name="gamePath"></param>
    public static void StartGame()
    {
        string gamePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var dllPath = Path.Combine(gamePath, "DREDGE_Data/Managed/Assembly-CSharp.dll");

        void StartGameViaExe() => Process.Start(Path.Combine(gamePath, "DREDGE.exe"));

        Assembly assembly = null;
        try
        {
            assembly = Assembly.LoadFrom(dllPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            StartGameViaExe();
            return;
        }

        try
        {
            var types = assembly.GetTypes().Select(x => x.Name).ToList();
            types.Sort();
            var isEpic = types.Any(x => x == "EOSScreenshotStrategy");
            var isSteam = types.Any(x => x == "SteamEntitlementStrategy");

            foreach (var type in types)
            {
                Console.WriteLine(type);
            }

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
            Console.WriteLine(e.Message);
            StartGameViaExe();
        }

        // Keep the window open until the user presses a key
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
