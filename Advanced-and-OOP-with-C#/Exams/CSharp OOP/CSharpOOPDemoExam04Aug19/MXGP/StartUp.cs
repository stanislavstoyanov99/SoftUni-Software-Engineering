namespace MXGP
{
    using MXGP.IO;
    using MXGP.Core;
    using MXGP.Factories;
    using MXGP.IO.Contracts;
    using MXGP.Repositories;
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IRepository<IMotorcycle> motorcycleRepository = new MotorcycleRepository();
            IRepository<IRace> raceRepository = new RaceRepository();
            IRepository<IRider> riderRepository = new RiderRepository();

            MotorcycleFactory motorcycleFactory = new MotorcycleFactory();

            // Judge system does not require dependency inversion principle to be observed!
            // Also Factories and CommandInterpreter are not required!

            IChampionshipController championshipController = new ChampionshipController(
            motorcycleRepository,
            raceRepository,
            riderRepository,
            motorcycleFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(championshipController);

            IEngine engine = new Engine(commandInterpreter, reader, writer);

            engine.Run();
        }
    }
}
