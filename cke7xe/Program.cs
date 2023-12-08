using cke7xe.Controller;
using cke7xe.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        IHengerController controller = new HengerController();
        if (QuestionWantToGenerateDemoHengers()) {
            List<Henger> hengerek = controller.GenerateDemoHengers(50);
            foreach (var item in hengerek)
            {
                Console.WriteLine(item);
            }
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
}