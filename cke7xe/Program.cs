﻿using cke7xe.Controller;
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
        int selectedOption = 0;
        while ((selectedOption = menuController.Menu()) != 0)
        {
            switch (selectedOption)
            {
                case 0: hengerController.WriteHengersToFile(hengerek, workingDirectory, fileName); break;
                case 10: Console.Clear(); break;
                case 1: hengerek.Add(menuController.MenuCreateHenger()); break;
                case 2: menuController.MenuUpdateHenger();break;
                case 3: menuController.MenuListHengers(hengerek); break;
                case 4: hengerController.FindHengerWithBiggestAtmero(hengerek); break;
                case 5: hengerController.GenerateReportCountByAtmero(hengerek,workingDirectory);break;
                case 6: menuController.MenuFindHengerAndWriteToFile(hengerController,workingDirectory); break;
            }
        }

    }

}