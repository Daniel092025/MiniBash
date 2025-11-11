namespace MiniBash.Models
{
    class HEAD
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: head <filename> [lines]");
                return;
            }

            string path = args[0];
            int linesToRead = 10; // default number of lines

            // Optional: allow user to specify line count
            if (args.Length > 1 && int.TryParse(args[1], out int n))
                linesToRead = n;

            if (!File.Exists(path))
            {
                Console.WriteLine($"head: cannot open '{path}' for reading: No such file");
                return;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                for (int i = 0; i < linesToRead; i++)
                {
                    string? line = reader.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }
            }
        }
    }
}