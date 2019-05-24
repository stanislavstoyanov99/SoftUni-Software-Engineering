using System;

namespace PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            string result = string.Empty;

            if (age >= 16)
            {
                if (gender == "m")
                {
                    result = "Mr.";
                }
                else
                {
                    result = "Ms.";
                }
            }
            else
            {
                if (gender == "m")
                {
                    result = "Master";
                }
                else
                {
                    result = "Miss";
                }
            }
            Console.WriteLine(result);
        }
    }
}
