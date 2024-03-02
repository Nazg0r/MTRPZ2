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

        internal string Start(string text)
        {
            StringBuilder sb = new();

            TextHandler(text, patterns.paragrph, (m) =>
            {
                sb.Append(MarkdownToHTML(m) + "\n");
            });

            return sb.ToString();
        }

        internal string MarkdownToHTML(string paragraph)
        {
            List<string> preformattedText = TakePreformattedText(ref paragraph);
            ExtraCheck(paragraph);
            paragraph = DoConversion(paragraph);
            paragraph = ReturnPreformattedText(paragraph, preformattedText);
            string result = patterns.paragraphTeg.Replace(" ", paragraph);

            return result;
        }

        private string DoConversion(string text)
        {
            foreach (KeyValuePair<string, string> relation in patterns.relations)
            {
                while (Regex.IsMatch(text, relation.Key))
                {
                    string match = Regex.Match(text, relation.Key).Value;
                    string tagForm = StringToHTML(match, relation.Key, true);
                    text = text.Replace(match, tagForm);
                }
            }

            return text;
        }

        private List<string> TakePreformattedText(ref string text)
        {
            List<string> preformattedText = new();
            int i = 0;

            while (Regex.IsMatch(text, patterns.preformatted))
            {
                string match = Regex.Match(text, patterns.preformatted).Value;
                preformattedText.Add(StringToHTML(match, patterns.preformatted, false));
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
                Console.Error.WriteLine($"Convertion error on \"{match}\" ");
            }

            return patterns.relations[pattern].Replace(" ", simpleForm);
        }

        private bool CheckMarckdown(string text)
        {
            foreach (string pattern in patterns.checklist)
            {
                if (Regex.IsMatch(text, pattern)) return true;
            }

            return false;
        }

        private void ExtraCheck(string text)
        {
            foreach (string pattern in patterns.extraChecklist)
            {
                string workingTextPice = string.Copy(text);

                TextHandler(workingTextPice, pattern, (m) =>
                {
                    if (!Regex.IsMatch(m, patterns.markupEnding))
                    {
                        string simpleForm = Regex.Match(m, patterns.simpleForm).Value;
                        throw new($"Convertion error on \"{simpleForm}\" ");
                    }
                });
            }
        }

        private void TextHandler(string text, string pattern, Action<string> handler)
        {
            while (Regex.IsMatch(text, pattern))
            {
                string match = Regex.Match(text, pattern).Value;
                handler.Invoke(match);
                int pointer = text.IndexOf(match) + match.Length;
                text = text.Substring(pointer);

            }
        } 
    }
}
