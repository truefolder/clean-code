namespace Markdown.Tags;

public class ItalicsToken : IToken
{
    public List<string> TokenIdentifiers => ["_"];
    public bool HasPair => true;
    public string HtmlTag => "em";
}