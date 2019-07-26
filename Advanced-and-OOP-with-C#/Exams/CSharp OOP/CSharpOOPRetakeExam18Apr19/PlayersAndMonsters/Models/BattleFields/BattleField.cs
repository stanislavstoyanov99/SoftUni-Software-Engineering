namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;

    public class BattleField : IBattleField
    {
        private const int HEALTH_TO_INCREASE = 40;
        private const int DAMAGE_POINTS_TO_INCREASE = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException(ExceptionMessages.PlayerDeadException);
            }

            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                IncreasePoints(attackPlayer);
            }

            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                IncreasePoints(enemyPlayer);
            }

            attackPlayer.Health += attackPlayer
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            enemyPlayer.Health += enemyPlayer
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            while (true)
            {
                int attackerDamagePoints = attackPlayer
                    .CardRepository
                    .Cards
                    .Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer
                    .CardRepository
                    .Cards
                    .Sum(c => c.DamagePoints);

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }

        private static void IncreasePoints(IPlayer player)
        {
            player.Health += HEALTH_TO_INCREASE;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += DAMAGE_POINTS_TO_INCREASE;
            }
        }
    }
}
