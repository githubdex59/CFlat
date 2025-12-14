using CFlat.Html;
using CFlat.Html.Base;
using CFlat.Html.IO;
using CFlat.Html.IO.EcmaScript;

namespace Tests.WebServer;

public class EcmaScript : WebPage
{
    public EcmaScript() : base(
        new List<HtmlElement>(),
        "Javascript",
        new HtmlHead(new List<HtmlMeta>())
    )
    {
        Add(new Cookie(
            "foo",
            "bar",
            1
            ));

        Add(new HtmlEcmascript("console.log(\"PAIN!\");", new Attributes()));

    }
}