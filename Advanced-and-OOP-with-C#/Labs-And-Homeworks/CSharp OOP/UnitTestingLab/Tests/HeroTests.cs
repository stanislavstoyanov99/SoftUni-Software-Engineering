using NUnit.Framework;
using Skeleton.Contracts;
using Skeleton.Models;

namespace Tests
{
    [TestFixture]
    public class HeroTests
    {
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            ITarget fakeTarget = new FakeTarget();
            IWeapon fakeWeapon = new FakeWeapon();

            Hero hero = new Hero(HeroName, fakeWeapon);

            // Assert
        }
    }
}
