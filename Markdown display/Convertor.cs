using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Markdown_display.Pattern;

namespace Markdown_display
{
    public class Convertor
    {
        private Patterns _patterns;

        public Convertor(Patterns format) 
        { 
            _patterns = format;
        }

        public string Start(string text)
        {
            StringBuilder sb = new();

            TextHandler(text, _patterns.paragrph, (m) =>
            {
                sb.Append(MarkdownToFormat(m) + "\n");
            });

            return sb.ToString();
        }

        internal string MarkdownToFormat(string paragraph)
        {
            List<string> preformattedText = TakePreformattedText(ref paragraph);
            ExtraCheck(paragraph);
            paragraph = DoConversion(paragraph);
            paragraph = ReturnPreformattedText(paragraph, preformattedText);
            string result = _patterns.paragraph!.Replace(" ", paragraph);

            return result;
        }

        private string DoConversion(string text)
        {
            foreach (KeyValuePair<string, string> relation in _patterns.relations!)
            {
                while (Regex.IsMatch(text, relation.Key))
                {
                    string match = Regex.Match(text, relation.Key).Value;
                    string tagForm = StringToFormat(match, relation.Key, true);
                    text = text.Replace(match, tagForm);
                }
            }

            return text;
        }

        private List<string> TakePreformattedText(ref string text)
        {
            List<string> preformattedText = new();
            int i = 0;

            while (Regex.IsMatch(text, _patterns.preformatted))
            {
                string match = Regex.Match(text, _patterns.preformatted).Value;
                preformattedText.Add(StringToFormat(match, _patterns.preformatted, false));
                text = text.Replace(match, _patterns.placeholder + i);
                i++;
            }

            return preformattedText;
        }

        private string ReturnPreformattedText(string text, List<string> preformattedText)
        {
            int i = 0;
            foreach (string preformattedPart in preformattedText)
            {
                text = text.Replace(_patterns.placeholder + i, preformattedPart);
                i++;
            }

            return text;
        }

        private string StringToFormat(string match, string pattern, bool checkMarkdoun)
        {
            string simpleForm = Regex.Match(match, _patterns.withoutMarkup[pattern]).Value;

            if (checkMarkdoun && CheckMarckdown(simpleForm))
            {
                throw new($"Convertion error on \"{match}\"");
            }

            return _patterns.relations![pattern].Replace(" ", simpleForm);
        }

        private bool CheckMarckdown(string text)
        {
            foreach (string pattern in _patterns.checklist)
            {
                if (Regex.IsMatch(text, pattern)) return true;
            }

            return false;
        }

        private void ExtraCheck(string text)
        {
            foreach (string pattern in _patterns.extraChecklist)
            {
                string workingTextPice = string.Copy(text);

                TextHandler(workingTextPice, pattern, (m) =>
                {
                    if (!Regex.IsMatch(m, _patterns.markupEnding))
                    {
                        string simpleForm = Regex.Match(m, _patterns.simpleForm).Value;
                        throw new($"Convertion error on \"{simpleForm}\"");
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
