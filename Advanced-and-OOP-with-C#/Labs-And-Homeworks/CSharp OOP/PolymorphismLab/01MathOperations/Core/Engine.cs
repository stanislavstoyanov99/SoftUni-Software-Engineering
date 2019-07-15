using System;

using Operations.Models;

namespace Operations.Core
{
    public class Engine
    {
        private readonly MathOperations mathOperations;

        public Engine()
        {
            this.mathOperations = new MathOperations();
        }

        public void Run()
        {
            Console.WriteLine(mathOperations.Add(2, 3));
            Console.WriteLine(mathOperations.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mathOperations.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
