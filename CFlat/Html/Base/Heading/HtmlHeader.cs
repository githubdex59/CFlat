using System.Net.Sockets;
using CFlat.Html.Base.Strings;

namespace CFlat.Html.Base.Heading;

public class HtmlHeader : HtmlElement
{
    protected HeaderLevel _level;
    protected HtmlString _text;
    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }

    public HtmlHeader(HeaderLevel level, string text, string css = "")
    {
        _level = level;
        _text = new HtmlString(text);
        _css = css;
    }

    public HtmlHeader(HeaderLevel level, string text, Attributes attributes, string css = "")
    {
        _level = level;
        _text = new HtmlString(text);
        _css = css;
        _attributes = attributes;
    }

    public string Render(ref NetworkStream stream)
    {
        return Render();
    }

    public string Render()
    {
        string html = "";

        string tag = _level switch
        {
            HeaderLevel.h1 => "h1",
            HeaderLevel.h2 => "h2",
            HeaderLevel.h3 => "h3",
            HeaderLevel.h4 => "h4",
            HeaderLevel.h5 => "h5",
            HeaderLevel.h6 => "h6",
        };

        string style = "";
        if (_css != "")
        {
            style = $" style=\"{_css}\"";
        }

        html += $"<{tag}{style}>{_text.Render()}</{tag}>";
        
        return html;
    }
}