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
    
    /// <summary>
    /// Used to generate HTML to be returned via the receiver.
    /// </summary>
    /// <returns>Generated HTML code</returns>
    public string Render();
}