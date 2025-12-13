namespace CFlat.Html.Base;

/// <summary>
/// Represents the `meta` tag, no css or children are allowed
/// </summary>
public class HtmlMeta : HtmlElement
{
    public HtmlMeta(List<HtmlElement> children, string css, Attributes attributes)
    {
        _children = children;
        _css = css;
        _attributes = attributes;
    }

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }
    public string Render()
    {
        return $"<meta{_attributes.GetAttributes()}>\n";
    }
}