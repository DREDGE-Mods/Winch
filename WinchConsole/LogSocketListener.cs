using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Winch.Config;
using Winch.Logging;

namespace Winch;

public class LogSocketListener
{
    private const string Separator = "\n--------------------------------";
    private const int BufferSize = 262144;
    private static int _port;
    private static TcpListener _server;
    private bool _hasReceivedFatalMessage;

    public LogSocketListener()
    {

    }

    public void Run()
    {
        var portStr = WinchConfig.GetProperty("LogPort", string.Empty);

        if (string.IsNullOrEmpty(portStr) || !int.TryParse(portStr, out _port))
        {
            return;
        }

        WriteByType(LogLevel.INFO, $"Setting up socket listener {_port}");
        try
        {
            ListenToSocket();
        }
        catch (SocketException ex)
        {
            WriteByType(LogLevel.ERROR, $"Error in socket listener: {ex.SocketErrorCode} - {ex}");
        }
        catch (Exception ex)
        {
            WriteByType(LogLevel.ERROR, $"Error while listening: {ex}");
        }
        finally
        {
            _server?.Stop();
        }
    }

    private void ListenToSocket()
    {
        var localAddress = IPAddress.Parse(Constants.IP);

        _server = new TcpListener(localAddress, _port);
        _server.Start();
        WriteByType(LogLevel.INFO, $"Connected to local {localAddress}:{_port}");

        var bytes = new byte[BufferSize];

        while (true)
        {
            var client = _server.AcceptTcpClient();

            WriteByType(LogLevel.INFO, "Console connected to socket!");

            var stream = client.GetStream();

            int i;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                ProcessMessage(bytes, i);
            }

            WriteByType(LogLevel.INFO, "Closing client!");
            client.Close();
        }
    }

    private void ProcessMessage(byte[] bytes, int count)
    {
        var message = Encoding.UTF8.GetString(bytes, 0, count);

        var jsons = SplitMessage(message);

        foreach (var json in jsons)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            ProcessJson(json);
        }
    }

    /// <summary>
    /// Message can come in containing multiple JSON objects, we have to split them up into separate strings to parse
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private string[] SplitMessage(string message)
    {
        var jsons = new List<string>();
        var jsonStart = 0;
        var bracketCount = 0;
        for (int i = 0; i < message.Length; i++)
        {
            if (message[i] == '{')
            {
                bracketCount++;

            }
            else if (message[i] == '}')
            {
                bracketCount--;
                if (bracketCount == 0)
                {
                    var json = message.Substring(jsonStart, i + 1 - jsonStart);
                    jsons.Add(json);
                    jsonStart = i + 1;
                }
            }
        }

        return jsons.Any() ? jsons.ToArray() : new string[] { message };
    }

    private void ProcessJson(string json)
    {
        LogMessage data;
        try
        {
            data = JsonConvert.DeserializeObject<LogMessage>(json) ?? throw new NullReferenceException();
        }
        catch (Exception ex)
        {
            WriteByType(LogLevel.WARN, $"Failed to process following message:{Separator}\n{json}{Separator}");
            WriteByType(LogLevel.WARN, $"Reason: {ex}");
            return;
        }

        var nameTypePrefix = $"[{data.Source}] : ";

        var messageData = data.Message;
        messageData = messageData.Replace("\n", $"\n{new string(' ', nameTypePrefix.Length)}");

        WriteByType(data.Level, $"{nameTypePrefix}{messageData}");
    }

    public static void WriteByType(LogLevel type, string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            return;
        }

        Console.ForegroundColor = type switch
        {
            LogLevel.ERROR => ConsoleColor.Red,
            LogLevel.WARN => ConsoleColor.Yellow,
            LogLevel.DEBUG => ConsoleColor.DarkGray,
            _ => ConsoleColor.White
        };

        Console.WriteLine(line);
    }
}