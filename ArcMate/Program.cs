using ArcMate;

namespace AzulArchives;

class Program
{
    static void Main()
    {
        var svc = new ArchiveService();
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("                    ArcMate v1.0");
            Console.WriteLine("              Archive Management System");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            Console.WriteLine("\n  [1] Create Archive");
            Console.WriteLine("  [2] Create Archive with Root Folder");
            Console.WriteLine("  [3] Extract Archive");
            Console.WriteLine("  [4] Extract Archive (Verbose)");
            Console.WriteLine("  [5] List Archive Contents");
            Console.WriteLine("  [6] Exit");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();
            Console.Write("\n  Select an option: ");

            switch (Console.ReadLine()?.Trim() ?? "")
            {
                case "1":
                    Console.WriteLine();
                    string folderPath = GetInput("  Enter folder path to compress: ");
                    svc.Create(folderPath);
                    Pause();
                    break;
                case "2":
                    Console.WriteLine();
                    string folderPathWithRoot = GetInput("  Enter folder path to compress with root: ");
                    svc.CreateWithRoot(folderPathWithRoot);
                    Pause();
                    break;
                case "3":
                    Console.WriteLine();
                    string extractPath = GetInput("  Enter archive path to extract: ");
                    svc.Extract(extractPath);
                    Pause();
                    break;
                case "4":
                    Console.WriteLine();
                    string extractPathVerbose = GetInput("  Enter archive path to extract: ");
                    svc.ExtractVerbose(extractPathVerbose);
                    Pause();
                    break;
                case "5":
                    Console.WriteLine();
                    string listPath = GetInput("  Enter archive path to list contents: ");
                    svc.ListContents(listPath);
                    Pause();
                    break;
                case "6":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n  Thank you for using ArcMate!");
                    Console.ResetColor();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  [ERROR] Invalid input. Please select 1-6.");
                    Console.ResetColor();
                    Pause();
                    break;
            }
        }
    }
    public static string GetInput(string prompt)
    {
        Console.Write(prompt);
        var input = Console.ReadLine()?.Trim() ?? "";
        return input;
    }
    public static void Pause()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n  Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
