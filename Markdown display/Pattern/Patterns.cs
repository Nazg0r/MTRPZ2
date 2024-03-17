using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Markdown_display.Pattern
{
    public class Patterns
    {
        internal string placeholder = "@:";
        internal string paragrph = @"[^\r\n](.|\W[^(\n\r\n)])*(?=\r\n\r\n)";
        internal string preformatted = @"`{3}[\w\W]*`{3}";
        internal string simpleForm = @"[^\s]*";
        internal string markupEnding = @"\w(_|`|\*{2})$";

        internal Dictionary<string, string>? relations;
        internal string? paragraph;


        internal Dictionary<string, string> withoutMarkup = new()
        {
            {@"`{3}[\w\W]*`{3}",                     @"(?<=`{3}\r\n)[\w\W]+(?=\r\n`{3})" },
            { @"(\*{2}|_|`){2}.+(\*{2}|_|`){2}",     @"(?<=(\*{2}|_|`)).+(?=(\*{2}|_|`))" },
            {@"\*{2}(\w*\w|[^\*])+\*{2}",            @"(?<=\*{2}).+(?=\*{2})" },
            {@"_{1}(\w_\w|[^_])+_{1}",               @"(?<=_{1}).+(?=_{1})" },
            {@"`{1}(\w`\w|[^`])+`{1}",               @"(?<=`{1}).+(?=`{1})" }
        };

        internal List<string> checklist = new()
        {
            @"`{3}[\w\W]*`{3}",
            @"`{1}.+`{1}",
            @"\*{2}.+\*{2}",
            @"_{1}.+_{1}"
        };

        internal List<string> extraChecklist = new()
        {
            @"(?<=\s)_{1}[^\s]([^_\s\.\,]_[^_\s\,\.]|[^_])*.",
            @"(?<=\s)`{1}[^\s]([^`\s\.\,]`[^`\s\.\,]|[^`])*.",
            @"(?<=\s)\*{2}[^\s]([^\*\s\,\.]\*{2}[^\*\s\,\.]|[^\*])*.{2}"
        };
    }
}
