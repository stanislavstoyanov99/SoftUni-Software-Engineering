using System;

namespace _01DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            DataType(dataType);
        }

        private static void DataType(string dataType)
        {
            switch (dataType)
            {
                case "int":
                    int intNumber = int.Parse(Console.ReadLine());
                    int resultAsInteger = intNumber * 2;
                    Console.WriteLine(resultAsInteger);
                    break;
                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    double resultAsRealNumber = realNumber * 1.5;
                    Console.WriteLine($"{resultAsRealNumber:F2}");
                    break;
                case "string":
                    string text = Console.ReadLine();
                    Console.WriteLine($"${text}$");
                    break;
            }
        }
    }
}
