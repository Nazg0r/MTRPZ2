
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown_display.Pattern
{
    public class HTMLPatterns : Patterns
    {
        public HTMLPatterns()
        {
            paragraph = "<p>\n \n</p>";
            relations = new()
            {
                {@"(\*{2}|_|`){2}.+(\*{2}|_|`){2}",      "" },
                {@"`{3}[\w\W]*`{3}",                     "<pre>\n \n</pre>" },
                {@"\*{2}(\w*\w|[^\*])+\*{2}",            "<b> </b>" },
                {@"_{1}(\w_\w|[^_])+_{1}",               "<i> </i>" },
                {@"`{1}(\w`\w|[^`])+`{1}",               "<tt> </tt>" }
            };
        }

    }
}
