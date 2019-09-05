using StorageMaster.Core;
using StorageMaster.Core.Contracts;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
