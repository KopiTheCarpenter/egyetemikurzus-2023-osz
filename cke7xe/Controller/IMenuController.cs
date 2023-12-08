using cke7xe.Model;

namespace cke7xe.Controller
{
    public interface IMenuController
    {
        public bool QuestionWantToGenerateDemoHengers();
        public string QuestionWhereIsWorkDirectiory(string defaultDirectory);
        public string QuestionWhatIsNameOfFile(string defaultFileName = "hengerek.json");
        public int Menu();
        public Henger MenuCreateHenger();
        public Henger MenuUpdateHenger();
        public int QuestionWhichHengerToWriteToFile();
        public void MenuListHengers(List<Henger> hengers);
    }
}
