namespace Markdown.Tags;

public class TextTag : ITag
{
    public string TokenIdentifiers { get; }
    public bool HasPair { get; }
    public string HtmlTag { get; }
}