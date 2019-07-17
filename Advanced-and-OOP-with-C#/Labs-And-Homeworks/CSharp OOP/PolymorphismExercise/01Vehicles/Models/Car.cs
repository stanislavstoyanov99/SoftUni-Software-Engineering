namespace _01Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITIONER = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm += AIR_CONDITIONER;
        }
    }
}
