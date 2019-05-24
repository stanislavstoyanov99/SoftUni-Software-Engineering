using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysForCampaign = int.Parse(Console.ReadLine());
            int numberOfConfectioners = int.Parse(Console.ReadLine());
            int numberOfCakes = int.Parse(Console.ReadLine());
            int numberOfWaffles = int.Parse(Console.ReadLine());
            int numberOfPancakes = int.Parse(Console.ReadLine());

            var sumOfCakes = numberOfCakes * 45;
            var sumOfWaffles = numberOfWaffles * 5.80;
            var sumOfPancakes = numberOfPancakes * 3.20;
            var totalSumForOneDay = (sumOfCakes + sumOfWaffles + sumOfPancakes) * numberOfConfectioners;
            var totalSumOfCompany = totalSumForOneDay * daysForCampaign;
            var sumAfterTaxes = 0.125 * totalSumOfCompany;
            var totalSum = totalSumOfCompany - sumAfterTaxes;
            Console.WriteLine("{0:F2}", totalSum);
        }
    }
}
