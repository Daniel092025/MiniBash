namespace MiniBash.Models
{
    class CAT
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                // Leser direkte fra tastatur (stdin)
                string? input;
                while ((input = Console.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
            else
            {
                foreach (var file in args)
                {
                    if (File.Exists(file))
                    {
                        string content = File.ReadAllText(file);
                        Console.Write(content);
                    }
                    else
                    {
                        Console.Error.WriteLine($"cat: {file}: No such file or directory");
                    }
                }
            }
        }
    }
}