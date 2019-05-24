using System;

class Program
{
    static void Main(string[] args)
    {
        double number = double.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        string output = Console.ReadLine();

        double inputInMit = 0;
        if (input == "mm")
        {
            inputInMit = number / 1000;
        }
        else if (input == "cm")
        {
            inputInMit = number / 100;
        }
        else if (input == "mi")
        {
            inputInMit = number / 0.000621371192;
        }
        else if (input == "in")
        {
            inputInMit = number / 39.3700787;
        }
        else if (input == "km")
        {
            inputInMit = number / 0.001;
        }
        else if (input == "ft")
        {
            inputInMit = number / 3.2808399;
        }
        else if (input == "yd")
        {
            inputInMit = number / 1.0936133;
        }
        else if (input == "m")
        {
            inputInMit = number;
        }

        double result = 0.0;

        if (output == "m")
        {
            result = inputInMit;
        }
        else if (output == "mm")
        {
            result = inputInMit * 1000;
        }
        else if (output == "cm")
        {
            result = inputInMit * 100;
        }
        else if (output == "mi")
        {
            result = inputInMit * 0.000621371192;
        }
        else if (output == "in")
        {
            result = inputInMit * 39.3700787;
        }
        else if (output == "km")
        {
            result = inputInMit * 0.001;
        }
        else if (output == "ft")
        {
            result = inputInMit * 3.2808399;
        }
        else if (output == "yd")
        {
            result = inputInMit * 1.0936133;
        }
        Console.WriteLine($"{result:F8}");
    }
}
