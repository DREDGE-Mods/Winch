using System;
using System.Diagnostics;
using Winch;

/*
 * Winch console logs were adapted from the log console for the Outer Wilds Mods Loader (OWML) under MIT license
 * https://github.com/ow-mods/owml
 */

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

			if (duplicates.Length > 1)
			{
				currentProcess.Kill();
			}
			else
			{
				new LogSocketListener().Run();
			}
		}
	}
}