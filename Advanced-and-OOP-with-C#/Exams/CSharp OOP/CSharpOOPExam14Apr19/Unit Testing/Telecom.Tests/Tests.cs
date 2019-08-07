namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Samsung", "Galaxy S6 Edge");
        }

        [Test]
        public void Test_If_Phone_Make_Is_Null()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "Galaxy S6 Edge"));
        }

        [Test]
        public void Test_If_Phone_Make_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Phone(string.Empty, "Galaxy S6 Edge"));
        }

        [Test]
        public void Test_If_Phone_Model_Is_Null()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Samsung", null));
        }

        [Test]
        public void Test_If_Phone_Model_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Samsung", string.Empty));
        }

        [Test]
        public void Test_If_Add_Contact_Works_Correctly()
        {
            this.phone.AddContact("Pesho", "0832732723723");

            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void Test_If_Add_Contact_Throws_InvalidOperationException_When_Contact_Already_Exists()
        {
            this.phone.AddContact("Pesho", "0832732723723");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Pesho", "0832732723723"));
        }

        [Test]
        public void Test_If_Call_Works_Correctly()
        {
            this.phone.AddContact("Pesho", "0832732723723");

            string expectedResult = $"Calling Pesho - 0832732723723...";
            string actualResult = this.phone.Call("Pesho");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_If_Call_Throws_InvalidOperationException_When_Contact_Does_Not_Exist()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Slavi"));
        }
    }
}