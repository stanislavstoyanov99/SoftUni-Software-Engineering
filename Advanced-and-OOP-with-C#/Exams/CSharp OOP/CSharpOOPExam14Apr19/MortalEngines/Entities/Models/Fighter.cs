using System;

using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        private const int INITIAL_HEALTH_POINTS = 200;
        private const int ATTACK_POINTS_TO_INCREASE = 50;
        private const int DEFENSE_POINTS_TO_DECREASE = 25;

        public Fighter(string name, double attackPoints, double defensePoints, double healthPoints)
            : base(name, attackPoints, defensePoints, healthPoints)
        {
            this.HealthPoints = INITIAL_HEALTH_POINTS;
        }

        public bool AggressiveMode
        {
            get => true;
            private set
            {
                this.AttackPoints += ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints -= DEFENSE_POINTS_TO_DECREASE;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;

                this.AttackPoints += ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints -= DEFENSE_POINTS_TO_DECREASE;
            }
            else
            {
                this.AggressiveMode = false;

                this.AttackPoints -= ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints += DEFENSE_POINTS_TO_DECREASE;
            }
        }

        public override string ToString()
        {
            if (this.AggressiveMode == true)
            {
                return base.ToString() + Environment.NewLine + " *Aggressive: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + " *Aggressive: OFF";
            }
        }
    }
}
