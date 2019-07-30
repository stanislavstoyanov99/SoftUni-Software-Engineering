namespace CustomTestingFramework.Tests
{
    using System;

    using CustomTestingFramework.Asserts;
    using CustomTestingFramework.Attributes;

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void ShouldSumValues()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 5;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldSumValuesSecond()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 6;

            Assert.AreNotEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldAccessArrayElement()
        {
            string[] input = new string[5];
            Assert.Throws<IndexOutOfRangeException>(() => input[12] == "Lalala");
        }

        [TestMethod]
        public void ShouldAccessObject()
        {
            string input = null;
            Assert.Throws<NullReferenceException>(() => input.Contains("Kiro"));
        }
    }
}
