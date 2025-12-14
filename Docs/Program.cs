using CFlat;
using CFlat.Routing;

namespace Docs;

class Program
{
    static void Main(string[] args)
    {
        Receiver r = new Receiver(8080);
        
        r.Add(new StaticFile(""));
        
        r.Run();
    }
}