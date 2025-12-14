using CFlat;
using CFlat.Routing;

namespace Tests.WebServer;

public class WebServer : Test
{
    public static bool Run()
    {
        Receiver r = new Receiver(8080);

        Route root = new Route("/", new Root(), Method.GET);
        Route table = new Route("/table", new Table(), Method.GET);
        Route paragraphs = new Route("/paragraphs", new Paragraphs(), Method.GET);
        Route ecma = new Route("/ecma", new EcmaScript(), Method.GET);
        StaticFile staticIndex = new StaticFile("/staticindex.html");
        
        r.Add(root);
        r.Add(table);
        r.Add(paragraphs);
        r.Add(ecma);
        r.Add(staticIndex);
        try
        {
            r.Run();
        }
        catch
        {
            return false;
        }
        
        return true;
    }
}