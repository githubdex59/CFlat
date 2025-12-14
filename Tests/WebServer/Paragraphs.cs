using CFlat.Html;
using CFlat.Html.Base;
using CFlat.Html.Base.Strings;
using CFlat.Html.Collections;
using CFlat.Html.Css;

namespace Tests.WebServer;

public class Paragraphs : WebPage
{
    public Paragraphs() : base(new List<HtmlElement>(), "Paragraphs", new HtmlHead(new List<HtmlMeta>()))
    {
        _css =
            "aside {\n" +
            "  width: 40%;\n" +
            "  padding-left: 0.5rem;\n" +
            "  margin-left: 0.5rem;\n" +
            "  float: right;\n" +
            "  box-shadow: inset 5px 0 5px -5px #29627e;\n" +
            "  font-style: italic;\n" +
            "  color: #29627e;\n" +
            "}\n" +
            "\n" +
            "aside > p {\n" +
            "  margin: 0.5rem;\n" +
            "}\n" +
            "";
        
        Add(new HtmlAside(new List<HtmlElement>([
            new HtmlParagraph("This is a quote from the popular film Star Wars: The Revenge of the Sith")
        ])));
        Add(new HtmlParagraph("Hello there!"));
        Add(new HtmlParagraph("General Kenobi!", css : "font-style: italic; color: red;", Sizing.em2));


    }
}