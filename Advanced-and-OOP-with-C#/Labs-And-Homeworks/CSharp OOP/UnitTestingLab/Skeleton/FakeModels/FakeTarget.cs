using Skeleton.Contracts;

namespace Skeleton.FakeModels
{
    public class FakeTarget : ITarget
    {
        private int health;

        public int Health => this.health;

        public int GiveExperience() { return 20; }

        public bool IsDead() { return true; }

        public void TakeAttack(int attackPoints)
        {
            this.health -= attackPoints;
        }
    }
}
