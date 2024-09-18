using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Winch.Logging;

public class LogConsole
{

	public LogConsole()
	{
		BepInEx.ConsoleManager.Initialize(false);
		BepInEx.ConsoleManager.CreateConsole();
		BepInEx.ConsoleManager.SetConsoleTitle("Winch Console");
	}

	public void WriteToConsole(string logMessage)
	{
		if (BepInEx.ConsoleManager.ConsoleActive)
		{
			BepInEx.ConsoleManager.ConsoleStream.WriteLine(logMessage);
		}
	}

	public void Close()
	{
		Thread.Sleep(TimeSpan.FromSeconds(1));
		BepInEx.ConsoleManager.DetachConsole();
	}
}