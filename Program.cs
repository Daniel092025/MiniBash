using MiniBash.Models;

namespace MiniBash;


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input == "exit")
                break;

            HandleCommand(input);
        }
    }
    static void HandleCommand(string input)
    {
        string[] parts = input.Split(' ', 2);
        string command = parts[0];
        string args = parts.Length > 1 ? parts[1] : "";
        string[] commandArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] argsArray = args.Length > 0 ? args.Split(' ') : Array.Empty<string>();

        switch (command)
        {
            case "echo":
                Echo.Repeat(args);
                break;

            case "pwd":
                Pwd.Run();
                break;

            case "head":
                HEAD.Run(commandArgs);
                break;

            case "cat":
                CAT.Run(commandArgs);
                break;
    // Test om dette fungerer 
            case "tail":
                TAIL.Run(commandArgs);
                break;

            case "cp":
                CP.Run(commandArgs);
                break;

            case "ls":
            string? path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // How should we gather the path? User input? 
                Ls.List(path);
                break;
            default:
                Console.WriteLine($"Ukjent kommando: {command}");
                break;
        }

    }
}
