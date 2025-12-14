using CFlat.Html;

namespace CFlat.Routing;

/// <summary>
/// Used in Receiver to determine what to run when a request is received. 
/// </summary>
public class Route : IEquatable<Route>
{
    /// <summary>
    /// Receiver uses this to get the appropriate response, for
    /// example: client requests /foo/bar, Receiver searches
    /// through it's list of Routes and finds /foo/bar,
    /// then calls <paramref name="_page"/>.Render() 
    /// </summary>
    /// <example>/foo/bar</example>
    public string _path;
    /// <summary>
    /// Your webpage
    /// </summary>
    public WebPage _page;
    /// <summary>
    /// Currently supported: GET
    /// </summary>
    public Method _method;

    
    public Route(string path, WebPage page, Method method)
    {
        _path = path;
        _page = page;
        _method = method;
    }
    
    /// <summary>
    /// DO NOT USE!
    ///
    /// This is for comparison purposes only!
    /// </summary>
    /// <param name="path"></param>
    /// <param name="method"></param>
    [Obsolete("This is for comparison purposes only!", false)]
    internal Route(string path, Method method) { _path = path; _method = method; }

    public static bool operator ==(Route x, Route y) { return x.Equals(y); }

    public static bool operator !=(Route x, Route y)
    {
        return !(x == y);
    }

    public bool Equals(Route? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path && _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return Equals((Route)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, (int)_method);
    }
}