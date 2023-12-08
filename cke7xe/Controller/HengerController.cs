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
        readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
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

        public List<Henger> ReadHengersFromFile(string workingDirectory, string filename = "hengerek.json")
        {
            List<Henger> ret = new List<Henger>();

            try
            {
                using (var reader = File.OpenText(Path.Combine(workingDirectory, filename)))
                {
                    string? line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "{")
                        {
                            string? temp = null;
                            while ((temp = reader.ReadLine()) != "}")
                            {
                                if(temp != null)
                                line += temp.Trim();
                            }
                            line += "}";
                        }
                        Henger? h = JsonSerializer.Deserialize<Henger>(line, serializerOptions);
                        if (h != null) ret.Add(h);
                    }
                }

            }
            catch (IOException e)
            {
                //IO Pokemon
                Console.WriteLine(e.Message);
            }
            if (ret.Count > 0) _nextId = ret.Max(h => h.Id)+1;
            else _nextId = 1;
            return ret;
        }

        public Henger? FindHengerById(int id, List<Henger> hengerek)
        {
            if (hengerek == null || hengerek.Count < 1) return null;
            return hengerek.Find(x => x.Id == id);
        }
        public int FindHengerWithBiggestAtmero(List<Henger> hengerek)
        {
            return hengerek.Max(x => x.Atmero);
        }
        public void GenerateReportCountByAtmero(List<Henger> hengerek, string workingDirectory, string filename ="CountByAtmeroRiport.txt") {
            try
            {
                string filePath = Path.Combine(workingDirectory, filename);
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    foreach (var line in hengerek.GroupBy(h => h.Atmero)
                        .Select(group => new {
                            Atmero = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Atmero))
                    {
                        writer.WriteLine($"{line.Atmero}cm: {line.Count}");
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
