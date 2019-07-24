using System;

using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        private const int INITIAL_HEALTH_POINTS = 100;
        private const int ATTACK_POINTS_TO_DECREASE = 40;
        private const int DEFENSE_POINTS_TO_INCREASE = 30;

        public Tank(string name, double attackPoints, double defensePoints, double healthPoints)
            : base(name, attackPoints, defensePoints, healthPoints)
        {
            this.HealthPoints = INITIAL_HEALTH_POINTS;
        }

        public bool DefenseMode
        {
            get => true;
            private set
            {
                this.AttackPoints -= ATTACK_POINTS_TO_DECREASE;
                this.DefensePoints += DEFENSE_POINTS_TO_INCREASE;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= ATTACK_POINTS_TO_DECREASE;
                this.DefensePoints += DEFENSE_POINTS_TO_INCREASE;
            }
            else
            {
                this.DefenseMode = false;

                this.AttackPoints += ATTACK_POINTS_TO_DECREASE;
                this.DefensePoints -= DEFENSE_POINTS_TO_INCREASE;
            }
        }

        public override string ToString()
        {
            if (this.DefenseMode == true)
            {
                return base.ToString() + Environment.NewLine + " *Defense: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + " *Defense: OFF";
            }
        }
    }
}
