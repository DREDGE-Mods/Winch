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

	[DllImport("kernel32.dll")]
	static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

	[DllImport("kernel32.dll")]
	static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int mode);

	[DllImport("kernel32.dll")]
	static extern IntPtr GetStdHandle(int handle);


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