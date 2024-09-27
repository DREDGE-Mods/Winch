using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Winch.Logging;

public class LogSocket
{
    private Socket _socket;
    private readonly int _port;
    private readonly Logger _logger;

    public LogSocket(Logger logger, int port)
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _port = port;
        _logger = logger;
    }

    public void WriteToSocket(LogMessage logMessage)
    {
        if (_socket == null)
        {
            return;
        }

        if (!_socket.Connected)
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(Constants.IP), _port);
            try
            {
                _socket?.Connect(endPoint);
            }
            catch (Exception ex)
            {
                _socket = null;
                _logger.Error($"Could not connect to console at {Constants.IP}:{_port} - {ex}");
            }
        }

        try
        {
            _socket?.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(logMessage)));
        }
        catch (SocketException) { }
    }

    public void Close()
    {
        Thread.Sleep(TimeSpan.FromSeconds(1));
        _socket?.Close();
    }
}
