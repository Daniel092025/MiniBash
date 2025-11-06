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

        switch (command)
        {
            case "echo":
                Echo.Repeat(args);
                break;

            case "pwd":
                Pwd.Run();
                break;

            default:
                Console.WriteLine($"Ukjent kommando: {command}");
                break;
        }

    }
}
