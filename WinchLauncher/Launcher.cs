using System.Diagnostics;
using System.Reflection;

namespace WinchLauncher;

internal static class Launcher
{
    public static void Main(string[] args)
    {
        StartGame(args[0]);
    }

    /// <summary>
    /// Adapted from OWML https://github.com/ow-mods/owml/blob/master/src/OWML.Launcher/App.cs
    /// </summary>
    /// <param name="gamePath"></param>
    public static void StartGame(string gamePath)
    {
        var dllPath = Path.Combine(gamePath, "DREDGE_Data/Managed/Assembly-CSharp.dll");

        void StartGameViaExe() => Process.Start(Path.Combine(gamePath, "DREDGE.exe"));

        Assembly assembly = null;
        try
        {
            assembly = Assembly.LoadFrom(dllPath);
        }
        catch
        {
            StartGameViaExe();
            return;
        }

        var types = assembly.GetTypes();
        var isEpic = types.Any(x => x.Name == "EpicEntitlementRetriever");
        var isSteam = types.Any(x => x.Name == "SteamEntitlementRetriever");

        if (isEpic && !isSteam)
        {
            Process.Start("com.epicgames.launcher://apps/8b454b47f5544fc6829cf0fed42ebae0%3Aeac6533129434f98a6b04a81cbcaf357%3A65c25644a2e0444d8766967a008b1d69?action=launch&silent=true");
        }
        else if (!isEpic && isSteam)
        {
            Process.Start("steam://rungameid/1562430");
        }
        else
        {
            StartGameViaExe();
        }
    }
}
