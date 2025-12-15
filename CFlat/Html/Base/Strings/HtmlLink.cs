using System.Net.Sockets;

namespace CFlat.Html.Base.Strings;

public class HtmlLink : HtmlElement
{
    protected HtmlString _link;
    protected HtmlString _text;

    public HtmlLink(string link, string text, string css = "", Attributes attributes = null)
    {
        _link = new HtmlString(link, true);
        _css = css;
        if (attributes != null) _attributes = attributes;
        else _attributes = new Attributes();
        _children = new List<HtmlElement>();
        _text = new  HtmlString(text, true);
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
        string style = "";
        if (_css != "")  style = $"stype=\"{_css}\""; 
        string html = $"<a{style} {_attributes.GetAttributes()} href=\"{_link.Render()}\">{_text.Render()}</a>";
        return html;
    }
}