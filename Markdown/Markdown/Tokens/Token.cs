using Markdown.Tokens.Tags;

namespace Markdown.Tokens;

public class Token(ITag type, string value, int endIndex)
{
    public ITag Type { get; } = type;
    public string Value { get; } = value;
    public int EndIndex { get; } = endIndex;
}