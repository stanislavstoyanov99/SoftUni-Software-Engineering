using System;

class Program
{
    static void Main(string[] args)
    {
        string teamName = Console.ReadLine();
        string typeOfSouvenir = Console.ReadLine();
        int boughtSouvenirs = int.Parse(Console.ReadLine());

        double sum = default(double);
        string result = string.Empty;
        bool isInvalid = true;

        if (teamName == "Brazil")
        {
            if (typeOfSouvenir == "stickers")
            {
                sum += 1.20;
            }
            else if (typeOfSouvenir == "posters")
            {
                sum += 5.35;
            }
            else if (typeOfSouvenir == "caps")
            {
                sum += 8.50;
            }
            else if (typeOfSouvenir == "flags")
            {
                sum += 4.20;
            }
            else
            {
                result = $"Invalid stock!";
                isInvalid = false;
            }
        }
        else if (teamName == "Argentina")
        {
            if (typeOfSouvenir == "stickers")
            {
                sum += 1.25;
            }
            else if (typeOfSouvenir == "posters")
            {
                sum += 5.10;
            }
            else if (typeOfSouvenir == "caps")
            {
                sum += 7.20;
            }
            else if (typeOfSouvenir == "flags")
            {
                sum += 3.25;
            }
            else
            {
                result = $"Invalid stock!";
                isInvalid = false;
            }
        }
        else if (teamName == "Croatia")
        {
            if (typeOfSouvenir == "stickers")
            {
                sum += 1.10;
            }
            else if (typeOfSouvenir == "posters")
            {
                sum += 4.95;
            }
            else if (typeOfSouvenir == "caps")
            {
                sum += 6.90;
            }
            else if (typeOfSouvenir == "flags")
            {
                sum += 2.75;
            }
            else
            {
                result = $"Invalid stock!";
                isInvalid = false;
            }
        }
        else if (teamName == "Denmark")
        {
            if (typeOfSouvenir == "stickers")
            {
                sum += 0.9;
            }
            else if (typeOfSouvenir == "posters")
            {
                sum += 4.80;
            }
            else if (typeOfSouvenir == "caps")
            {
                sum += 6.50;
            }
            else if (typeOfSouvenir == "flags")
            {
                sum += 3.10;
            }
            else
            {
                result = $"Invalid stock!";
                isInvalid = false;
            }
        }
        else
        {
            result = $"Invalid country!";
            isInvalid = false;
        }
        double totalSum = sum * boughtSouvenirs;
        if (isInvalid)
        {
            Console.WriteLine($"Pepi bought {boughtSouvenirs} {typeOfSouvenir} of {teamName} for {totalSum:F2} lv.");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
}
