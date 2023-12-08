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
                do
                {
                    ret.Atmero = MyInputToIntParser(Console.ReadLine());
                } while (ret.Atmero <0);
                ret.Id = HengerController.GetNextId();
                return ret;
            }
        }

        public int Menu()
        {
            Console.Clear();
            Console.WriteLine("0 - Kilépés(Mentés felülírja meglévő fájlt)");
            Console.WriteLine("1 - Henger Hozzáadása");
            Console.WriteLine("2 - Henger Modosítása");
            Console.WriteLine("3 - Legnagyobb Átmérő megkeresése");
            int ret = -1;
            do
            {
                ret = MyInputToIntParser(Console.ReadLine());
            } while (ret <0);
            return ret;

        }
        int MyInputToIntParser(string? input) {
            try
            {
                return int.Parse(input);

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return -2;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return -3;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                return -4;
            }
        }

        public Henger MenuUpdateHenger(int id)
        {
            throw new NotImplementedException();
        }
    }
}
