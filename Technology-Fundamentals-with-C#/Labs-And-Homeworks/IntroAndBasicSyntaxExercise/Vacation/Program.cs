using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine().ToLower();
            string typeOfDay = Console.ReadLine().ToLower();

            double pricePerPerson = default(double);
            double totalPrice = default(double);

            if (typeOfGroup == "students")
            {
                if (typeOfDay == "friday")
                {
                    pricePerPerson = 8.45;
                }
                else if (typeOfDay == "saturday")
                {
                    pricePerPerson = 9.80;
                }
                else if (typeOfDay == "sunday")
                {
                    pricePerPerson = 10.46;
                }

                if (people >= 30)
                {
                    totalPrice = people * pricePerPerson * 0.85;
                }
                else
                {
                    totalPrice = people * pricePerPerson;
                }
            }
            else if (typeOfGroup == "business")
            {
                if (typeOfDay == "friday")
                {
                    pricePerPerson = 10.90;
                }
                else if (typeOfDay == "saturday")
                {
                    pricePerPerson = 15.60;
                }
                else if (typeOfDay == "sunday")
                {
                    pricePerPerson = 16;
                }

                if (people >= 100)
                {
                    totalPrice = (people * pricePerPerson) - (10 * pricePerPerson);
                }
                else
                {
                    totalPrice = people * pricePerPerson;
                }
            }
            else if (typeOfGroup == "regular")
            {
                if (typeOfDay == "friday")
                {
                    pricePerPerson = 15;
                }
                else if (typeOfDay == "saturday")
                {
                    pricePerPerson = 20;
                }
                else if (typeOfDay == "sunday")
                {
                    pricePerPerson = 22.50;
                }

                if (people >= 10 && people <= 20)
                {
                    totalPrice = people * pricePerPerson * 0.95;
                }
                else
                {
                    totalPrice = people * pricePerPerson;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
