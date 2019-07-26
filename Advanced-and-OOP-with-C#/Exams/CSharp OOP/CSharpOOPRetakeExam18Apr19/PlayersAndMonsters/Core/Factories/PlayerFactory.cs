namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type);

            if (playerType == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerNotFoundException);
            }

            ICardRepository cardRepository = new CardRepository();

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType, cardRepository, username);

            return player;
        }
    }
}
