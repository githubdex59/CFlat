namespace CFlat.Html;

public interface HtmlElement
{
    List<HtmlElement> _children
    {
        get;
        set;
    }

    string _css
    {
        get;
        set;
    }

    Attributes _attributes
    {
        get;
        set;
    }
    public string Render();
}