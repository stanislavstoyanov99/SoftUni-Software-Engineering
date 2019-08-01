using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            this.axe = new Axe(10, 1);
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void CheckIfConstructorPassesSuccessfully()
        {
            Axe fakeAxe = new Axe(10, 1);

            Assert.AreEqual(fakeAxe.AttackPoints, this.axe.AttackPoints);
            Assert.AreEqual(fakeAxe.DurabilityPoints, this.axe.DurabilityPoints);
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
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
