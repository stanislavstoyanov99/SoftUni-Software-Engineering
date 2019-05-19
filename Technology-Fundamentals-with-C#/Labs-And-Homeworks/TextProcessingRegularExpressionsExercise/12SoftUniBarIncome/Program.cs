using System;
using System.Text.RegularExpressions;

namespace _12SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            decimal income = default(decimal);

            while ((input = Console.ReadLine()) != "end of shift")
            {
                string patternForName = @"\%(?<name>[A-Z][a-z]+)\%";
                string patternForProduct = @"\<(?<product>\w+)\>";
                string patternForCount = @"\|(?<count>\d+)\|";
                string patternForPrice = @"(?<price>\d+(\.\d+)?)\$";

                if (!Regex.IsMatch(input, patternForName) || !Regex.IsMatch(input, patternForProduct)
                    || !Regex.IsMatch(input, patternForCount) || !Regex.IsMatch(input, patternForPrice))
                {
                    continue;
                }

                var namesRegex = Regex.Match(input, patternForName);
                string customerName = namesRegex.Groups["name"].Value;

                var productsRegex = Regex.Match(input, patternForProduct);
                string productName = productsRegex.Groups["product"].Value;

                var countRegex = Regex.Match(input, patternForCount);
                int count = int.Parse(countRegex.Groups["count"].ToString());

                var priceRegex = Regex.Match(input, patternForPrice);
                decimal price = decimal.Parse(priceRegex.Groups["price"].ToString());

                decimal priceOfProduct = count * price;
                income += priceOfProduct;

                Console.WriteLine($"{customerName}: {productName} - {priceOfProduct:F2}");
            }

            Console.WriteLine($"Total income: {income:F2}");
        }

        /*Second more simple way
        static void Main(string[] args)
        {
            string input = string.Empty;
            decimal income = default(decimal);

            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"\%(?<name>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+(\.\d+)?)\$";

                var match = Regex.Match(input, pattern);
                if (!Regex.IsMatch(input, pattern))
                {
                    continue;
                }

                string customerName = match.Groups["name"].Value;
                string productName = match.Groups["product"].Value;
                int count = int.Parse(match.Groups["count"].Value);
                decimal price = decimal.Parse(match.Groups["price"].Value);

                decimal priceOfProduct = count * price;
                income += priceOfProduct;

                Console.WriteLine($"{customerName}: {productName} - {priceOfProduct:F2}");
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
        */

        /* Third way
        static void Main()
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$";

            string input = String.Empty;
            double totalIncome = 0.0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Regex order = new Regex(pattern);

                if (order.IsMatch(input))
                {

                    string customerName = order.Match(input).Groups["customer"].Value;
                    string productName = order.Match(input).Groups["product"].Value;
                    int count = int.Parse(order.Match(input).Groups["count"].Value);
                    double price = double.Parse(order.Match(input).Groups["price"].Value);

                    double totalPrice = price * count;

                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {productName} - {totalPrice:F2}");

                }

            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
        */
    }
}
