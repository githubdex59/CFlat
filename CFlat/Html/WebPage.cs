using System.Net.Sockets;
using CFlat.Html.Base;
using static CFlat.Receiver;

namespace CFlat.Html;

/// <summary>
/// The class used to define a standard web page.
///
///
/// Populate the _head property with any data needed there(title is already set) and fill <paramref name="_children"/> with the page's contents.
/// When making your own page by extending this class, do the following:
/// - Name your class the path excluding slashes, after slashes capitalise the letter, e.g. <c>/foo/bar/bazz/buzz</c> => <c>FooBarBazzBuzz</c>
/// - Make a constructor as follows:
/// <code>
/// public FooBar() : base(
///     new List<HtmlElement>(),
///     new Attributes(),
///     "FooBar",
///     new HtmlHead(new List<HtmlMeta>())
///     )
/// {
///     ...
/// }
/// </code>
///
/// To manipulate the document refer to Document
/// </summary>
public class WebPage : Division
{
    /// <summary>
    /// The value of the `Content-Type` header in the response
    /// </summary>
    protected string _type = "text/html";
    
    /// <summary>
    /// - Add(): adds a new element(s) to the page.
    /// 
    /// </summary>
    [Obsolete("",true)]
    private class Document {}
    
    /// <summary>
    /// Used to populate the <c>Title</c> element in <paramref name="_head"/>.
    /// </summary>
    public string _name;

    /// <summary>
    /// The HtmlHead used in a web page, contains title and metadata.
    /// </summary>
    public HtmlHead _head;
    
    
    public WebPage(List<HtmlElement> children, string css, Attributes attributes, string name, HtmlHead head) : base(children, css, attributes)
    {
        _name = name;
        _head = head;
    }

    public WebPage(List<HtmlElement> children, string css, string name, HtmlHead head) : base(children, css)
    {
        _name = name;
        _head = head;
    }

    public WebPage(List<HtmlElement> children, Attributes attributes, string name, HtmlHead head) : base(children, attributes)
    {
        _name = name;
        _head = head;
    }

    public WebPage(List<HtmlElement> children, string name, HtmlHead head) : base(children)
    {
        _name = name;
        _head = head;
        _head._title = _name;
    }

    /// <summary>
    /// Add a new element to the page
    /// </summary>
    /// <param name="element"><example>new HtmlParagraph("Hello, World!")</example></param>
    protected void Add(HtmlElement element)
    {
        _children.Add(element);
    }

    /// <summary>
    /// Add an IEnumerable of elements to the page
    /// </summary>
    /// <param name="elements"><example>[new HtmlParagraph("Hello, World!"), new HtmlFoo("Bar")]</example></param>
    protected void Add(IEnumerable<HtmlElement> elements)
    {
        _children.AddRange(elements);
    }

    protected void DealWithHeaders(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
    {
        string[] rFirstLine = headers.rType.Split(" ");
        string httpV = rFirstLine.LastOrDefault();
        string contentType = headers.headers.GetValueOrDefault("Accept");
        string encoding = headers.headers.GetValueOrDefault("Acept-Encoding");
        
        _instance.SendHeaders(httpV, 200, "OK", _type
            , encoding, 0, ref stream);

    }

    /// <summary>
    /// DO NOT USE! TESTING PURPOSES ONLY!
    /// </summary>
    /// <returns>STUFF YOU SHOULDN'T USE IF UR NOT DOING IN THE Tests NAMESPACE!</returns>
    public virtual string RenderNoServer()
    {
        string html = "<!DOCTYPE html>\n";

        string attr = "";

        for (int i = 0; i < _attributes.Count; i++)
        {
            attr += $" {_attributes[i].Name}=\"{_attributes[i].Value}\"";
        }

        html += $"<html{attr}>\n";
        
        html += "<head>\n" + _head.Render() +
                $"\n<style>\n {_css} </style>\n"
                + "\n</head>\n";
        
        html += "<body>\n";
        foreach (HtmlElement _child in _children)
        {
            html += _child.Render();
        }
        html += "</body>\n";
        
        html += "</html>\n";

        return html;
    }
    
    /// <summary>
    /// Generates the html for any given web page by rendering all child elements.
    /// </summary>
    /// <param name="stream">The NetworkStream(Set by Reciever)</param>
    /// <param name="headers">The request headers(Set by Reciever)</param>
    /// <returns>A string containing html rendered from the page</returns>
    public virtual string Render(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
    {
        
        DealWithHeaders(ref stream, headers);
                
        string html = "<!DOCTYPE html>\n";

        string attr = "";

        for (int i = 0; i < _attributes.Count; i++)
        {
            attr += $" {_attributes[i].Name}=\"{_attributes[i].Value}\"";
        }

        html += $"<html{attr}>\n";
        
        html += "<head>\n" + _head.Render(ref stream) +
                           $"\n<style>\n {_css} </style>\n"
            + "\n</head>\n";
        
        html += "<body>\n";
        foreach (HtmlElement _child in _children)
        {
            html += _child.Render(ref stream);
        }
        html += "</body>\n";
        
        html += "</html>\n";

        return html;
    }
}

