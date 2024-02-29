using Markdown_display;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Missing argiments");
                return;
            }

            string path = args[0];
            string? destinationPath = null;
            Convertor convertor = new();

            if (!File.Exists(path))
            {
                Console.Error.WriteLine("Invalid file path");
                return;
            }

            if (args.Length == 1 || args.Length == 3 && args[1] == "--out")
            {
                if (args.Length == 3) destinationPath = args[2];

                string text = FileProcessing.ReadFile(path);

                string? paragrph = Utils.getMatch(text, @"(?<=\n\r\n)(.|\W[^(\n\r\n)])*");

                string HTML = convertor.MarkdownToHTML(paragrph);

                FileProcessing.WriteFile(HTML);
                return;
            }

            Console.Error.WriteLine("Wrong number of parameters");
            return;

        }
    }
}