using System.Net;
using System.Net.Sockets;

namespace CFlat;

public class Receiver
{
    private TcpListener _listener;
    
    public Receiver(int _port, string _ip = "0.0.0.0")
    {
        _listener = new TcpListener(IPAddress.Parse(_ip), _port);
    }
}