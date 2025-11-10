using Markdown.Tokens;
using Markdown.Tokens.Tags;

namespace Markdown.Parsers;

public class HeadingParser : IParser
{
    public bool CanParse(char symbol, string text, int index)
    {
        if (symbol != '#')
            return false;

        if (index != 0)
            return false;

        if (index + 1 < text.Length && !char.IsWhiteSpace(text[index + 1])) // TODO: почему тут warning?
            return false;
        
        return true;
    }

    public Token Parse(string text, int index)
    {
        var inner = text.Length > 2 ? text.Substring(2) : string.Empty;
        return new Token(new HashTag(), inner, text.Length - 1);
    }
}