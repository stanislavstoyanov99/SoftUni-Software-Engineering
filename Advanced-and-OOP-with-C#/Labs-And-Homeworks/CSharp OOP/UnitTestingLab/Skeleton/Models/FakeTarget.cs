using Skeleton.Contracts;
using System;

namespace Skeleton.Models
{
    public class FakeTarget : ITarget
    {
        private int health;

        public int Health => this.health;

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            if (this.IsDead())
            {
                throw new InvalidOperationException("Dummy is dead.");
            }

            this.health -= attackPoints;
        }
    }
}
