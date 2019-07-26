using System;

using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        private const int INITIAL_HEALTH_POINTS = 100;
        private const int ATTACK_POINTS_TO_DECREASE = 40;
        private const int DEFENSE_POINTS_TO_INCREASE = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - ATTACK_POINTS_TO_DECREASE, defensePoints + DEFENSE_POINTS_TO_INCREASE, INITIAL_HEALTH_POINTS)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

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
            string result = string.Empty;

            if (this.DefenseMode == true)
            {
                result = base.ToString() + Environment.NewLine + " *Defense: ON";
            }
            else
            {
                result = base.ToString() + Environment.NewLine + " *Defense: OFF";
            }

            return result;
        }
    }
}
