namespace MiniBash.Models
{
    class TAIL
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: tail <filename> [lines]");
                return;
            }

            string path = args[0];
            int linesToRead = 10; // default like Unix `tail`

            // Optional: user can specify number of lines
            if (args.Length > 1 && int.TryParse(args[1], out int n))
                linesToRead = n;

            if (!File.Exists(path))
            {
                Console.WriteLine($"tail: cannot open '{path}' for reading: No such file");
                return;
            }

            // Efficiently store only the last N lines
            Queue<string> lastLines = new Queue<string>(linesToRead);

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lastLines.Count == linesToRead)
                        lastLines.Dequeue(); // remove oldest line

                    lastLines.Enqueue(line);
                }
            }

            // Print the collected lines
            foreach (var line in lastLines)
                Console.WriteLine(line);
        }
    }
}