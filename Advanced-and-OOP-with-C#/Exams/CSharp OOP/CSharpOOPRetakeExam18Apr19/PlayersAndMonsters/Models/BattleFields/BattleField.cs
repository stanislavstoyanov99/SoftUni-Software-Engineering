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

            IncreaseHealthPoints(attackPlayer);

            IncreaseHealthPoints(enemyPlayer);

            int attackerDamagePoints = GetDamagePoints(attackPlayer);

            int enemyDamagePoints = GetDamagePoints(enemyPlayer);

            while (true)
            {
                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }

        private int GetDamagePoints(IPlayer player)
        {
            return player
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);
        }

        private void IncreaseHealthPoints(IPlayer player)
        {
            player.Health += player
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);
        }

        private void IncreasePoints(IPlayer player)
        {
            player.Health += HEALTH_TO_INCREASE;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += DAMAGE_POINTS_TO_INCREASE;
            }
        }
    }
}
