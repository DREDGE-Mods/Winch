using System;
using System.IO;
using System.Reflection;

namespace Winch.EntryPoint;

public class EntryPoint
{
    public static void Main()
    {
        if(File.Exists("WinchError.txt"))
        {
            File.Delete("WinchError.txt");
        }

        try
        {
            var winchAsm = Assembly.LoadFrom("Winch\\Winch.dll");
            winchAsm.GetType("Winch.Core.EntryPoint").GetMethod("Main").Invoke(null, null);
        }
        catch (Exception e)
        {
            File.WriteAllText("WinchError.txt", e.ToString());
        }
    }
}