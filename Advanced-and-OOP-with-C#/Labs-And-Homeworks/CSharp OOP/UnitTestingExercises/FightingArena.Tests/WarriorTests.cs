using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDmg = 15;
            int expectedHp = 100;

            Warrior warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void TestEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(" ", 25, 100);
            });
        }

        [Test]
        public void TestWhiteSpaceName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("    ", 25, 100);
            });
        }

        [Test]
        public void TestIfDamageIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 10);
            });
        }

        [Test]
        public void TestIfDamageIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", -10, 50);
            });
        }

        [Test]
        public void TestIfHealthIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 15, -10);
            });
        }

        [Test]
        public void TestIfAttackWorksCorrectly()
        {
            int expectedAttHp = 95;
            int expectedDefHp = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttHp, attacker.HP);
            Assert.AreEqual(expectedDefHp, defender.HP);
        }

        [Test]
        public void TestAttackingWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior deffender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void TestAttackingEnemyWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior deffender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }
    }
}