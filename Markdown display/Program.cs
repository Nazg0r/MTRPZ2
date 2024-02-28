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
            string? destinationPath;

            if (!File.Exists(path))
            {
                Console.Error.WriteLine("Invalid file path");
                return;
            }

            if (args.Length == 1)
            {
                Console.WriteLine(path);
                return;
            }

            if (args.Length == 3 && args[1] == "--out")
            {
                destinationPath = args[2];

                Console.WriteLine(destinationPath);
                return;
            }

            Console.Error.WriteLine("Wrong number of parameters");
            return;

        }
    }
}