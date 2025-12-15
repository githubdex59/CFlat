using System.Net.Sockets;
using System.Text.RegularExpressions;
using static CFlat.Receiver;

namespace CFlat.Routing;

/// <summary>
/// Loads an image from disk.
///
/// <example>new Image("[\\w-]+\\.(?i:png)</example>
/// </summary>
public class Image : ByteItem
{
    protected string path = "./Static";
        
    protected byte[] GetContent()
    {
        string lPath = $"{path}{_path}";
        Console.WriteLine(lPath);

        if (System.IO.File.Exists(lPath))
            return System.IO.File.ReadAllBytes(lPath);
        return new byte[0];
    }
        

   /// <summary>
   /// The image name
   /// </summary>
    protected string _path;
   /// <summary>
   /// Defaults to image/png
   /// </summary>
    protected string _type;
    public Image(string path, string type = "image/png") : base(path)
    {
        _path = path;
        _type = type;
    }
    /// <summary>
    /// Sends headers
    /// </summary>
    /// <param name="stream">The NetworkStream(Set by Reciever)</param>
    /// <param name="headers">The request headers(Set by Reciever)</param>
    protected void DealWithHeaders(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
    {
        string[] rFirstLine = headers.rType.Split(" ");
        string httpV = rFirstLine.LastOrDefault();
        string contentType = headers.headers.GetValueOrDefault("Accept");
        string encoding = headers.headers.GetValueOrDefault("Acept-Encoding");
        
        _instance.SendHeaders(httpV, 200, "OK", _type
            , encoding, 0, ref stream);

    }
    
    public override byte[] Render(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
    {
        string[] rFirstLine = headers.rType.Split(" ");
        _path = rFirstLine[1];
        string type;
        
            
        DealWithHeaders(ref stream, headers);
            

        byte[] content = GetContent();
        return content;
    }

    public override bool Equals(ByteItem other)
    {
        return Regex.IsMatch(other._path, _path);
    }


    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return Equals((Image)obj);
    }

    public override int GetHashCode()
    {
        return _path.GetHashCode();
    }
}