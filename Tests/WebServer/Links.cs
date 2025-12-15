using CFlat.Html;
using CFlat.Html.Base;
using CFlat.Html.Base.Strings;

namespace Tests.WebServer;

public class Links : WebPage
{
    public Links() : base(
        new List<HtmlElement>(),
        "Links",
        new HtmlHead(
            new List<HtmlMeta>()
            )
        )
    {
        Add(new HtmlLink("127.0.0.1:8080/table", "Click here"));
        AddBreak();
        Add(new HtmlLink("127.0.0.1:8080/", "Click here"));
        AddBreak();
        Add(new HtmlLink("127.0.0.1:8080/paragraphs", "Click here"));
    }
}