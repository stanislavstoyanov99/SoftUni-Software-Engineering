namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int INITIAL_DAMAGE_POINTS = 120;
        private const int INITIAL_HEALTH_POINTS = 5;

        public TrapCard(string name,
            int damagePoints = INITIAL_DAMAGE_POINTS,
            int healthPoints = INITIAL_HEALTH_POINTS) 
            : base(name, damagePoints, healthPoints)
        {

        }
    }
}
