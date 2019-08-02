using System;

using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialDatabase = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialDatabase);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int exptectedCount = 2;
            int actualCount = this.database.Count;

            Assert.AreEqual(exptectedCount, actualCount);
        }

        [Test]
        public void TestAddingCorrectly()
        {
            int expectedCount = 3;

            this.database.Add(3);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void TestRemovingCorrectly()
        {
            int expectedCount = 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingFromEmptyDatabase()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void TestFetchWorksCorrectly()
        {
            int[] expectedResult = this.database.Fetch();

            CollectionAssert.AreEqual(expectedResult, this.initialDatabase);
        }
    }
}