namespace MiniBash.Models
{
    public static class Ls
    {
        public static void List(string? path = null)
        {
            // Default to users Documents folder if no path is provided
            path ??= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine($"Listing contents of: {path}");
            Console.WriteLine();

            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Directory '{path}' not found.");
                Console.ResetColor();
                return;
            }

            DirectoryInfo directory = new(path);

            // List subdirectories
            var folders = directory.GetDirectories();
            foreach (var folder in folders)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("/");
                Console.ResetColor();
                Console.WriteLine(folder.Name);
            }

            Console.WriteLine();

            // List files
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                string fileSize = FormatFileSizeHelper(file.Length);
                Console.WriteLine($"File: {file.Name,-30}  {file.CreationTime:yyyy-MM-dd}  {file.Extension,-6}  {fileSize}");
            }

            Console.WriteLine();
        }

        // Helper method to make filesizes more readable. 
        private static string FormatFileSizeHelper(double bytes)
        {
            const double KB = 1024;
            const double MB = KB * 1024;
            const double GB = MB * 1024;

            return bytes switch
            {
                >= GB => $"{bytes / GB:F2} GB",
                >= MB => $"{bytes / MB:F2} MB",
                >= KB => $"{bytes / KB:F2} KB",
                _ => $"{bytes} Bytes"
            };
        }
    }
}
