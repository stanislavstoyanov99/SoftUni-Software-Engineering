namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

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

            IEngine engine = new Engine(managerController, reader, writer);
            engine.Run();
        }
    }
}