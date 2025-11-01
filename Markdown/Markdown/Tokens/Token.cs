using Markdown.Tags;

namespace Markdown.Tokens;

public class Token(IToken type, string value, int position)
{
    public IToken Type { get; } = type;
    public string Value { get; } = value;
    public int Position { get; } = position;
}