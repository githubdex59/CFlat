using System.Net.Sockets;
using CFlat.Html.Css;

namespace CFlat.Html.Base.Strings;

public class HtmlParagraph : HtmlElement
{
    protected Dictionary<char, string> _charMap = new Dictionary<char, string>([new KeyValuePair<char, string>('<', "&lt"), 
        new KeyValuePair<char, string>('>', "&gt"),
        new KeyValuePair<char, string>('&', "&amp"),
        new KeyValuePair<char, string>('\"', "&quot"),
        new KeyValuePair<char, string>('\'', "&#39")]);
    
    protected string _text;
    protected Sizing _spaceBetween;
    protected Sizing _spaceBefore;

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }
    public HtmlParagraph(string text, string css = "", Sizing spaceBetween = Sizing.None, Sizing spaceBefore = Sizing.None)
    {
        _text = text;
        _spaceBetween = spaceBetween;
        _spaceBefore = spaceBefore;
        _css = css;
    }

    public string Render()
    {
        return "";
    }
    public new string Render(ref NetworkStream stream)
    {
        string html = "";
        string finalString = "";
        
        foreach (char c in _text.ToCharArray())
        {
            if (_charMap.ContainsKey(c)) finalString += _charMap[c];
            else finalString += c;
        }
        

        string mBottom = _spaceBetween switch
        {
            Sizing.em2 => "2em",
            Sizing.None => "0",
            _ => "0"
        };

        string mTop = _spaceBefore switch
        {
            Sizing.em2 => "2em",
            Sizing.None => "0",
            _ => "0"
        };

        html += $"<p style=\"margin-bottom: {mBottom}; margin-top: {mTop}; {_css}\">{finalString}</p>\n";
        
        return html;
    }
}