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
        
        _children.Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "a")]
                ))));
        _children.Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "A")]
            ))));
        _children.Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "i")]
            ))));
        _children.Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "I")]
            ))));
        _children.Add(new HtmlList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9],
            Ordering.Ordered,
            new Attributes(new List<ElementAttribute<string>>(
                [new ElementAttribute<string>("type", "1")]
            ))));
    }
}