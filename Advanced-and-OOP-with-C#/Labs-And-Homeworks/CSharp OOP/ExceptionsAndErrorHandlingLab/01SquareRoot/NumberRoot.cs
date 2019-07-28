using System;

namespace _01SquareRoot
{
    public class NumberRoot
    {
        private int number;

        public NumberRoot(int number)
        {
            this.Number = number;
        }

        public int Number
        {
            get => this.number;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid number");
                }

                this.number = value;
            }
        }

        public void CalculateRoot(int number)
        {
            double numberRoot = Math.Sqrt(number);

            Console.WriteLine($"Number root: {numberRoot:F3}");
        }
    }
}
