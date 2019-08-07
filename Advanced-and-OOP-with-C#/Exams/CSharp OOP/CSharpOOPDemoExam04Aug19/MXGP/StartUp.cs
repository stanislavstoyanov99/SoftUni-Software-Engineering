namespace MXGP
{
    using MXGP.IO;
    using MXGP.Core;
    using MXGP.Factories;
    using MXGP.IO.Contracts;
    using MXGP.Repositories;
    using MXGP.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            //MotorcycleRepository motorcycleRepository = new MotorcycleRepository();
            //RaceRepository raceRepository = new RaceRepository();
            //RiderRepository riderRepository = new RiderRepository();

            //MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            IChampionshipController championshipController = new ChampionshipController();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(championshipController);

            IEngine engine = new Engine(commandInterpreter, reader, writer);

            engine.Run();
        }
    }
}
