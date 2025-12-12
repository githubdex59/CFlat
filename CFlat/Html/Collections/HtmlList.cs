namespace CFlat.Html.Collections;

public class HtmlList<T> : List<T>, HtmlElement
{
    
    public Ordering _ordering;

    public HtmlList(Ordering ordering, Attributes attributes)
    {
        _ordering = ordering;
        _css = "";
        _attributes = attributes;
    }

    public HtmlList(IEnumerable<T> collection, Ordering ordering, Attributes attributes) : base(collection)
    {
        _ordering = ordering;
        _css = "";
        _attributes = attributes;
    }

    public HtmlList(int capacity, Ordering ordering, Attributes attributes) : base(capacity)
    {
        _ordering = ordering;
        _css = "";
        _attributes = attributes;
    }

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }

    public string Render()
    {
        if (_children != null)
        {
            throw new InvalidHtmlException("Lists cannot have children.");
        }
        string html = "";

        switch (_ordering)
        {
            case Ordering.Unordered:
                html += "<ul>\n";
                foreach (T item in this)
                {
                    html += $"\t<li>{item.ToString() ?? "null"}</li>\n";
                }
                html += "</ul>\n";
                break;
            case Ordering.Ordered:
                string type;
                if (_attributes.Contains("type"))
                {
                    type = $" type=\"{_attributes.GetValue("type")}\"";
                }
                else
                {
                    
                    type = "";
                }
                html += $"<ol{type}>\n";
                foreach (T item in this)
                {
                    html += $"\t<li>{item.ToString() ?? "null"}</li>\n";
                }
                html += "</ol>\n";
                break;
            case Ordering.Menu:
                html += "<menu>\n";
                foreach (T item in this)
                {
                    html += $"\t<li>{item.ToString() ?? "null"}</li>\n";
                }
                html += $"</menu>\n";
                break;
            default:
                throw new InvalidHtmlException("Lists can only be unordered (temporary)");
        }
        

        return html;
    }
}