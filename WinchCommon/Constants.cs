using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Winch")]
[assembly: InternalsVisibleToAttribute("WinchConsole")]

namespace Winch;

public static class Constants
{
	public const string IP = "127.0.0.1";

	public const string WinchConfigFileName = "WinchConfig.json";

	public const string WinchDefaultConfigFileName = "WinchDefaultConfig.json";

	public const string ModConfigFileName = "config.json";

	public const string ModDefaultConfigFileName = "default_config.json";

	public const string ModManifestFileName = "mod_meta.json";

	internal const string OldModConfigFileName = "Config.json";

	internal const string OldModDefaultConfigFileName = "DefaultConfig.json";
}
