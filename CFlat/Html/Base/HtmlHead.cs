namespace CFlat.Html.Base;

/// <summary>
/// Represents the `head` tag.
///
/// <paramref name="_children"/> is ignored.
/// <paramref name="_css"/> is ignored.
/// <paramref name="_attributes"/> is ignored.
/// </summary>
public class HtmlHead : HtmlElement
{
    public HtmlHead(List<HtmlElement> children, string css, Attributes attributes, List<HtmlMeta> metas, string title)
    {
        _children = children;
        _css = css;
        _attributes = attributes;
        _metas = metas;
        _title = title;
    }

    public HtmlHead(List<HtmlElement> children, List<HtmlMeta> metas, string title)
    {
        _children = children;
        _metas = metas;
        _title = title;
        _css = string.Empty;
        _attributes = new Attributes();
    }

    public HtmlHead(List<HtmlElement> children, string css, List<HtmlMeta> metas, string title)
    {
        _attributes = new Attributes();
        _children = children;
        _css = css;
        _metas = metas;
        _title = title;
    }

    public HtmlHead(string css, List<HtmlMeta> metas, string title)
    {
        _css = css;
        _metas = metas;
        _title = title;
        _attributes = new Attributes();
        _children = new List<HtmlElement>();
    }

    public HtmlHead(Attributes attributes, List<HtmlMeta> metas, string title)
    {
        _css = string.Empty;
        _attributes = attributes;
        _metas = metas;
        _title = title;
        _children = new List<HtmlElement>();
    }

    public HtmlHead(List<HtmlElement> children, Attributes attributes, List<HtmlMeta> metas, string title)
    {
        _children = children;
        _attributes = attributes;
        _metas = metas;
        _title = title;
        _css = string.Empty;
    }

    public HtmlHead(List<HtmlMeta> metas, string title)
    {
        _metas = metas;
        _title = title;
        _children = new List<HtmlElement>();
        _css = string.Empty;
        _attributes = new Attributes();
    }

    public HtmlHead(List<HtmlMeta> metas)
    {
        _metas = metas;
        _children = new List<HtmlElement>();
        _css = string.Empty;
        _attributes = new Attributes();
        _title = string.Empty;
    }

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }

    /// <summary>
    /// Represents the tag's contents, <paramref name="_children"/> is ignored. 
    /// </summary>
    public List<HtmlMeta> _metas;

    /// <summary>
    /// Represents the `title` tag's content
    /// </summary>
    public string _title;
    public string Render()
    {
        string html = "";

        foreach (HtmlMeta meta in _metas)
        {
            html += $"\t{meta.Render()}";
        }

        html += $"\t<title>{_title}</title>\n";
        
        return html;
    }
}