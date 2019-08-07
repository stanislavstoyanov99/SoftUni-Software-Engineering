namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();

            this.car = new Car("BMW", "PK3209AT");
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            int expectedCount = 12;

            Assert.AreEqual(expectedCount, this.softPark.Parking.Count);
        }

        [Test]
        public void Test_If_ParkCar_Works_Correctly()
        {
            string expectedMessage = $"Car:{this.car.RegistrationNumber} parked successfully!";

            string actualMessage = this.softPark.ParkCar("A1", this.car);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void Test_If_ParkCar_ThrowsArgumentException_When_Parking_Spot_Does_Not_Exist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("D1", this.car));
        }

        [Test]
        public void Test_If_ParkCar_ThrowsArgumentException_When_Parking_Spot_Already_Exists()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A1", this.car));
        }

        [Test]
        public void Test_If_ParkCar_ThrowsArgumentException_When_Car_Is_Already_Parked()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<InvalidOperationException>(() =>
            this.softPark.ParkCar("A2", new Car("Audi", "PK3209AT")));
        }

        [Test]
        public void Test_If_RemoveCar_Works_Correctly()
        {
            this.softPark.ParkCar("A1", this.car);

            string expectedMessage = $"Remove car:{this.car.RegistrationNumber} successfully!";

            string actualMessage = this.softPark.RemoveCar("A1", this.car);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void Test_If_RemoveCar_ThrowsArgumentException_When_Parking_Spot_Does_Not_Exist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("D1", this.car));
        }

        [Test]
        public void Test_If_RemoveCar_ThrowsArgumentException_When_Current_Car_For_That_Spot_Does_Not_Exist()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<ArgumentException>(() =>
            this.softPark.RemoveCar("A1", new Car("Audi", "PK3209AT")));
        }
    }
}