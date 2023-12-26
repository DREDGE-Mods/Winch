using System;
using System.Diagnostics;
using System.Linq;
using Winch;

namespace WinchConsole
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Loading Winch console!");

			// Only allow one console to be open at a time
			var currentProcess = Process.GetCurrentProcess();
			var duplicates = Process.GetProcessesByName(currentProcess.ProcessName);

			// Let the existing console handle logs
			// For example, loading with the manager loads the game then it gets relaunched via Steam opening two consoles
			// However only the first console shows text
			if (duplicates.Length > 1)
			{
				currentProcess.Kill();
			}
			else
			{
				new LogSocketListener().Init();
			}
		}
	}
}