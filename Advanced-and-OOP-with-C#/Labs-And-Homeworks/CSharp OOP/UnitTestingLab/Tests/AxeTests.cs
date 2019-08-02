using NUnit.Framework;

using Skeleton.Contracts;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private IWeapon axe;
        private ITarget dummy;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            this.axe = new Axe(10, 1);
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void CheckIfConstructorPassesSuccessfully()
        {
            const int expectedAttackPoints = 10;
            const int expectedDurabilityPoints = 1;

            Assert.AreEqual(expectedAttackPoints, this.axe.AttackPoints);
            Assert.AreEqual(expectedDurabilityPoints, this.axe.DurabilityPoints);
        }

        [Test]
        public void TestIfAxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(0), "Axe durability does not change after attack.");
        }

        [Test]
        public void TestAttackingWithABrokenWeapon()
        {
            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //    axe.Attack(dummy);
            //});

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."),
                "Axe durability should be less or equal to zero in order axe to be ");
        }
    }
}
