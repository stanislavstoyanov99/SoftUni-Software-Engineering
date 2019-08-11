namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship("PeshoSpaceship", 200);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        { 
            Assert.AreEqual(this.spaceship.Name, "PeshoSpaceship");
            Assert.AreEqual(this.spaceship.Capacity, 200);
        }

        [Test]
        public void Test_If_Count_Works_Correctly()
        {
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void Test_If_Name_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => this.spaceship = new Spaceship(null, 200));
        }

        [Test]
        public void Test_If_Name_Is_Empty()
        {
            Assert.Throws<ArgumentNullException>(() => this.spaceship = new Spaceship(string.Empty, 200));
        }

        [Test]
        public void Test_If_Capacity_Is_Negative()
        {
            Assert.Throws<ArgumentException>(() => this.spaceship = new Spaceship("PeshoSpaceship", -100));
        }

        [Test]
        public void Test_If_Add_Works_Correctly()
        {
            Astronaut astronaut = new Astronaut("Pesho", 45);

            this.spaceship.Add(astronaut);

            Assert.AreEqual(1, this.spaceship.Count);
        }

        [Test]
        public void Test_If_Astronaut_Count_Throws_InvalidOperationException()
        {
            this.spaceship = new Spaceship("SlaviSpaceship", 1);

            Astronaut astronaut = new Astronaut("Pesho", 45);
            Astronaut secondAstronaut = new Astronaut("Slavi", 45);

            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(secondAstronaut));
        }

        [Test]
        public void Test_If_Astronaut_Already_Exists()
        {
            Astronaut astronaut = new Astronaut("Pesho", 45);

            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("Pesho", 100)));
        }

        [Test]
        public void Test_If_Remove_Works_Correctly()
        {
            Astronaut astronaut = new Astronaut("Pesho", 45);

            this.spaceship.Add(astronaut);

            bool actualResult = this.spaceship.Remove("Pesho");

            Assert.AreEqual(true, actualResult);
        }

        [Test]
        public void Test_If_Astronaut_OxygenInPercentage_Works_Correctly()
        {
            Astronaut astronaut = new Astronaut("Pesho", 45);

            Assert.AreEqual(45, astronaut.OxygenInPercentage);
        }
    }
}