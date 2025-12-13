using CFlat.Html;
using CFlat.Html.Collections;

namespace Tests;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Running test `Lists`: {Lists.Run()}");
        Console.WriteLine($"Running test `WebPages`: {WebPages.Run()}");
        Console.WriteLine($"Running test `WebServer: {WebServer.WebServer.Run()}");
    }
}