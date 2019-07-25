using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int INITIAL_HEALTH_POINTS = 250;

        public Advanced(ICardRepository cardRepository, string username, int health) 
            : base(cardRepository, username, health = INITIAL_HEALTH_POINTS)
        {

        }
    }
}
