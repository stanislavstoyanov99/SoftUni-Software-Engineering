namespace MXGP
{
    using MXGP.Core;
    using MXGP.Core.Contracts;
    using MXGP.Factories;
    using MXGP.IO;
    using MXGP.IO.Contracts;
    using MXGP.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            MotorcycleRepository motorcycleRepository = new MotorcycleRepository();
            RaceRepository raceRepository = new RaceRepository();
            RiderRepository riderRepository = new RiderRepository();

            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            IChampionshipController championshipController = new ChampionshipController(
                motorcycleFactory,
                motorcycleRepository,
                raceRepository,
                riderRepository);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(championshipController);

            IEngine engine = new Engine(commandInterpreter, reader, writer);

            engine.Run();
        }
    }
}
