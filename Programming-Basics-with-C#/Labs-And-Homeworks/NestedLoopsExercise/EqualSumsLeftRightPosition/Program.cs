using System;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        for (int i = firstNumber; i <= secondNumber; i++)
        {
            string numInString = i.ToString();
            int leftSum = (numInString[0] - '0') + (numInString[1] - '0');
            int rightSum = (numInString[3] - '0') + (numInString[4] - '0');
            int midDigit = numInString[2] - '0';
            if (leftSum == rightSum || (Math.Abs(leftSum - rightSum) == midDigit))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }
}
