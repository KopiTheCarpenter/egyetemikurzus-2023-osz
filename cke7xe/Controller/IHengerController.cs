using cke7xe.Model;

namespace cke7xe.Controller
{
    public interface IHengerController
    {
        public List<Henger> GenerateDemoHengers(int count);
        public void WriteSelectedHengerToFile(Henger henger, string workingDirectory);
        public void WriteHengersToFile(List<Henger> hengerek, string workingDirectory, string filename="hengerek.json");
        public List<Henger> ReadHengersFromFile(string workingDirectory, string filename = "hengerek.json");
        public Henger? FindHengerById(int id, List<Henger> hengerek);
        public int FindHengerWithBiggestAtmero(List<Henger> hengerek);
        public void GenerateReportCountByAtmero(List<Henger> hengerek, string workingDirectory, string filename = "CountByAtmeroRiport.txt");
    }
}
