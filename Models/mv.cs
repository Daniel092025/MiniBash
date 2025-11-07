namespace MiniBash.Models;
class MV
{
    public static void Run(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: mv <source1> [<source2> ...] <destination>");
            return;
        }

        // Destinasjon er siste argument
        string destination = args[args.Length - 1];
        string[] sources = new string[args.Length - 1];
        Array.Copy(args, sources, args.Length - 1);

        // Hvis destinasjon er mappe og flere filer skal flyttes
        bool destIsDirectory = Directory.Exists(destination);

        foreach (var source in sources)
        {
            if (!File.Exists(source))
            {
                Console.WriteLine($"mv: {source}: No such file");
                continue;
            }

            string destPath = destIsDirectory
                ? Path.Combine(destination, Path.GetFileName(source))
                : destination;

            try
            {
                // Samme disk?
                if (Path.GetPathRoot(source) == Path.GetPathRoot(destPath))
                {
                    // Prøv direkte move
                    File.Move(source, destPath, true); // true = overwrite hvis fil finnes
                    Console.WriteLine($"Moved '{source}' → '{destPath}' (same disk)");
                }
                else
                {
                    // Forskjellig disk: Copy + Delete
                    using (FileStream input = new FileStream(source, FileMode.Open, FileAccess.Read))
                    using (FileStream output = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                    {
                        input.CopyTo(output);
                    }
                    File.Delete(source);
                    Console.WriteLine($"Moved '{source}' → '{destPath}' (different disk)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving '{source}': {ex.Message}");
            }
        }
    }
}
