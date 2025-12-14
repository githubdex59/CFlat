using System.Net.Sockets;
using CFlat.Html;
using CFlat.Html.Base;

namespace CFlat.Routing;

public class StaticFile : Route
{
    public class File : WebPage
    {
        private string path = "./Static";
        
        protected string GetContent()
        {
            string lPath = $"{path}{_name}";
            Console.WriteLine(path);
            Console.WriteLine(lPath);

                    return System.IO.File.ReadAllText(lPath);
            return "";
        }
        
        
        
        public File(string name) : base(new List<HtmlElement>(), name, new HtmlHead(new List<HtmlMeta>()))
        {
            
        }

        public override string Render(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
        {
            DealWithHeaders(ref stream, headers);
            
            string content = GetContent();
            return content;
        }
    }
    public StaticFile(string path) : base(path, new File(path), Method.GET)
    {
    }

    internal StaticFile(string path, Method method) : base(path, method)
    {
    }
}