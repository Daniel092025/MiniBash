namespace MiniBash.Models;


public class Ls
{
    public static List()
    {

    }

    static string FormatFileSizeHelper(double bytes)
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


/*




string path = "C:/Users/Instruktor.P-02506/Documents/Kurs";
Console.WriteLine($"GetFolderPath: {path}");
DirectoryInfo ls = new(path);

var folders = ls.GetDirectories();

foreach (var folder in folders)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write("/");
    Console.ResetColor();
    Console.Write($"{folder.Name}\n");
}


var files = ls.GetFiles();

foreach (var file in files)
{
    string fileSize = FormatFileSizeHelper(file.Length);
    Console.WriteLine($"File: '{file.Name,-30}'   {file.CreationTime.Date:yyyy-MM-dd}  {file.Extension,-6}  {fileSize}");
}

   
    
}    

*/