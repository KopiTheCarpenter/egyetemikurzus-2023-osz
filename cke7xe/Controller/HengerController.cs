using cke7xe.Model;
using System.Text.Json;

namespace cke7xe.Controller
{
    internal class HengerController : IHengerController
    {
        private static int _nextId;
        public static int GetNextId()
        {
            return _nextId++;
        }
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public List<Henger> GenerateDemoHengers(int count)
        {

            List<Henger> ret = new List<Henger>();
            for (int i = 0; i < count; i++)
            {
                ret.Add(new Henger
                {
                    Id = i,
                    Megnevezes = $"Demo{i}",
                    Atmero = Random.Shared.Next(90, 180)
                });
            }
            _nextId = count;
            return ret;
        }

        public void WriteHengersToFile(List<Henger> hengerek, string workingDirectory, string filename = "hengerek.json")
        {
            try
            {
                string filePath = Path.Combine(workingDirectory, filename);
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    foreach (var item in hengerek)
                    {
                        writer.WriteLine(JsonSerializer.Serialize(item, serializerOptions));
                    }

                }
            }
            catch (IOException e)
            {
                //IO Pokemon
                Console.WriteLine(e.Message);
            }
        }
    }
}
