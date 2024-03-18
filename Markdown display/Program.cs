using Markdown_display;
using Markdown_display.Pattern;
using System;
using System.Linq;
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
            string? destinationPath = Utilities.SetOutPath(args);
            Patterns format = Utilities.SetFormat(args);

            try
            {
                Utilities.CheckFormatFlag(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }

            try 
            {
                Utilities.CheckOutPath(destinationPath!); 
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }

            Convertor convertor = new(format);

            if (!File.Exists(path))
            {
                Console.Error.WriteLine("Invalid file path");
                return 1;
            }

            if (args.Length <= 4 && args.Length > 0)
            {
                string text = FileProcessing.ReadFile(path);

                try
                {
                    string HTML = convertor.Start(text);

                    FileProcessing.WriteFile(HTML, destinationPath);
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