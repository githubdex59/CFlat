using System.Collections;

namespace CFlat.Html;

public class Attributes<T>
{
    protected List<ElementAttribute<T>> _attributes;
    
    public ElementAttribute<T> this[int i] => _attributes[i];
    
    public int Count => _attributes.Count;

    public Attributes(List<ElementAttribute<T>> attributes)
    {
        _attributes = attributes;
    }

    public Attributes()
    {
        _attributes = new List<ElementAttribute<T>>();
    }

    public T GetValue(string name)
    {
        foreach (var attribute in _attributes)
        {
            if (attribute.Equals(new ElementAttribute<T>(name, default(T)), true))
                return attribute.Value;
        }

        throw new Exception("Attribute not found");
    }
    
    public bool Contains(string name)
    {
        foreach (var attribute in _attributes)
        {
            if (attribute.Equals(new ElementAttribute<T>(name, default(T)), true)) return true;
        }
        return false;
    }

    public string GetAttributes()
    {
        string _attr = "";
        foreach (ElementAttribute<T> attr in _attributes)
        {
            _attr += $" {attr.Name}=\"{attr.Value.ToString() ?? ""}\"";
        }
        return _attr;
    }

}


public class Attributes : Attributes<string>
{
    public Attributes(List<ElementAttribute<string>> attributes) : base(attributes)
    {
    }

    public Attributes() : base()
    {
        
    }
}