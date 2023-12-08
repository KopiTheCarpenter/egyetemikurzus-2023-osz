using cke7xe.Model;

namespace cke7xe.Controller
{
    public class ConsoleMenuController : IMenuController
    {
        public bool QuestionWantToGenerateDemoHengers()
        {
            Console.Clear();
            Console.WriteLine("Generáljon a program demo hengereket vagy olvassa be a megadott fájlból?");
            Console.WriteLine("0 - Fájlból olvasás");
            Console.WriteLine("1 - Demo Generálás");
            return Console.ReadLine() == "1";

        }
        public string QuestionWhereIsWorkDirectiory(string defaultDirectory)
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
        public string QuestionWhatIsNameOfFile(string defaultFileName = "hengerek.json")
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

        public Henger MenuCreateHenger()
        {
            {
                Henger ret = new Henger();
                Console.Clear();
                Console.WriteLine("Henger Megnevezése:");
                ret.Megnevezes = Console.ReadLine();
                Console.WriteLine("Henger Átmerő:");
                while (true)
                {
                    try
                    {
                        ret.Atmero = int.Parse(Console.ReadLine());
                        ret.Id = HengerController.GetNextId();
                        return ret;
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
