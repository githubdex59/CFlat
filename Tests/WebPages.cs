using CFlat.Html;
using CFlat.Html.Base;
using CFlat.Html.Collections;

namespace Tests;

public class WebPages : Test
{
    public static bool Run()
    {
        WebPage wp = new WebPage(new List<HtmlElement>(), "WebPagesTest", new HtmlHead(new List<HtmlMeta>()));

        wp._children.Add(new HtmlList<string>(["foo", "bar", "bazz", "buzz"], Ordering.Unordered, new Attributes()));
        
        Console.WriteLine(wp.Render());

        return true;
    }
}