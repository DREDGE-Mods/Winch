using Newtonsoft.Json;
using WinchCommon;

namespace Winch.Logging
{
	public class LogMessage
	{
		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("level")]
		public LogLevel Level { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
