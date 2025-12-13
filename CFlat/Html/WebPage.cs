using CFlat.Html.Base;

namespace CFlat.Html;

/// <summary>
/// The class used to define a standard web page.
///
///
/// Populate the _head property with any data needed there(title is already set) and fill <paramref name="_children"/> with the page's contents.
/// </summary>
public class WebPage : Division
{
    
    /// <summary>
    /// Used to populate the <c>Title</c> element in <paramref name="_head"/>.
    /// </summary>
    public string _name;

    /// <summary>
    /// The HtmlHead used in a web page, contains title and metadata.
    /// </summary>
    public HtmlHead _head;
    
    
    public WebPage(List<HtmlElement> children, string css, Attributes attributes, string name, HtmlHead head) : base(children, css, attributes)
    {
        _name = name;
        _head = head;
    }

    public WebPage(List<HtmlElement> children, string css, string name, HtmlHead head) : base(children, css)
    {
        _name = name;
        _head = head;
    }

    public WebPage(List<HtmlElement> children, Attributes attributes, string name, HtmlHead head) : base(children, attributes)
    {
        _name = name;
        _head = head;
    }

    public WebPage(List<HtmlElement> children, string name, HtmlHead head) : base(children)
    {
        _name = name;
        _head = head;
        _head._title = _name;
    }

    protected WebPage() : base()
    {
    }

    public new string Render()
    {
        string html = "<!DOCTYPE html>\n";

        string attr = "";

        for (int i = 0; i < _attributes.Count; i++)
        {
            attr += $" {_attributes[i].Name}=\"{_attributes[i].Value}\"";
        }

        html += $"<html{attr}>\n";
        
        html += "<head>\n" + _head.Render() + "\n</head>\n";
        
        html += "<body>\n";
        foreach (HtmlElement _child in _children)
        {
            html += _child.Render();
        }
        html += "</body>\n";
        
        html += "</html>\n";

        return html;
    }
}