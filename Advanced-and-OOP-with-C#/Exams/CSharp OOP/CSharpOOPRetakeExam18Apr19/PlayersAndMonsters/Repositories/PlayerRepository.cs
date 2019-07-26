namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerNotFoundException);
            }

            bool isPlayerExists = this.players.Any(p => p.Username == player.Username);

            if (isPlayerExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAllreadyExistsException,
                    player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players
                .FirstOrDefault(p => p.Username == username);

            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerNotFoundException);
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerNotFoundException);
            }

            return this.players.Remove(player);
        }
    }
}
