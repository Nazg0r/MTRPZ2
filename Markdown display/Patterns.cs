using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Markdown_display
{
    internal class Patterns
    {
        string firstpattern = @"(.|\W[^(\n\r\n)])*";
        internal string secondpattern = @"\`{3}[\w\W]*\`{3}";
        internal string paragraphTeg = "<p>\n \n</p>";

        internal Dictionary<string, string> relations = new()
        {
            {@"\`{3}[\w\W]*\`{3}",  "<pre> </pre>" },
            {@"(?<=\s)\*{2}.*\*{2}(?=[\s\,\.])",       "<b> </b>" },
            {@"(?<=\s)_{1}[^\s].*_{1}(?=[\s\,\.])",         "<i> </i>" },
            {@"(?<=\s)\`{1}.*\`{1}(?=[\s\,\.])",       "<tt> </tt>" }
        };

        internal Dictionary<string, string> patternsWithoutMarkup = new()
        {
            {@"\`{3}[\w\W]*\`{3}",       @"(?<=\`{3})[\w\W]*(?=\`{3})" },
            {@"(?<=\s)\*{2}.*\*{2}(?=[\s\,\.])",       @"(?<=\*{2}).*(?=\*{2})" },
            {@"(?<=\s)_{1}[^\s].*_{1}(?=[\s\,\.])",         @"(?<=_{1}).*(?=_{1})" },
            {@"(?<=\s)\`{1}.*\`{1}(?=[\s\,\.])",       @"(?<=\`{1}).*(?=\`{1})" }
        };
    }
}
