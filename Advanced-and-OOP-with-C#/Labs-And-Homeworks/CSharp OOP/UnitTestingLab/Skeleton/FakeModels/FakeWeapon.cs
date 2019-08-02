using Skeleton.Contracts;

namespace Skeleton.FakeModels
{
    public class FakeWeapon : IWeapon
    {
        private int durabilityPoints;

        public int AttackPoints => 10;

        public int DurabilityPoints => this.durabilityPoints;

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
            this.durabilityPoints -= 1;
        }
    }
}
