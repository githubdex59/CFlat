using System.Net.Sockets;
using CFlat.Html.Css;

namespace CFlat.Html.Base.Strings;

/// <summary>
/// Represents the `p` tag.
///
/// <paramref name="_children"/> is ignored.
/// </summary>
public class HtmlParagraph : HtmlElement
{
    /// <summary>
    /// Used in converting a normal string to a html legal string.
    /// </summary>
    protected Dictionary<char, string> _charMap = new Dictionary<char, string>([
        new KeyValuePair<char, string>('<', "&lt"), 
        new KeyValuePair<char, string>('>', "&gt"),
        new KeyValuePair<char, string>('&', "&amp"),
        new KeyValuePair<char, string>('\"', "&quot"),
        new KeyValuePair<char, string>('\'', "&#39")]);
    
    /// <summary>
    /// The contents of the paragraph 
    /// </summary>
    protected string _text;
    /// <summary>
    /// CSS margin-bottom
    /// </summary>
    protected Sizing _spaceBetween;
    /// <summary>
    /// CSS margin-top
    /// </summary>
    protected Sizing _spaceBefore;

    /// <summary>
    /// Ignored
    /// </summary>
    public List<HtmlElement> _children { get; set; }
    /// <summary>
    /// The inline CSS applied to the rendered paragraph
    /// </summary>
    public string _css { get; set; }
    /// <summary>
    /// Any attributes for the paragraph element
    /// </summary>
    public Attributes _attributes { get; set; }
    
    /// <summary>
    ///
    ///
    /// </summary>
    /// <remarks>Parameters marked * are required</remarks>
    /// <param name="text">The contents of the paragraph*</param>
    /// <param name="css">The inline CSS</param>
    /// <param name="spaceBetween">The space between the previous element and this</param>
    /// <param name="spaceBefore">The space before the next element and this</param>
    public HtmlParagraph(string text, string css = "", Sizing spaceBetween = Sizing.None, Sizing spaceBefore = Sizing.None, Attributes attributes = null)
    {
        _text = text;
        _spaceBetween = spaceBetween;
        _spaceBefore = spaceBefore;
        _css = css;
        _attributes = attributes ?? new Attributes();
    }
    public string Render()
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

        html += $"<p style=\"margin-bottom: {mBottom}; margin-top: {mTop}; {_css}\" {_attributes.GetAttributes()}>{finalString}</p>\n";
        
        return html;
    }
    public string Render(ref NetworkStream stream)
    {
        return Render();
    }
}