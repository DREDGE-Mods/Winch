using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using Winch.Config;
using Winch.Core;

namespace Winch.Logging
{
	public class Logger
    {
        private LogFile? _log;
        private LogFile? _latestLog;

        private bool _writeLogsToFile;
		private bool _writeLogsToConsole;
        private LogLevel? _minLogLevel;

		private LogSocket? _logSocket;

		public string LogConsoleExe => Path.Combine(WinchCore.WinchInstallLocation, "WinchConsole.exe");

        public Logger()
        {
            _writeLogsToFile = WinchConfig.GetProperty("WriteLogsToFile", true);
            if (_writeLogsToFile)
			{
				_minLogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), WinchConfig.GetProperty("LogLevel", "DEBUG"));
				_log = new LogFile();
				_latestLog = new LogFile("latest.log");
				CleanupLogs();
			}

			_writeLogsToConsole = WinchConfig.GetProperty("WriteLogsToConsole", true);

			if (_writeLogsToConsole)
			{
				// Find an avialable port for the logs
				var listener = new TcpListener(IPAddress.Loopback, 0);
				listener.Start();
				var port = ((IPEndPoint)listener.LocalEndpoint).Port;
				listener.Stop();

				// Console exe will get the port from the WinchConfig file
				WinchConfig.SetProperty("LogPort", $"{port}");

				Info($"Writing logs to port {port}");

				try
				{
					Info($"Starting console at path {LogConsoleExe}");
					Process.Start(LogConsoleExe);

					_logSocket = new LogSocket(this, port);
				}
				catch (Exception e)
				{
					Error($"Could not start console : {e}");
				}
			}

			Info($"Writing logs to file: {_writeLogsToFile}. Writing logs to console: {_writeLogsToConsole}.");
        }

        private static void CleanupLogs()
        {
            Regex logFileRegex = new Regex(@"\d{4}-\d{2}-\d{2}-\d{2}_\d{2}\.log");
            string logBasePath = WinchConfig.GetProperty("LogsFolder", "Logs");
            string[] allFiles = Directory.GetFiles(logBasePath);

            Array.Sort(allFiles);
            List<string> logFiles = new List<string>();
            foreach (string file in allFiles)
            {
                string filename = Path.GetFileName(file);
                if (logFileRegex.IsMatch(filename))
                    logFiles.Add(file);
            }

            long targetLogCount = WinchConfig.GetProperty("MaxLogFiles", 10L) - 1;
            while (logFiles.Count > targetLogCount)
            {
                File.Delete(logFiles[0]);
                logFiles.RemoveAt(0);
            }
        }

        private void Log(LogLevel level, string message)
        {
            Log(level, message, GetSourceTag());
        }

        private void Log(LogLevel level, string message, string source)
        {
			if (level < _minLogLevel)
				return;

			if (_writeLogsToConsole)
			{
				_logSocket?.WriteToSocket(new LogMessage()
				{
					Level = level,
					Message = message,
					Source = source
				});
			}

            if (_writeLogsToFile)
			{
				string logMessage = $"[{GetLogTimestamp()}] [{source}] [{level}] : {message}";
				_log?.Write(logMessage);
				_latestLog?.Write(logMessage);
			}
        }

        private string GetLogTimestamp()
        {
            DateTime now = DateTime.Now;
            return $"{now.Year:0000}-{now.Month:00}-{now.Day:00} {now.Hour:00}:{now.Minute:00}:{now.Second:00}";
        }

        private string GetSourceTag()
        {
            StackFrame[] frames = new StackTrace().GetFrames() ?? throw new InvalidOperationException("No stack trace available.");
            string? callingClass = "";
            string? callingMethod = "";
            string? callingAssembly = "";
            for(int i = 1; i < frames?.Length; i++)
            {
                callingMethod = frames[i].GetMethod().Name;
                callingClass = frames[i].GetMethod().ReflectedType?.Name;
                callingAssembly = frames[i].GetMethod().ReflectedType?.Assembly.GetName().Name;
                if(callingClass != null && !callingClass.Equals("Logger"))
                    break;
            }

            string sourceTag = $"{callingAssembly}";
            if (WinchConfig.GetProperty("DetailedLogSources", false))
                sourceTag += $".{callingClass}.{callingMethod}";

            return sourceTag;
        }



        internal void Unity(object message, string source) { Log(LogLevel.UNITY, message.ToString(), source); }
        public void Debug(object message) { Log(LogLevel.DEBUG, message.ToString()); }
        public void Info(object message) { Log(LogLevel.INFO, message.ToString()); }
        public void Warn(object message) { Log(LogLevel.WARN, message.ToString()); }
        public void Error(object message) { Log(LogLevel.ERROR, message.ToString()); }
    }
}
