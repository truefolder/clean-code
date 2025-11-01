namespace Markdown.Tags;

public class MarkedListToken : IToken
{
    public List<string> TokenIdentifiers => ["*", "-", "+"];
    public bool HasPair => false;
    public string CommonHtmlTag => "ul";
    public string HtmlTag => "li";
}