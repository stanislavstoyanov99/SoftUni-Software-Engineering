using ViceCity.Core;
using ViceCity.Core.Contracts;

namespace ViceCity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
