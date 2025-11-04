namespace Markdown.Tags;

public class HashTag : ITag
{
    public List<string> TokenIdentifiers => ["#"];
    public bool HasPair => false;
    public string HtmlTag => "h1";
}