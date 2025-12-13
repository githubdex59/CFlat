using System.Net;
using System.Net.Sockets;
using System.Text;
using CFlat.Routing;

namespace CFlat;

/// <summary>
/// The included web server.
/// </summary>
public class Receiver
{
    /// <summary>
    /// Thus only allowing one port to be opened
    /// </summary>
    public static Receiver _instance;
    private TcpListener _listener;
    private List<Route> _routes;
    
    public Receiver(int _port, string _ip = "0.0.0.0")
    {
        if (_instance != null) throw new Exception("Receiver already exists");
        
        _listener = new TcpListener(IPAddress.Parse(_ip), _port);
        _instance = this;
        _routes = new List<Route>();
    }

    public void Add(Route route)
    {
        _routes.Add(route);
    }

    public void Run()
    {
        if (_routes.Count == 0) throw new Exception("No routes found");
        
        _listener.Start();
        Console.WriteLine($"Listening on {_listener.LocalEndpoint.ToString()}");
        Thread th = new Thread(new ThreadStart(StartListen));
        th.Start();
    }

    private void StartListen()
    {
        while (true)
        {
            TcpClient client = _listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            
            SendHeaders("HTTP/1.1", 200, "OK", "text/html"
                , "text/html", 0, ref stream);
            string html = _routes[0]._page.Render();
            stream.Write(Encoding.UTF8.GetBytes(html), 0, html.Length);
            
            client.Close();
        }
    }
    
    private void SendHeaders(string? httpVersion, int statusCode, string statusMsg, string? contentType, string? contentEncoding,
        int byteLength, ref NetworkStream networkStream)
    {
        string responseHeaderBuffer = "";

        responseHeaderBuffer = $"HTTP/1.1 {statusCode} {statusMsg}\r\n" +
                               $"Connection: Keep-Alive\r\n" +
                               $"Date: {DateTime.UtcNow.ToString()}\r\n" +
                               $"Server: CFlat \r\n" +
                               $"Content-Encoding: {contentEncoding}\r\n" +
                               "X-Content-Type-Options: nosniff"+
                               $"Content-Type: {contentType ?? "text/plain"};v=b3\r\n\r\n";

        byte[] responseBytes = Encoding.UTF8.GetBytes(responseHeaderBuffer);
        networkStream.Write(responseBytes, 0, responseBytes.Length);
    }
}