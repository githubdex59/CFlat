using System.Net.Sockets;
using CFlat.Html.Base.Strings;

namespace CFlat.Html.IO;

public class HtmlEcmascript :  HtmlElement
{
    public HtmlEcmascript(string src, Attributes attributes)
    {
        _src = new HtmlString(src, true);
        _attributes = attributes;
    }

    protected HtmlString _src;
    
    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }
    public string Render()
    {
        return "";
    }
    public string Render(ref NetworkStream stream)
    {
        if (_children != null) throw new InvalidHtmlException("Script tags are not allowed children.");
        if (_css != null) throw new InvalidHtmlException("Script tags have no valid css.s");

        string html = "";

        html += $"<script {_attributes.GetAttributes()}>\n" +
                $"{_src.Render(ref stream)}\n" +
                $"</script>\n";
        
        return html;
    }
}