namespace CFlat.Html;

public class ElementAttribute<T>
{
    public string Name;
    public T Value;
    
    public ElementAttribute(string name, T value)
    {
        Name = name;
        Value = value;
    }

    protected ElementAttribute()
    {
        Name = "null";
        Value = default(T);
    }



    public bool Equals(ElementAttribute<T> other)
    {
        return Name == other.Name && Value.Equals(other.Value);
    }

    public bool Equals(ElementAttribute<T> other, bool nameOnly)
    {
        if (nameOnly)
        {
            return Name == other.Name;
        }
        return Equals(other);
    }

    public static bool operator ==(ElementAttribute<T> a, ElementAttribute<T> b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(ElementAttribute<T> a, ElementAttribute<T> b)
    {
        return !(a == b);
    }
}

public class ElementAttribute : ElementAttribute<string>
{
    public ElementAttribute(string name, string value) : base(name, value)
    {
    }
}