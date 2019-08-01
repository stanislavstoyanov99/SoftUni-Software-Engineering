using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void CreateDummy()
        {
            this.dummy = new Dummy(20, 10);
        }

        [Test]
        public void CheckIfConstructorPassesSuccessfully()
        {
            // Check only health points, because experience is not property
            const int expectedHealthPoints = 10;

            Assert.AreEqual(expectedHealthPoints, this.dummy.Health, "Constructor failed!");
        }

        [Test]
        public void CheckIfDummyLossesHealthAfterAttack()
        {
            this.dummy.TakeAttack(5);

            Assert.That(this.dummy.Health, Is.EqualTo(15), "Dummy does not lose health after attack.");
        }

        [Test]
        public void CheckIfDummyIsDeadWhenAttacked()
        {
            this.dummy.TakeAttack(20);

            Assert.That(() => this.dummy.TakeAttack(1),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."),
                "Dummy can't be attacked because he's dead");
        }

        [Test]
        public void CheckIfDeadDummyGivesExperiencePoints()
        {
            this.dummy.TakeAttack(20);
            // dummy is dead

            Assert.That(this.dummy.GiveExperience(), Is.EqualTo(10),
                "Dummy cannot give experience points because he's dead.");
        }

        [Test]
        public void CheckIfAliveDummyGivesExperiencePoints()
        {
            this.dummy.TakeAttack(10);
            // dummy is alive

            Assert.That(() => this.dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."),
                "Dummy cannot give experience points because he's alive.");
        }
    }
}
