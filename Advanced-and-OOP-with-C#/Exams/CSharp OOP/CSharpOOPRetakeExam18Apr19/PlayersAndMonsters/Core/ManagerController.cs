namespace PlayersAndMonsters.Core
{
    using System.Text;

    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;

        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;

        private readonly IBattleField battleField;

        public ManagerController(
            IPlayerRepository playerRepository,
            ICardRepository cardRepository,
            IPlayerFactory playerFactory,
            ICardFactory cardFactory,
            IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;

            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;

            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer,
                player.GetType().Name, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard,
                card.GetType().Name, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer foundPlayer = this.playerRepository.Find(username);
            ICard foundCard = this.cardRepository.Find(cardName);

            foundPlayer.CardRepository.Add(foundCard);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards,
                foundCard.Name,
                foundPlayer.Username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyUserPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyUserPlayer);

            return string.Format(ConstantMessages.FightInfo,
                attackPlayer.Health,
                enemyUserPlayer.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
