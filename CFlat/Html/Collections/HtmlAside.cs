using System.Net.Sockets;

namespace CFlat.Html.Collections;

public class HtmlAside : HtmlElement
{
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