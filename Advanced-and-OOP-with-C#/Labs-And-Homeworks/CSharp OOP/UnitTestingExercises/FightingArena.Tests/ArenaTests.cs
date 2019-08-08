using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        private Warrior customWarrior;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.customWarrior = new Warrior("Pesho", 10, 100);

            this.attacker = new Warrior("Pesho", 50, 100);
            this.defender = new Warrior("Kiro", 80, 200);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void Test_If_Counter_Works_Correctly()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void Test_If_Enroll_Works_Correctly()
        {
            this.arena.Enroll(this.customWarrior);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.arena.Warriors.Count);
        }

        [Test]
        public void Test_If_Warrior_Already_Exists_When_Enrolling()
        {
            this.arena.Enroll(this.customWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(this.customWarrior));
        }

        [Test]
        public void Test_If_Fight_Works_Correctly()
        {
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            this.arena.Fight("Pesho", "Kiro");

            int expectedAttackerHp = 20;
            int expectedDefenderHP = 150;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void Test_If_Attacker_Is_Null_When_Fighting()
        {
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Slavi", "Kiro"));
        }

        [Test]
        public void Test_If_Defender_Is_Null_When_Fighting()
        {
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Pesho", "Slavi"));
        }
    }
}
