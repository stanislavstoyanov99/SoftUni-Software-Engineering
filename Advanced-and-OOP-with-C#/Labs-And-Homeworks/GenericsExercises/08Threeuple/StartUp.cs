using System;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(" ");

            string names = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            string town = string.Empty;
            if (personInfo.Length == 5)
            {
                town = personInfo[3] + " " + personInfo[4];
            }
            else
            {
                town = personInfo[3];
            }

            var firstCustomTuple = new CustomThreeuple<string, string, string>(names, address, town);

            string[] personBeerInfo = Console.ReadLine().Split(" ");

            string personName = personBeerInfo[0];
            int litersOfBeer = int.Parse(personBeerInfo[1]);
            string drunkInfo = personBeerInfo[2];
            bool drunkOrNot = false;

            if (drunkInfo == "drunk")
            {
                drunkOrNot = true;
            }
            else
            {
                drunkOrNot = false;
            }

            var secondCustomTuple = new CustomThreeuple<string, int, bool>(personName, litersOfBeer, drunkOrNot);

            string[] bankInfo = Console.ReadLine().Split(" ");

            string name = bankInfo[0];
            double accountBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            var thirdCustomTuple = new CustomThreeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(firstCustomTuple);
            Console.WriteLine(secondCustomTuple);
            Console.WriteLine(thirdCustomTuple);
        }
    }
}
