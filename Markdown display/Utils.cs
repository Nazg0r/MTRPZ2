using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Markdown_display
{
    internal static class Utils
    {
        internal static string? getMatch(string text, string pattern)
        {
            if (Regex.IsMatch(text, pattern))
            {
                return Regex.Match(text, pattern).Value;
            }

            return null;
        }

        internal static string? delMatch(string text, string match)
        {
            if (!text.Contains(match)) return null;

            int mSize = match.Length;
            int mStart = text.IndexOf(match);

            return text.Substring(mStart + mSize + 1);
        }
    }
}
