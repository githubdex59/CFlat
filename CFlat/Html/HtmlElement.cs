using System.Net.Sockets;

namespace CFlat.Html;

/// <summary>
/// Use this to make custom elements.
/// </summary>
public interface HtmlElement
{
    List<HtmlElement> _children
    {
        get;
        set;
    }

    string _css
    {
        get;
        set;
    }

    Attributes _attributes
    {
        get;
        set;
    }
    
    /// <summary>
    /// Used to generate HTML to be returned via the receiver.
    /// </summary>
    /// <returns>Generated HTML code</returns>
    public string Render(ref NetworkStream stream);
    public string Render();
}