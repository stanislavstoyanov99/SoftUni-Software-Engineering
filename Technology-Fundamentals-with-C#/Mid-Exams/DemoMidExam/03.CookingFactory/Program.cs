using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] bestBatch = new int[] { int.MinValue }; 
        int bestQuality = int.MinValue;                 
        string input = string.Empty; 

        while ((input = Console.ReadLine()) != "Bake It!")
        {
            int[] currentBatch = input.Split('#').Select(int.Parse).ToArray(); //настоящата партида
            int currentQuality = currentBatch.Sum();                           //настоящото качество
            bool foundBetterBatch = false;       //булева променлива за това дали сме намерили по-добра партида

            if (bestQuality < currentQuality)    //проверка по първи критерий (ако сумата на най-добрата партида е по малка от сумата на настоящата)
            {
                foundBetterBatch = true;
            }
            else if (bestQuality == currentQuality)                        //при равно качество
            {
                if (bestBatch.Average() < currentBatch.Average())          //втори критерий сравняваме средноаритметичните суми
                {
                    foundBetterBatch = true;
                }
                else if (bestBatch.Average() == currentBatch.Average() &&  //при равни средноаритметични суми
                         bestBatch.Length > currentBatch.Length)           //сравняваме по трети критерий (дължина на партидите)
                {
                    foundBetterBatch = true;
                }
            }

            if (foundBetterBatch)                          //ако е намерена по-добра партида
            {
                bestBatch = (int[])currentBatch.Clone();   //най-добрата ни партида става настоящата
                bestQuality = bestBatch.Sum();             //ъпдейтваме bestQuality
            }
        }

        Console.WriteLine($"Best Batch quality: {bestQuality}\n{string.Join(" ", bestBatch)}");
    }
}

