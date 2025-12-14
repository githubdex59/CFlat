using CFlat.Html;
using CFlat.Html.Base;
using CFlat.Html.Collections;
using CFlat.Html.Data;

namespace Tests.WebServer;

public class Table : WebPage
{
    public Table() : base(
        new List<HtmlElement>(),
        "TableTest",
        new HtmlHead(new List<HtmlMeta>())
        )
    {
        Add(new HtmlTable(
            new List<string>(["Foo", "Bar"]),
            new List<List<string>>([
            new List<string>(["A", "B"]),
            new List<string>(["B", "C"]),
            new List<string>(["C", "D"]),
            new List<string>(["D", "E"])
            ])
            ));
    }
}