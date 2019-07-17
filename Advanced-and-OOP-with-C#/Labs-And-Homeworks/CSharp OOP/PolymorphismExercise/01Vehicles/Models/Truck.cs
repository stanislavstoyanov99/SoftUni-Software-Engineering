using System;

namespace _01Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONER = 1.6;
        private readonly double initialFuelQuantity = 0.95;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm += AIR_CONDITIONER;
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters * initialFuelQuantity;
            }
        }
    }
}
