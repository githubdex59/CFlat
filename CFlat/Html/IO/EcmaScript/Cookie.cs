namespace CFlat.Html.IO.EcmaScript;

public class Cookie : HtmlEcmascript
{
    /// <summary>
    /// Sets a cookie based on Mandeep Janjua's answer(https://stackoverflow.com/questions/14573223/set-cookie-and-get-cookie-with-javascript) on stack overflow.
    /// </summary>
    /// <param name="name">The name of the cookie</param>
    /// <param name="value">What is stored in the cookie</param>
    /// <param name="days">The amount of days before the cookie expires</param>
    public Cookie(string name, string value, int days) : base(
        $"    var expires = \"\";\n" +
            $"    if ({days}) {{\n" +
            $"        var date = new Date();\n" +
            $"        date.setTime(date.getTime() + ({days}*24*60*60*1000));\n" +
            $"        expires = \"; expires=\" + date.toUTCString();\n" +
            $"    }}\n" +
            $"    document.cookie = \"{name}\" + \"=\" + (\"{value}\" || \"\")  + expires + \"; path=/\";", new Attributes())
    {
    }

    /// <summary>
    /// Gets the value of a cookie based on name
    /// </summary>
    /// <param name="name">The name of the cookie</param>
    /// <returns>Code to get the value of the cookie in a variable the name of the cookie</returns>
    public static string GetCookie(string name)
    {
        return
            $"    var nameEQ = {name} + \"=\";\n" +
            $"    var ca = document.cookie.split(';');\n" +
            $"    for(var i=0;i < ca.length;i++) {{\n" +
            $"        var c = ca[i];\n" +
            $"        while (c.charAt(0)==' ') c = c.substring(1,c.length);\n" +
            $"        if (c.indexOf(nameEQ) == 0) var {name} = c.substring(nameEQ.length,c.length);\n";

    }
}