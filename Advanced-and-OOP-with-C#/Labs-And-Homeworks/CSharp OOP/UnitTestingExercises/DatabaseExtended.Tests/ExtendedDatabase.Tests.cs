using System;

using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Pesho");

            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void Test_Person_Constructor()
        {
            Assert.AreEqual(1, this.person.Id);
            Assert.AreEqual("Pesho", this.person.UserName);
        }

        [Test]
        public void Test_Database_Count()
        {
            Assert.AreEqual(16, this.extendedDatabase.Count);
        }

        [Test]
        public void Test_If_AddRange_Throws_Exception()
        {
            Person[] people = new Person[17];
            Assert.Throws<ArgumentException>
                (() => this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_If_Add_Throws_First_Exception()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(this.person));
        }

        [Test]
        public void Test_If_Add_Throws_Second_Exception()
        {
            this.extendedDatabase.Remove();

            Person targetPerson = new Person(100, "Username10");

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(targetPerson));
        }
        
        [Test]
        public void Test_If_Add_Throws_Third_Exception()
        {
            this.extendedDatabase.Remove();

            Person targetPerson = new Person(1, "Username1");

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(targetPerson));
        }
    }
}