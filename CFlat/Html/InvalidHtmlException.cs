namespace CFlat.Html;

public class InvalidHtmlException : Exception
{
    public InvalidHtmlException(string message) : base(message)
    {
    }
}