using System;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int boughtSouvenirs = int.Parse(Console.ReadLine());
            double totalSum = -1;

            if (country == "Argentina")
            {
                if (souvenirs == "flags")
                {
                    totalSum = boughtSouvenirs * 3.25;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = boughtSouvenirs * 7.20;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = boughtSouvenirs * 5.10;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = boughtSouvenirs * 1.25;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }

            else if (country == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    totalSum = boughtSouvenirs * 4.20;
                }

                else if (souvenirs == "caps")
                {
                    totalSum = boughtSouvenirs * 8.50;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = boughtSouvenirs * 5.35;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = boughtSouvenirs * 1.20;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }

            else if (country == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    totalSum = boughtSouvenirs * 2.75;
                }

                else if (souvenirs == "caps")
                {
                    totalSum = boughtSouvenirs * 6.90;
                }

                else if (souvenirs == "posters")
                {
                    totalSum = boughtSouvenirs * 4.95;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = boughtSouvenirs * 1.10;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (country == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    totalSum = boughtSouvenirs * 3.10;
                }

                else if (souvenirs == "caps")
                {
                    totalSum = boughtSouvenirs * 6.50;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = boughtSouvenirs * 4.80;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = boughtSouvenirs * 0.90;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
            }

            if (totalSum > 0)
            {
                Console.WriteLine($"Pepi bought {boughtSouvenirs} {souvenirs} of {country} for {totalSum:F2} lv.");
            }
        }
    }
}