namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption => defaultFuelConsumption;

        public void Drive(double kilometers)
        {
            double fuelNeeded = kilometers * this.FuelConsumption;

            if (this.Fuel >= fuelNeeded)
            {
                this.Fuel -= fuelNeeded;
            }
        }
    }
}
