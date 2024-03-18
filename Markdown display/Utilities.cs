using Markdown_display.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Markdown_display
{
    internal static class Utilities
    {
        static public string? SetOutPath(string[] args)
        {
            string? outPath;

            if (args.Contains("--out"))
            {
                int i = Array.IndexOf(args, "--out");
                outPath = args[i + 1];

                return outPath;
            }

            return null;
        }

        static public void CheckOutPath(string outPath)
        {
            if (outPath != null)
            {
                using (File.Create(outPath))
                {
                    if (!File.Exists(outPath))
                    {
                        throw new("Invalid destination path");
                    }
                }
            }
        }

        static public Patterns SetFormat(string[] args)
        {
            Patterns format;
            if (args.Contains("--format=HTML")) format = new HTMLPatterns();
            else if (!args.Any((arg) => arg.Contains("--format")) && args.Contains("--out")) format = new HTMLPatterns();
            else format = new ANSIPatterns();

            return format;
        }

        static public void CheckFormatFlag(string[] args)
        {
            if (!args.Contains("--format=HTML") &&
                !args.Contains("--format=ANSI") &&
                args.Any((arg) => arg.Contains("--format=")))
            {
                throw new("Incorrect out format");
            }
        }
    }
}
