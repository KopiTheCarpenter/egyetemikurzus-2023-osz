using cke7xe.Model;

namespace cke7xe.Controller
{
    internal class HengerController : IHengerController
    {
        private static int _nextId;
        public static int GetNextId()
        {
            return _nextId++;
        }

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
    }
}
