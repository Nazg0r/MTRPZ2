using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown_display.Pattern
{
    public class ANSIPatterns : Patterns
    {
        public ANSIPatterns()
        {
            paragraph = " \n";
            relations = new()
            {
                {@"(\*{2}|_|`){2}.+(\*{2}|_|`){2}",      "" },
                {@"`{3}[\w\W]*`{3}",                     "\x1b[7m \x1b[27m" },
                {@"\*{2}(\w*\w|[^\*])+\*{2}",            "\x1b[1m \x1b[22m" },
                {@"_{1}(\w_\w|[^_])+_{1}",               "\x1b[3m \x1b[23m" },
                {@"`{1}(\w`\w|[^`])+`{1}",               "\x1b[7m \x1b[27m" }
            };
        }
    }
}
