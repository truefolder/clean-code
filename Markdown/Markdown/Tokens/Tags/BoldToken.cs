namespace Markdown.Tags;

public class BoldToken : IToken
{
    public List<string> TokenIdentifiers => ["__"];
    public bool HasPair => true;
    public string HtmlTag => "strong";
}