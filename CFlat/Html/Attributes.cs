namespace CFlat.Html;

public class Attributes<T>
{
    protected List<ElementAttribute<T>> _attributes;

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