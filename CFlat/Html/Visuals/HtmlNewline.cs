using System.Net.Sockets;

namespace CFlat.Html.Css;

public class HtmlNewline : HtmlElement
{
    public HtmlNewline(string css)
    {
        _css = css;
    }

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }
    public string Render(ref NetworkStream stream)
    {
        return Render();
    }

    public string Render()
    {
        string style = $"";
        if (_css != "") style = $" style=\"{_css}\"";
        return $"<br{style}>";
    }
}