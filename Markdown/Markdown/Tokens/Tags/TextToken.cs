namespace Markdown.Tags;

public class TextToken : IToken
{
    public List<string> TokenIdentifiers { get; }
    public bool HasPair { get; }
    public string HtmlTag { get; }
}