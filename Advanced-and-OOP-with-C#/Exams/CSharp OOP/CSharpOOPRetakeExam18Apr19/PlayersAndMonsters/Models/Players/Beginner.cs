using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int INITIAL_HEALTH_POINTS = 50;

        public Beginner(ICardRepository cardRepository, string username, int health) 
            : base(cardRepository, username, health = INITIAL_HEALTH_POINTS)
        {

        }
    }
}
