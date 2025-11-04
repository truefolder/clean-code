namespace Markdown.Tags;

public class UnderscoreTag : ITag
{
    public string TokenIdentifiers => "_";
    public bool HasPair => true;
    public string HtmlTag => "em";
}