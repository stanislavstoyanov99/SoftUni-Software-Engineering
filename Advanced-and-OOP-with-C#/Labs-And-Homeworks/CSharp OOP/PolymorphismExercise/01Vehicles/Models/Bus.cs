namespace _01Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITIONER = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm += AIR_CONDITIONER;
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumptionPerKm -= AIR_CONDITIONER;
            return base.Drive(distance);
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
