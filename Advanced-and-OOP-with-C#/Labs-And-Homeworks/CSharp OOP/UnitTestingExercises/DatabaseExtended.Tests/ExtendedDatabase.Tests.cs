using System;

using NUnit.Framework;
using ExtendedDatabase;

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
        public void Test_If_AddRange_With_Empty_People()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>
                (() => this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_Add_Range_With_Null_People()
        {
            Person[] people = new Person[3];

            Assert.Throws<NullReferenceException>(() =>
                    this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_AddRange_Throws_Exception()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>
                (() => this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));
        }


        [Test]
        public void Test_If_Add_Works_Correctly()
        {
            this.extendedDatabase.Remove();
            this.extendedDatabase.Add(new Person(333, "Slavi"));

            Assert.AreEqual(16, this.extendedDatabase.Count);
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

        [Test]
        public void Test_If_Remove_Works_Correctly()
        {
            int expectedCount = 15;

            this.extendedDatabase.Remove();

            Assert.AreEqual(expectedCount, this.extendedDatabase.Count);
        }

        [Test]
        public void Test_Removing_From_Empty_Database()
        {
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void Test_If_Name_Is_Empty_In_Finding_Method()
        {
            string targetName = string.Empty;

            Assert.Throws<ArgumentNullException>
                (() => this.extendedDatabase.FindByUsername(targetName));
        }

        [Test]
        public void Test_If_Name_Is_Null_In_Finding_Method()
        {
            string targetName = null;

            Assert.Throws<ArgumentNullException>
                (() => this.extendedDatabase.FindByUsername(targetName));
        }

        [Test]
        public void Test_If_No_Username_Is_Found()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.FindByUsername("Kiro"));
        }

        [Test]
        public void Test_If_Find_By_Username_Works_Correctly()
        {
            Person person = new Person(1, "Username1");

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            Person expectedPerson = this.extendedDatabase.FindByUsername(person.UserName);

            Assert.AreEqual(expectedPerson, person);
        }

        [Test]
        public void Test_If_Id_Is_A_Positive_Number()
        {
            int id = -10;

            Assert.Throws<ArgumentOutOfRangeException>
                (() => this.extendedDatabase.FindById(id));
        }

        [Test]
        public void Test_If_No_Id_Is_Found()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.FindById(200));
        }

        [Test]
        public void Test_If_Find_By_Id_Works_Correctly()
        {
            Person person = new Person(1, "Username1");

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            Person expectedPerson = this.extendedDatabase.FindById(1);

            Assert.AreEqual(expectedPerson, person);
        }
    }
}