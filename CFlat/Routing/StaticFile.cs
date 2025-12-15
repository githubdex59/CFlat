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
            //Console.WriteLine(lPath);

            if (System.IO.File.Exists(lPath))
                    return System.IO.File.ReadAllText(lPath);
            return "";
        }
        
        
        
        public File(string name) : base(new List<HtmlElement>(), name, new HtmlHead(new List<HtmlMeta>()))
        {
            
        }

        public override string Render(ref NetworkStream stream, (Dictionary<string, string> headers, string rType) headers)
        {
            if (_type != "text/html") _type = "text/html";
            
            string[] rFirstLine = headers.rType.Split(" ");
            _name = rFirstLine[1];
            string type;
            if (headers.headers.TryGetValue("Accept", out type))
            {
                if (!type.StartsWith("text/html"))  _type = type;
                if (type == "*/*") _type = rFirstLine[1].Split('.').Last() switch
                {
                    "js" => "text/javascript",
                    "png"  => "image/png",
                    _ => "text/plain"
                };
            }
            
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