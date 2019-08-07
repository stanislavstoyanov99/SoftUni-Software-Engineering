namespace TheRace.Tests
{
    using System;

    using NUnit.Framework;

    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitMotorcycle motorcycle;
        private UnitRider rider;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();

            this.motorcycle = new UnitMotorcycle("BMW", 60, 250);
            this.rider = new UnitRider("Pesho", this.motorcycle);
        }

        [Test]
        public void Test_If_Add_Rider_Works_Correctly()
        {
            string actualMessage = this.raceEntry.AddRider(this.rider);

            string expectedMessage = "Rider Pesho added in race.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void Test_If_Add_Rider_Throws_InvalidOperationException_When_Rider_Is_Null()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void Test_If_Add_Rider_Throws_Exception_With_Already_Added_Rider()
        {
            this.raceEntry.AddRider(this.rider);

            var exception = Assert.Throws<InvalidOperationException>(() =>
            this.raceEntry.AddRider(this.rider));

            string expectedMessage = "Rider Pesho is already added.";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void Test_If_CalculateAverageHorsePower_Throws_InvalidOperationException()
        {
            this.raceEntry.AddRider(this.rider);

            var exception = Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());

            string expectedMessage = "The race cannot start with less than 2 participants.";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void Test_If_CalculateAverageHorsePower_Works_Correctly()
        {
            // Arrange

            UnitMotorcycle secondRiderMotorcycle = new UnitMotorcycle("Kawasaki", 60, 350);
            UnitRider secondRider = new UnitRider("Kiro", secondRiderMotorcycle);

            // Act
            this.raceEntry.AddRider(this.rider);
            this.raceEntry.AddRider(secondRider);

            // Assert
            int expectedResult = 60;
            double actualResult = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}