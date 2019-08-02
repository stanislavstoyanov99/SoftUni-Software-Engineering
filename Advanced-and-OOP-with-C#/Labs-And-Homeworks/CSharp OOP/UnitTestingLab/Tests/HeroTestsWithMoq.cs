using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Tests
{
    [TestFixture]
    public class HeroTestsWithMoq
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            fakeTarget.Setup(t => t.GiveExperience()).Returns(20);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            Hero hero = new Hero("Pesho", fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }
}
