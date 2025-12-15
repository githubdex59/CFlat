using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using CFlat.Html;
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
    private List<ByteItem> _byteItems;
    
    public Receiver(int _port, string _ip = "0.0.0.0")
    {
        if (_instance != null) throw new Exception("Receiver already exists");
        
        _listener = new TcpListener(IPAddress.Parse(_ip), _port);
        _instance = this;
        _routes = new List<Route>();
        _byteItems = new List<ByteItem>();
    }

    public void Add(Route route)
    {
        _routes.Add(route);
    }

    public void Add(ByteItem byteItem)
    {
        _byteItems.Add(byteItem);
    }

    public void Run()
    {
        if (_routes.Count == 0) throw new Exception("No routes found");
        
        // \todo implement multithreading
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
            
            //read request 
            byte[] requestBytes = new byte[1024];
            int bytesRead = stream.Read(requestBytes, 0, requestBytes.Length);

            string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
            var headers = ParseHeaders(request);

            Console.WriteLine(request);
            string[] rFirstLine = headers.rType.Split(" ");
            string httpV = rFirstLine.LastOrDefault();
            string contentType = headers.headers.GetValueOrDefault("Accept");
            string encoding = headers.headers.GetValueOrDefault("Acept-Encoding");

            Method method;
            if (!request.StartsWith("GET"))
            {
                SendHeaders(httpV, 405, "METHOD NOT ALLOWED", contentType
                    , encoding, 0, ref stream);
                client.Close();
                continue;
            }
            else
            {
                method = Method.GET;
            }

            if (_byteItems.Contains(new ByteItem(rFirstLine[1])))
            {
                try
                {
                    int index = _byteItems.IndexOf(new ByteItem(rFirstLine[1]));
                    byte[] data = _byteItems[index].Render(ref stream, headers);
                    stream.Write(data, 0, data.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (_routes.Contains(new Route(rFirstLine[1], method)))
            {

                try
                {
                    int index = _routes.IndexOf(new Route(rFirstLine[1], method));
                    string html = _routes[index]._page.Render(ref stream, headers);
                    
                    stream.Write(Encoding.ASCII.GetBytes(html), 0, html.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                SendHeaders("HTTP/1.1", 404, "NOT FOUND", contentType
                    , encoding, 0, ref stream);
            }
            client.Close();
        }
    }
    
    internal void SendHeaders(string? httpVersion, int statusCode, string statusMsg, string? contentType, string? contentEncoding,
        int byteLength, ref NetworkStream networkStream)
    {
        string responseHeaderBuffer = "";
        
        responseHeaderBuffer = $"{httpVersion ?? "HTTP/1.1"} {statusCode} {statusMsg}\r\n" +
                               $"Connection: Keep-Alive\r\n" +
                               $"Date: {DateTime.UtcNow.ToString()}\r\n" +
                               $"Server: CFlat \r\n" +
                               $"Content-Encoding: {contentEncoding}\r\n" +
                               $"X-Clacks-Overhead \"GNU Terry Pratchett\"\n" +
                               "X-Content-Type-Options: nosniff\n"+
                               $"Content-Type: {contentType};v=b3\r\n\r\n";

        Console.WriteLine(responseHeaderBuffer);
        byte[] responseBytes = Encoding.UTF8.GetBytes(responseHeaderBuffer);
        
        networkStream.Write(responseBytes, 0, responseBytes.Length);
    }

    private (Dictionary<string, string> headers, string rType) ParseHeaders(string headerString)
    {
        var headerLines = headerString.Split("\r\n");
        string firstLine = headerLines[0];
        var headerValues = new Dictionary<string, string>();
        foreach (var headerLine in headerLines)
        {
            var detail = headerLine.Trim();
            var delimiter = detail.IndexOf(':');
            if (delimiter >= 0)
            {
                var name = headerLine.Substring(0, delimiter).Trim();
                var value = headerLine.Substring(delimiter + 1).Trim();
                headerValues.Add(name, value);
            }
        }
        return (headerValues, firstLine);
    }
}