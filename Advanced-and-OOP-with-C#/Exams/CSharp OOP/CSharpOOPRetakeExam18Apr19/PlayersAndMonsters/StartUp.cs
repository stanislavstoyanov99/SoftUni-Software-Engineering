namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IPlayerRepository playerRepository = new PlayerRepository();
            ICardRepository cardRepository = new CardRepository();
            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();
            IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController(
                playerRepository,
                cardRepository,
                playerFactory,
                cardFactory,
                battleField);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(managerController);

            IEngine engine = new Engine(commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}