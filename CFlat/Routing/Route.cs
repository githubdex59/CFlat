using CFlat.Html;

namespace CFlat.Routing;

/// <summary>
/// Used in Receiver to determine what to run when a request is received. 
/// </summary>
public class Route
{
    /// <summary>
    /// Receiver uses this to get the appropriate response, for
    /// example: client requests /foo/bar, Receiver searches
    /// through it's list of Routes and finds /foo/bar,
    /// then calls <paramref name="_page"/>.Render() 
    /// </summary>
    /// <example>/foo/bar</example>
    public string _path;
    public WebPage _page;
    public Method _method;

    
    public Route(string path, WebPage page, Method method)
    {
        _path = path;
        _page = page;
        _method = method;
    }
}