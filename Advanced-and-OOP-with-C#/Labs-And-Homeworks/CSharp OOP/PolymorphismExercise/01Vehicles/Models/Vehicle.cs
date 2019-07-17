using System;

namespace _01Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;

            CheckFuelTank();
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionPerKm { get; protected set; }

        public double TankCapacity { get; protected set; }

        public string Drive(double distance)
        {
            string result = string.Empty;

            double fuelNeeded = this.FuelConsumptionPerKm * distance;

            if (fuelNeeded <= this.FuelQuantity && this.FuelQuantity <= this.TankCapacity)
            {
                this.FuelQuantity -= fuelNeeded;
                result += $"{this.GetType().Name} travelled {distance} km";
            }
            else if (fuelNeeded > this.FuelQuantity)
            {
                result += $"{this.GetType().Name} needs refueling";
            }

            return result;
        }

        public virtual void Refuel(double liters)
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
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:F2}";
        }

        private void CheckFuelTank()
        {
            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }
    }
}
