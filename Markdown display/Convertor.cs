using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Markdown_display
{
    internal class Convertor
    {
        Patterns patterns = new();

        internal string MarkdownToHTML(string paragraph)
        {
            List<string> preformattedText = TakePreformattedText(ref paragraph);

            foreach (KeyValuePair<string, string> relation in patterns.relations)
            {
                while (Regex.IsMatch(paragraph, relation.Key))
                {
                    string match = Regex.Match(paragraph, relation.Key).Value;
                    string tagForm = StringToHTML(match, relation.Key, true);
                    paragraph = paragraph.Replace(match, tagForm);
                }
            }

            paragraph = ReturnPreformattedText(paragraph, preformattedText);
            string result = patterns.paragraphTeg.Replace(" ", paragraph);

            return result;
        }

        private List<string> TakePreformattedText(ref string text)
        {
            List<string> preformattedText = new();
            int i = 0;

            while (Regex.IsMatch(text, patterns.preformattedPattern))
            {
                string match = Regex.Match(text, patterns.preformattedPattern).Value;
                preformattedText.Add(StringToHTML(match, patterns.preformattedPattern, false));
                text = text.Replace(match, patterns.placeholder + i);
                i++;
            }

            return preformattedText;
        }

        private string ReturnPreformattedText(string text, List<string> preformattedText)
        {
            int i = 0;
            foreach (string preformattedPart in preformattedText)
            {
                text = text.Replace(patterns.placeholder + i, preformattedPart);
                i++;
            }

            return text;
        }

        private string StringToHTML(string match, string pattern, bool checkMarkdoun)
        {
            string simpleForm = Regex.Match(match, patterns.withoutMarkup[pattern]).Value;

            if (checkMarkdoun && CheckMarckdown(simpleForm))
            {
                Console.Error.WriteLine($"Error: invalid markdown. Convertion error on \"{simpleForm}\" ");
            }

            return patterns.relations[pattern].Replace(" ", simpleForm);
        }

        private bool CheckMarckdown(string text)
        {
            foreach (var relation in patterns.relations)
            {
                if (Regex.IsMatch(text, relation.Key)) return true;
            }

            return false;
        }

    }
}
