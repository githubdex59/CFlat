namespace CFlat.Html;

public class Division : HtmlElement
{
    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }

    public Division(List<HtmlElement> children, string css, Attributes attributes)
    {
        _children = children;
        _css = css;
        _attributes = attributes;
    }

    public Division(List<HtmlElement> children, string css)
    {
        _children = children;
        _attributes = new Attributes();
        _css = css;
    }

    public Division(List<HtmlElement> children, Attributes attributes)
    {
        _children = children;
        _attributes = attributes;
        _css = "";
    }

    public Division(List<HtmlElement> children)
    {
        _children = children;
        _attributes = new Attributes();
        _css = "";
    }

    protected Division()
    {
        
    }

    public string Render()
    {
        string html = "";

        string attr = "";

        for (int i = 0; i < _attributes.Count; i++)
        {
            attr += $" {_attributes[i].Name}=\"{_attributes[i].Value}\"";
        }

        html += $"<div{attr}>\n";

        foreach (HtmlElement _child in _children)
        {
            html += _child.Render();
        }
        
        html += "</div>\n";

        return html;
    }
}