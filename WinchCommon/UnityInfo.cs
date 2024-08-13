using System.Diagnostics;
using System.Text;

namespace Winch
{
    /// <summary>
    /// Various information about the currently executing Unity player.
    /// </summary>
    public static class UnityInfo
    {
        private static readonly ManagerLookup[] ManagerVersionLookup =
        {
            new("globalgamemanagers", 0x14, 0x30),
            new("data.unity3d", 0x12),
            new("mainData", 0x14)
        };

        private static bool initialized;

        /// <summary>
        /// Path to the player executable.
        /// </summary>
        public static string PlayerPath { get; private set; }

        /// <summary>
        /// Path to the game data directory (directory that contains the game assets).
        /// </summary>
        public static string GameDataPath { get; private set; }

        /// <summary>
        /// Version of the Unity player
        /// </summary>
        public static UnityVersion Version { get; private set; }

        internal static void Initialize(string unityPlayerPath, string gameDataPath)
        {
            if (initialized)
                return;
            PlayerPath = Path.GetFullPath(unityPlayerPath ?? throw new ArgumentNullException(nameof(unityPlayerPath)));
            GameDataPath = Path.GetFullPath(gameDataPath ?? throw new ArgumentNullException(nameof(gameDataPath)));

            Version = DetermineVersion();
            initialized = true;
        }

        internal static void SetRuntimeUnityVersion(string version) => Version = UnityVersion.Parse(version);

        private static UnityVersion DetermineVersion()
        {
            // Try looking up first since it's more reliable
            foreach (var lookup in ManagerVersionLookup)
            {
                if (lookup.TryLookup(out var managerVersion))
                {
                    return managerVersion;
                }
            }

            var version = FileVersionInfo.GetVersionInfo(PlayerPath);
            var simpleVersion = new Version(version.FileVersion);
            return new UnityVersion((ushort)simpleVersion.Major, (ushort)simpleVersion.Minor,
                                       (ushort)simpleVersion.Build);
        }

        private class ManagerLookup
        {
            private readonly string filePath;
            private readonly int[] lookupOffsets;

            public ManagerLookup(string filePath, params int[] lookupOffsets)
            {
                this.filePath = filePath;
                this.lookupOffsets = lookupOffsets;
            }

            public bool TryLookup(out UnityVersion version)
            {
                var path = Path.Combine(GameDataPath, filePath);
                if (!File.Exists(path))
                {
                    version = default;
                    return false;
                }

                using var fs = File.OpenRead(path);
                foreach (var offset in lookupOffsets)
                {
                    var sb = new StringBuilder();
                    fs.Position = offset;

                    byte b;
                    while ((b = (byte)fs.ReadByte()) != 0)
                        sb.Append((char)b);

                    try
                    {
                        version = UnityVersion.Parse(sb.ToString());
                        return true;
                    }
                    catch (Exception e)
                    {
                        // Ignore
                    }
                }

                version = default;
                return false;
            }
        }
    }
}
