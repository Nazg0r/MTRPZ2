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
        string placeholder = "@:";

        internal string MarkdownToHTML(string paragraph)
        {
            List<string> preformattedText = TakePreformattedText(ref paragraph);

            foreach (var relation in patterns.relations)
            {
                while (Regex.IsMatch(paragraph, relation.Key))
                {
                    string match = Regex.Match(paragraph, relation.Key).Value;
                    string tagForm = StringToHTML(match, relation.Key, true);
                    paragraph = paragraph.Replace(match, tagForm);
                }
            }

            paragraph = ReturnPreformattedText(paragraph, preformattedText);
            string what = patterns.paragraphTeg.Replace(" ", paragraph);
            return what;
        }

        private List<string> TakePreformattedText(ref string text)
        {
            List<string> preformattedText = new();
            int i = 0;

            while (Regex.IsMatch(text, patterns.secondpattern))
            {
                string match = Regex.Match(text, patterns.secondpattern).Value;
                preformattedText.Add(StringToHTML(match, patterns.secondpattern, false));
                text = text.Replace(match, placeholder + i);
                i++;
            }

            return preformattedText;
        }

        private string ReturnPreformattedText(string text, List<string> preformattedText)
        {
            int i = 0;
            foreach (string preformattedPart in preformattedText)
            {
                text = text.Replace(placeholder + i, preformattedPart);
            }

            return text;
        }

        private string StringToHTML(string match, string pattern, bool checkMarkdoun)
        {
            match = Regex.Match(match, patterns.patternsWithoutMarkup[pattern]).Value;

            if (checkMarkdoun && CheckMarckdown(match)) throw new Exception();

            return patterns.relations[pattern].Replace(" ", match);
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
