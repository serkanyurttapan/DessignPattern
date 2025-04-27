// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Text;

Console.WriteLine("Hello, World!");


var hello = "hello";
var sb = new StringBuilder();
sb.Append("<p>");
sb.Append(hello);
sb.Append("</p>");
Console.WriteLine(sb.ToString());

var words = new[] { "hello", "world" };
sb.Clear();
sb.Append("<ul>");
foreach (var word in words)
{
    sb.Append(string.Format("<li>{0}</li>", word));
}

sb.Append("</ul>");

Console.WriteLine(sb.ToString());


public class HtmlElement
{
    public string Name, Text;
    public IList<HtmlElement> HtmlElements = new List<HtmlElement>();
    private const int indentSize = 2;

    public HtmlElement()
    {
    }

    public HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        sb.Append($"{i}<{Name}>");
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.AppendLine(Text);
        }

        foreach (var element in HtmlElements)
        {
            sb.Append(element.ToStringImpl(indent + 1));
        }

        return sb.ToString();
    }
}