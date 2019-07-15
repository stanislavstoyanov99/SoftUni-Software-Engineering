using System;

using Cars.Interfaces;
using Cars.Models;

namespace Cars.Core
{
    public class Engine
    {
        public void Run()
        {
            ICar seat = new Seat("Leon", "Grey");
            IElectricCar tesla = new Tesla("Model 3", "Red", 2);

            PrintCars(seat, tesla);
        }

        private void PrintCars(ICar seat, IElectricCar tesla)
        {
            Console.WriteLine(seat);
            Console.WriteLine(tesla);
        }
    }
}
