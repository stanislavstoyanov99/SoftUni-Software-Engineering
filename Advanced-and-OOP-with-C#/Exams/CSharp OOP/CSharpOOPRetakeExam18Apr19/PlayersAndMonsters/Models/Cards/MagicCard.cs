namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int INITIAL_DAMAGE_POINTS = 5;
        private const int INITIAL_HEALTH_POINTS = 80;

        public MagicCard(string name,
            int damagePoints = INITIAL_DAMAGE_POINTS,
            int healthPoints = INITIAL_HEALTH_POINTS) 
            : base(name, damagePoints, healthPoints)
        {

        }
    }
}
