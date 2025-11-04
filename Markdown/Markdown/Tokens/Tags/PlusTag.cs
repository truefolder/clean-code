namespace Markdown.Tags;

public class PlusTag : ITag
{
    public string TokenIdentifiers => "+";
    public bool HasPair => false;
    public string CommonHtmlTag => "ul";
    public string HtmlTag => "li"; 
}