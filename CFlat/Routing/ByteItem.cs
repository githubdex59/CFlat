using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace CFlat.Routing;

public class ByteItem : IEquatable<ByteItem>
{
    protected ByteItem()
    {

    }

    public ByteItem(string p)
    {
        _path = p;
    }

    internal string _path;

    public virtual byte[] Render(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
    {
        return new byte[0];
    }

    public virtual bool Equals(ByteItem other)
    {
        return Regex.IsMatch(_path, other._path);
    }

    public static bool operator ==(ByteItem a, ByteItem b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(ByteItem a, ByteItem b)
    {
        return !(a == b);
    }
}