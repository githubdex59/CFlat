using CFlat;
using CFlat.Routing;

namespace Tests.WebServer;

public class WebServer : Test
{
    public static bool Run()
    {
        Receiver r = new Receiver(8080);

        Route root = new Route("/", new Root(), Method.GET);
        
        
        r.Add(root);
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