using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double pricePerSabre = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double beltsPriceFree = default(double);
            double extraAmount = Math.Ceiling(students + (students * 0.1));

            if (students >= 6)
            {
                beltsPriceFree = pricePerBelt * (Math.Ceiling(students - (students / 6.00)));
            }
            else
            {
                beltsPriceFree = students * pricePerBelt;
            }

            double totalPrice = pricePerSabre * extraAmount + pricePerRobe * students + beltsPriceFree;

            if (totalPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                double neededmoney = totalPrice - money;
                Console.WriteLine($"Ivan Cho will need {neededmoney:F2}lv more.");
            }
        }
    }
}
