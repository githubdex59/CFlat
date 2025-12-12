namespace CFlat.Routing;

/// <summary>
/// Used in Receiver to determine what to run when a request is received. 
/// </summary>
public class Route
{
    public string _path;
    
    public Route(string _path)
    {
        this._path = _path;
    }
}