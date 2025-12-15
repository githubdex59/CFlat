using System.Net.Sockets;
using CFlat.Html.Css;

namespace CFlat.Html.Base.Strings;

public class HtmlString : HtmlElement
{
    
    protected Dictionary<char, string> _charMap = new Dictionary<char, string>([new KeyValuePair<char, string>('<', "&lt"), 
        new KeyValuePair<char, string>('>', "&gt"),
        new KeyValuePair<char, string>('&', "&amp"),
        new KeyValuePair<char, string>('\"', "&quot"),
        new KeyValuePair<char, string>('\'', "&#39")]);
    
    protected string _text;
    protected Sizing _spaceBetween;
    protected Sizing _spaceBefore;

    public HtmlString(string text, bool allowQuot = false, string css = "", Sizing spaceBetween = Sizing.None, Sizing spaceBefore = Sizing.None)
    {
        _text = text;
        _spaceBetween = spaceBetween;
        _spaceBefore = spaceBefore;
        _css = css;

        if (allowQuot)
        {
            _charMap.Remove('\"');
            _charMap.Remove('\'');
        }
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
        string finalString = "";

        foreach (char c in _text.ToCharArray())
        {
            if (_charMap.ContainsKey(c)) finalString += _charMap[c];
            else finalString += c;
        }
        
        return finalString;
    }
}