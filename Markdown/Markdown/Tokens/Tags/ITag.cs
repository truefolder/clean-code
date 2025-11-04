namespace Markdown.Tags;

public interface ITag
{
    public string TokenIdentifiers { get; }
    public bool HasPair { get; }
    public string HtmlTag { get; }
}