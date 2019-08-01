using System;

using Skeleton.Contracts;

namespace Skeleton.Models
{
    public class FakeWeapon : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;
        public int AttackPoints => this.attackPoints;

        public int DurabilityPoints => this.durabilityPoints;

        public void Attack(ITarget target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }
    }
}
