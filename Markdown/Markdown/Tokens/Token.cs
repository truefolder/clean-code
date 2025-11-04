using Markdown.Tags;

namespace Markdown.Tokens;

public class Token(ITag type, string value, int position)
{
    public ITag Type { get; } = type;
    public string Value { get; } = value;
    public int Position { get; } = position;
}