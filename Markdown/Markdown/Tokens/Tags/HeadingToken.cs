namespace Markdown.Tags;

public class HeadingToken : IToken
{
    public List<string> TokenIdentifiers => ["#"];
    public bool HasPair => false;
    public string HtmlTag => "h1";
}