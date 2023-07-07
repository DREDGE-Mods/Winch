using Newtonsoft.Json;

namespace Winch.Logging
{
	public class LogMessage
	{
		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("level")]
		public string Level { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
