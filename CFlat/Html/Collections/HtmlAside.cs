using System.Net.Sockets;

namespace CFlat.Html.Collections;

/// <summary>
/// Represents the `aside` tag. Acts similar to HtmlDivision.
/// </summary>
public class HtmlAside : HtmlElement
{
    /// <summary>
    /// <example>
    /// new HtmlAside(new List<HtmlElement>([
    ///     new HtmlParagraph("Foo"),
    ///     new HtmlParagraph("Bar"),
    /// ]);
    /// </example>
    /// </summary>
    /// <param name="children"></param>
    /// <param name="css"></param>
    /// <param name="attributes"></param>
    public HtmlAside(List<HtmlElement> children, string css = "", Attributes attributes = null)
    {
        _children = children;
        _css = css;
        _attributes = attributes ?? new Attributes();
    }

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }
    public string Render()
    {
        return "";
    }
    public string Render(ref NetworkStream stream)
    {
        string css = _css switch
        {
            "" => "",
            _ => $"style=\"{_css}\""
        };
        
        string html = $"<aside style=\"{_css}\">\n";
        foreach (HtmlElement child in _children)
        {
            html += child.Render(ref stream);
        }
        html += "</aside>\n";
        return html;
    }
}