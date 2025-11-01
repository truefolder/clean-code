using Markdown.Tokens;

namespace Markdown.Parsers;

public interface IParser
{
    Token Parse(string text);
}