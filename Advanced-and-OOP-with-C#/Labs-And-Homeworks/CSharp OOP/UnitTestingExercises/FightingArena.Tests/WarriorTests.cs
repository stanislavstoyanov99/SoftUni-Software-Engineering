using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [Test]
        public void Test_If_Constructor_Works_Correctly()
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
        public void Test_If_Warrior_Name_Is_Null()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(null, 25, 100);
            });
        }

        [Test]
        public void Test_Warrior_WhiteSpace_Name()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("    ", 25, 100);
            });
        }

        [Test]
        public void Test_If_Damage_Is_Zero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 10);
            });
        }

        [Test]
        public void Test_If_Damage_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", -10, 50);
            });
        }

        [Test]
        public void Test_If_Health_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 15, -10);
            });
        }

        [Test]
        public void Test_If_Attack_Works_Correctly()
        {
            int expectedAttackerHp = 95;
            int expectedDefenderHP = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void Test_Attacking_With_Low_Hp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior deffender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void Test_Attacking_Enemy_With_Low_Hp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior deffender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void Test_Attacking_Too_Strong_Enemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 50);
            Warrior deffender = new Warrior("Gosho", 80, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void Test_If_Attack_Works_Correctly_When_ЕnemyDamage_Is_Greater_Than_Deffender_Hp()
        {
            Warrior attacker = new Warrior("Pesho", 100, 100);
            Warrior defender = new Warrior("Gosho", 200, 50);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Test_If_Attack_Works_Correctly_When_AttackerDamage_Is_Greater_Than_Deffender_Hp()
        {
            Warrior attacker = new Warrior("Pesho", 100, 100);
            Warrior defender = new Warrior("Gosho", 50, 50);

            int expectedDefenderHp = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}