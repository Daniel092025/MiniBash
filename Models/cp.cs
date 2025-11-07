namespace MiniBash.Models;

class CP
{
    public static void Run(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: cp <source> <destination>");
            return;
        }

        string source = args[0];
        string destination = args[1];

        if (!File.Exists(source))
        {
            Console.WriteLine($"cp: {source}: No such file or directory");
            return;
        }

        try
        {
            // Bruker FileStream for å etterligne hvordan cp jobber
            using (FileStream input = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (FileStream output = new FileStream(destination, FileMode.Create, FileAccess.Write))
            {
                input.CopyTo(output);
            }

            Console.WriteLine($"Copied '{source}' → '{destination}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying file: {ex.Message}");
        }
    }
}
