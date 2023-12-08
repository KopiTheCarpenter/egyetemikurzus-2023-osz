using cke7xe.Model;

namespace cke7xe.Controller
{
    internal interface IHengerController
    {
        public List<Henger> GenerateDemoHengers(int count);
        public void WriteHengersToFile(List<Henger> hengerek, string workingDirectory, string filename="hengerek.json");
    }
}
