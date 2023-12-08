using cke7xe.Controller;
using cke7xe.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        IHengerController hengerController = new HengerController();
        IMenuController menuController = new ConsoleMenuController();
        string workingDirectory = menuController.QuestionWhereIsWorkDirectiory(AppContext.BaseDirectory);
        string fileName = menuController.QuestionWhatIsNameOfFile();
        List<Henger>? hengerek;
        //hengerek = controller.GenerateDemoHengers(50);
        //controller.WriteHengersToFile(hengerek, workingDirectory, fileName);
        if (menuController.QuestionWantToGenerateDemoHengers())
        {
            hengerek = hengerController.GenerateDemoHengers(50);
        }
        else
        {
            hengerek = hengerController.ReadHengersFromFile(workingDirectory, fileName);
        }
    }

}