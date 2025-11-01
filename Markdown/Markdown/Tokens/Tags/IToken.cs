namespace Markdown.Tags;

public interface IToken
{
    public List<string> TokenIdentifiers { get; }
    public bool HasPair { get; }
    public string HtmlTag { get; }
}