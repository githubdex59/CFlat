using CFlat.Html;
using CFlat.Html.Collections;

namespace Tests;

public class Lists : Test
{
    public static bool Run()
    {
        try
        {
            HtmlList<string> list = new HtmlList<string>(["a", "b", "c"], Ordering.Unordered, new Attributes());
            Console.WriteLine(list.Render() + "\n");

            HtmlList<string> oList = new HtmlList<string>(["a", "b", "c"], Ordering.Ordered, new Attributes());
            Console.WriteLine(oList.Render());

            HtmlList<string> oRList = new HtmlList<string>(["a", "b", "c"], Ordering.Ordered,
                new Attributes([new ElementAttribute("type", "i")]));
            Console.WriteLine(oRList.Render());
        }
        catch
        {
            return false;
        }
        return true;
    }
}