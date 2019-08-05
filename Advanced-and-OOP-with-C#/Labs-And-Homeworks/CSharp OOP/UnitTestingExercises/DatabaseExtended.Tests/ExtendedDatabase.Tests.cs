using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person testPerson1;
        private Person testPerson2;
        private Person testPerson3;

        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.testPerson1 = new Person(1, "Pesho");
            this.testPerson2 = new Person(2, "Kiro");
            this.testPerson3 = new Person(3, "Gosho");

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson2, testPerson3);
        }

        [Test]
        public void Test_Person_Constructor()
        {
            Assert.AreEqual(1, this.testPerson1.Id);
            Assert.AreEqual("Pesho", this.testPerson1.UserName);
        }

        [Test]
        public void Test_Database_Constructor()
        {
            Assert.AreEqual(2, this.extendedDatabase.Count);
        }

        [Test]
        public void Test_If_AddRange_Works_With_Empty_People()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>
                (() => this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_Add_Range__Works_With_Null_People()
        {
            Person[] people = new Person[3];

            Assert.Throws<NullReferenceException>(() =>
                    this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_AddRange_With_More_People_Than_Allowed()
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
            this.extendedDatabase.Add(this.testPerson1);

            Assert.AreEqual(3, this.extendedDatabase.Count);
        }

        [Test]
        public void Test_Add_Person_In_Full_Database()
        {         
            Person[] people = new Person[15];

            for (int i = 0; i < people.Length; i++)
            {
                 people[i] = new Person(i + 10, $"Username{i}");
            }

            var extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            extendedDatabase.Add(this.testPerson1);

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(this.testPerson2));
        }

        [Test]
        public void Test_Already_Added_PersonUsername()
        {
            this.extendedDatabase.Add(this.testPerson1);

            Person targetPerson = new Person(300, "Pesho");

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(targetPerson));
        }
        
        [Test]
        public void Test_Already_Added_PersonId()
        {
            Person targetPerson = new Person(2, "Stefan");

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.Add(targetPerson));
        }

        [Test]
        public void Test_If_Remove_Works_Correctly()
        {
            int expectedCount = 1;

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
                (() => this.extendedDatabase.FindByUsername(this.testPerson1.UserName));
        }

        [Test]
        public void Test_If_Find_By_Username_Works_Correctly()
        {
            Person actualPerson = this.extendedDatabase
                .FindByUsername(this.testPerson2.UserName);

            Assert.AreEqual(this.testPerson2, actualPerson);
        }

        [Test]
        public void Test_If_Find_By_Username_Is_Case_Sensitive()
        {
            this.extendedDatabase.Add(this.testPerson1);

            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase.FindByUsername(this.testPerson1.UserName.ToLower()));
        }

        [Test]
        public void Test_If_Id_Is_A_Positive_Number()
        {
            int id = -10;

            Assert.Throws<ArgumentOutOfRangeException>
                (() => this.extendedDatabase
                .FindById(id));
        }

        [Test]
        public void Test_If_No_Id_Is_Found()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.extendedDatabase
                .FindById(200));
        }

        [Test]
        public void Test_If_Find_By_Id_Works_Correctly()
        {
            Person actualPerson = this.extendedDatabase
                .FindById(2);

            Assert.AreEqual(this.testPerson2, actualPerson);
        }
    }
}