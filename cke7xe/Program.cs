using cke7xe.Controller;
using cke7xe.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        IHengerController controller = new HengerController();
        string workingDirectory = QuestionWhereIsWorkDirectiory(AppContext.BaseDirectory);
        string fileName = QuestionWhatIsNameOfFile();
        if (QuestionWantToGenerateDemoHengers()) {
            List<Henger> hengerek = controller.GenerateDemoHengers(50);
            controller.WriteHengersToFile(hengerek, workingDirectory);
        }
    }
    static bool QuestionWantToGenerateDemoHengers()
    {
        Console.Clear();
        Console.WriteLine("Generáljon a program demo hengereket?");
        Console.WriteLine("0 - nem");
        Console.WriteLine("1 - igen");
        return Console.ReadLine() == "1";

    }
    static string QuestionWhereIsWorkDirectiory(string defaultDirectory)
    {
        Console.Clear();
        Console.WriteLine("Melyik mappában dolgozzon a program?");
        Console.WriteLine($"Alapértelmezett(ha nem ad meg semmit vagy rossz útvonalat ad meg):");
        Console.WriteLine(defaultDirectory);
        string? line = Console.ReadLine();
        if (Directory.Exists(line))
        {
            return line;
        }
        else
        {
            var e = new DirectoryNotFoundException("Mappa nem található");
            Console.WriteLine(e.Message);
            Console.WriteLine("Alapértelmezett útvonal lesz használva!");
        }
        return defaultDirectory;
    }
    static string QuestionWhatIsNameOfFile(string defaultFileName = "hengerek.json")
    {
        Console.Clear();
        Console.WriteLine("Mi legyen a fájl neve, ahova hengereket tárolja?(Fájl kiterjesztés megadása szükséges(txt/json))");
        Console.WriteLine($"Alapértelmezett({defaultFileName})");
        string? line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line) || !line.EndsWith(".json") || !line.EndsWith(".txt"))
            return defaultFileName;
        else
            return line;
    }
}