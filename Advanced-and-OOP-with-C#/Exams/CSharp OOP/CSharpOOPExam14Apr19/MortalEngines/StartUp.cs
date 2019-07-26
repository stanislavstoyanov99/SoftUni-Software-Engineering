using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IMachinesManager machinesManager = new MachinesManager();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(machinesManager);
            IWriter writer = new Writer();

            IEngine engine = new Engine(commandInterpreter, writer);
            engine.Run();
        }
    }
}