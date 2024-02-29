using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown_display
{
    internal static class FileProcessing
    {
        internal static string ReadFile(string path)
        {
            StringBuilder sb = new();

            using (StreamReader reader = new(path))
            {
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }

                sb.AppendLine("");
            }

            return sb.ToString();
        }

        internal static void WriteFile(string text, string? path = null)
        {
            if (path == null) Console.WriteLine(text);
            else
            {
                using (StreamWriter writer = new(path, false)) 
                {
                    if (!File.Exists(path)) File.Create(path);
                    writer.WriteLine(text);
                }
            }
        }
    }
}
