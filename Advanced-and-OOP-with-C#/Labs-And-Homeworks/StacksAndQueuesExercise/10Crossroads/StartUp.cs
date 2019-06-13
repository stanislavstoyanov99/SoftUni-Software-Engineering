namespace _10Crossroads
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> queueOfCars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input = string.Empty;

            bool isHitted = false;
            string hittedCarName = string.Empty;
            char hittedSymbol = '\0';
            int totalCarsCounter = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    queueOfCars.Enqueue(input);
                    continue;
                }

                int currentGreenLightDuration = greenLightDuration;
                while (currentGreenLightDuration > 0 && queueOfCars.Count > 0)
                {
                    string carName = queueOfCars.Dequeue();
                    int carLenght = carName.Length;

                    if (currentGreenLightDuration - carLenght >= 0)
                    {
                        currentGreenLightDuration -= carLenght;
                        totalCarsCounter++;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;

                        if (currentGreenLightDuration - carLenght >= 0)
                        {
                            totalCarsCounter++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCarName = carName;
                            hittedSymbol = carName[currentGreenLightDuration];
                            break;
                        }
                    }
                }
            }

            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsCounter} total cars passed the crossroads.");
            }
        }
    }
}
