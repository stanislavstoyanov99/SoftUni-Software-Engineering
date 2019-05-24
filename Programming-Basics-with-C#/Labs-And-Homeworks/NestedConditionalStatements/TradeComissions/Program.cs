using System;

class Program
{
    static void Main(string[] args)
    {
        string town = Console.ReadLine().ToLower();
        double sales = double.Parse(Console.ReadLine());

        double commission = default(double);
        string result = string.Empty;

        if (town == "sofia")
        {
            if (0 <= sales && sales <= 500)
            {
                commission = 0.05;
            }
            else if (500 < sales && sales <= 1000)
            {
                commission = 0.07;
            }
            else if (1000 < sales && sales <= 10_000)
            {
                commission = 0.08;
            }
            else if (sales > 10_000)
            {
                commission = 0.12;
            }
            else
            {
                result = "error";
            }
        }
        else if (town == "varna")
        {
            if (0 <= sales && sales <= 500)
            {
                commission = 0.045;
            }
            else if (500 < sales && sales <= 1000)
            {
                commission = 0.075;
            }
            else if (1000 < sales && sales <= 10_000)
            {
                commission = 0.10;
            }
            else if (sales > 10_000)
            {
                commission = 0.13;
            }
            else
            {
                result = "error";
            }
        }
        else if (town == "plovdiv")
        {
            if (0 <= sales && sales <= 500)
            {
                commission = 0.055;
            }
            else if (500 < sales && sales <= 1000)
            {
                commission = 0.08;
            }
            else if (1000 < sales && sales <= 10_000)
            {
                commission = 0.12;
            }
            else if (sales > 10_000)
            {
                commission = 0.145;
            }
            else
            {
                result = "error";
            }
        }
        else
        {
            Console.WriteLine("error");
            return;
        }
        Console.WriteLine(result);
        Console.WriteLine($"{(commission * sales):F2}");
    }
}
