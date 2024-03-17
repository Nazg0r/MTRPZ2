using Markdown_display;
using Markdown_display.Pattern;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleParams
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Missing arguments");
                return 1;
            }

            string path = args[0];
            string? destinationPath = null;
            Convertor convertor = new(new ANSIPatterns());

            if (!File.Exists(path))
            {
                Console.Error.WriteLine("Invalid file path");
                return 1;
            }

            if (args.Length == 1 || args.Length == 3 && args[1] == "--out")
            {
                if (args.Length == 3) destinationPath = args[2];

                string text = FileProcessing.ReadFile(path);

                try
                {
                    string HTML = convertor.Start(text);

                    FileProcessing.WriteFile(HTML);
                    return 0;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Error: invalid markdown. {e.Message}");
                    return 1;
                }
            }

            Console.Error.WriteLine("Wrong number of parameters or incorrect inputs");
            return 1;

        }
    }
}