using System.Text;
using Markdown.Tokens;
using Markdown.Tokens.Tags;

namespace Markdown.Renderers;

public class MarkdownToHtmlRenderer()
{
    public string RenderWithConstraints(string markdown, bool allowBold)
    {
        var html = new StringBuilder();
        var tokenizer = new Tokenizer(allowBold);
        var tokens = tokenizer.Tokenize(markdown);

        for (var i = 0; i < tokens.Count; i++)
        {
            if (TryRenderMarkedList(tokens, i, html, out var newIndex))
            {
                i = newIndex;
                continue;
            }
            var token = tokens[i];
            if (token.Type is TextTag)
            {
                html.Append(token.Value);
                continue;
            }

            var innerPartAllowBold = token.Type is not UnderscoreTag;

            var innerHtml = RenderWithConstraints(token.Value, innerPartAllowBold);
            html.Append('<').Append(token.Type.HtmlTag).Append('>')
                .Append(innerHtml)
                .Append("</").Append(token.Type.HtmlTag).Append('>');
        }

        return html.ToString();
    }

    private bool TryRenderMarkedList(List<Token> tokens, int index, StringBuilder html, out int newIndex)
    {
        if (!IsMarkedListItem(tokens[index]))
        {
            newIndex = index;
            return false;
        }

        var listTagType = tokens[index].Type.GetType();
        var lastItemIndex = index;

        html.Append("<ul>");
        
        for (var currentIndex = index; currentIndex < tokens.Count; )
        {
            if (!IsMarkedListItemOfType(tokens, currentIndex, listTagType))
                break;

            html.Append("<").Append(tokens[currentIndex].Type.HtmlTag).Append('>')
                .Append(RenderWithConstraints(tokens[currentIndex].Value, allowBold: true))
                .Append("</").Append(tokens[currentIndex].Type.HtmlTag).Append('>');

            lastItemIndex = currentIndex;
            
            var lookAhead = currentIndex + 1;
            var newLines = 0;

            while (lookAhead < tokens.Count && tokens[lookAhead] is { Type: TextTag, Value: "\n" })
            {
                newLines++;
                lookAhead++;
            }
            
            if (lookAhead < tokens.Count &&
                IsMarkedListItemOfType(tokens, lookAhead, listTagType) &&
                newLines < 2)
            {
                if (newLines > 0) html.Append('\n');
                currentIndex = lookAhead;
                continue;
            }

            break;
        }

        html.Append("</ul>");
        newIndex = lastItemIndex;

        return true;
    }

    private bool IsMarkedListItem(Token token)
    {
        return token.Type is AsteriskTag or DashTag or PlusTag;
    }

    private bool IsMarkedListItemOfType(List<Token> tokens, int index, Type tagType)
    {
        return index < tokens.Count &&
               tokens[index].Type.GetType() == tagType &&
               (tokens[index].Type is AsteriskTag || tokens[index].Type is DashTag || tokens[index].Type is PlusTag);
    }
}