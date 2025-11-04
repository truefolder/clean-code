namespace Markdown.Tags;

public class DoubleUnderscoreTag : ITag
{
    public List<string> TokenIdentifiers => ["__"];
    public bool HasPair => true;
    public string HtmlTag => "strong";
}