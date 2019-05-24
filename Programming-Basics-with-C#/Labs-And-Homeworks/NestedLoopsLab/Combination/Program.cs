using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        int counter = 0;

        for (int firstDigit = 0; firstDigit <= number; firstDigit++)
        {
            for (int secondDigit = 0; secondDigit <= number; secondDigit++)
            {
                for (int thirdDigit = 0; thirdDigit <= number; thirdDigit++)
                {
                    for (int fourthDigit = 0; fourthDigit <= number; fourthDigit++)
                    {
                        for (int fifthDigit = 0; fifthDigit <= number; fifthDigit++)
                        {
                            sum = firstDigit + secondDigit + thirdDigit + fourthDigit + fifthDigit;
                            if (sum == number)
                            {
                                counter++;
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(counter);
    }
}
