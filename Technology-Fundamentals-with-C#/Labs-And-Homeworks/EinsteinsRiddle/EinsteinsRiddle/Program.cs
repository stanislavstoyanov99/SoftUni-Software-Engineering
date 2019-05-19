using System;

namespace EinsteinsRiddle
{
    class EinsteinsRiddle
    {
        static string[] houses = { "Red", "Green", "Yellow", "White", "Blue" };
        static string[] pets = { "Dog", "Cat", "Bird", "Horse", "Fish" };
        static string[] nationalities = { "Brit", "Swede", "Dane", "Norwegian", "German" };
        static string[] cigarattes = { "Blend", "Prince", "Dunhill", "BlueMaster", "PallMall" };
        static string[] drinks = { "Tea", "Coffee", "Milk", "Beer", "Water" };
        static string[] hints = new string[15];

        static void Main(string[] args)
        {
            Random rand = new Random();
            Shuffle(rand);
            GenerateHints();

            Console.WriteLine("Einstein's riddle");
            Console.WriteLine("The situation:");
            Console.WriteLine("     1.There are 5 houses in five different colors.");
            Console.WriteLine("     2.In each house lives a person with a different nationality.");
            Console.WriteLine("     3.These five owners drink a certain type of beverage, smoke a certain brand of cigar and keep a certain pet.");
            Console.WriteLine("     4.No owners have the same pet, smoke the same brand of cigar or drink the same beverage.");
            Console.WriteLine($"The question is: Who owns the {pets[4]}?");
            Console.WriteLine("Hints:");

            for (int i = 1; i <= hints.Length; i++)
            {
                Console.WriteLine($"{i}. {hints[i - 1]}");
            }

            Console.WriteLine("Einstein wrote this riddle this century. He said that 98% of the world could not solve it.");
            Console.WriteLine();
            Console.WriteLine("To see the solution type solution");

            string solution = Console.ReadLine();
            while (solution.ToLower() != "solution")
            {
                Console.WriteLine("Wrong command! Try again!");
                solution = Console.ReadLine();
            }

            PrintSolution();
        }

        private static void PrintSolution()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"In the {houses[i]} lives the {nationalities[i]}." +
                    $" He drinks {drinks[i]}, smokes {cigarattes[i]} and has {pets[i]} as a pet.");
            }
        }

        private static void GenerateHints()
        {
            hints[0] = $"the {nationalities[0]} lives in the {houses[0]} house";
            hints[1] = $"the {nationalities[1]} keeps {pets[0]} as pets";
            hints[2] = $"the {nationalities[2]} drinks tea";
            hints[3] = $"the {houses[1]} house is on the left of the {houses[3]} house";
            hints[4] = $"the {houses[1]} house's owner drinks {drinks[1]}";
            hints[5] = $"the person who smokes {cigarattes[4]} rears {pets[2]}";
            hints[6] = $"the owner of the {houses[2]} house smokes {cigarattes[2]}";
            hints[7] = $"the man living in the center house drinks {drinks[2]}";
            hints[8] = $"the {nationalities[3]} lives in the first house";
            hints[9] = $"the man who smokes {cigarattes[0]} lives next to the one who keeps {pets[1]}";
            hints[10] = $"the man who keeps {pets[3]} lives next to the man who smokes {cigarattes[2]}";
            hints[11] = $"the owner who smokes {cigarattes[3]} drinks {drinks[3]}";
            hints[12] = $"the {nationalities[4]} smokes {cigarattes[1]}";
            hints[13] = $"the {nationalities[3]} lives next to the {houses[4]} house";
            hints[14] = $"the man who smokes {cigarattes[0]} has a neighbor who drinks {drinks[4]}";
        }

        private static void Shuffle(Random rand)
        {
            for (int i = 0; i < 5; i++)
            {
                // Shuffling houses
                int randomHouse = i + rand.Next(0, houses.Length - i);
                Swap(i, randomHouse, houses);

                // Shuffling pets
                int randomPet = i + rand.Next(0, pets.Length - i);
                Swap(i, randomPet, pets);

                // Shuffling nationalities
                int randomNationality = i + rand.Next(0, nationalities.Length - i);
                Swap(i, randomNationality, nationalities);

                // Shuffling cigarattes
                int randomCigaratte = i + rand.Next(0, cigarattes.Length - i);
                Swap(i, randomCigaratte, cigarattes);

                // Shuffling drinks
                int randomDrink = i + rand.Next(0, drinks.Length - i);
                Swap(i, randomDrink, drinks);
            }
        }

        private static void Swap(int i, int random, string[] array)
        {
            string temp = array[i];
            array[i] = array[random];
            array[random] = temp;
        }
    }
}
