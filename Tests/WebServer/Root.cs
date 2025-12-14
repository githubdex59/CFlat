using CFlat.Html;
using CFlat.Html.Base;
using CFlat.Html.Collections;

namespace Tests.WebServer;

internal class Root : WebPage
{
    public Root() : base(
        new List<HtmlElement>(),
        new Attributes(),
        "WebServerTest",
        new HtmlHead(new List<HtmlMeta>())
        )
    {
        
        Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "a")]
                ))));
        Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "A")]
            ))));
        Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "i")]
            ))));
        Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "I")]
            ))));
        Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "1")]
            ))));
    }

    
}