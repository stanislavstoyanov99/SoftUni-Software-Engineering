using System;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsNumber = int.Parse(Console.ReadLine());

            int sumOfPeople = 0;
            int[] peopleAsArray = new int [wagonsNumber];

            for (int i = 0; i < peopleAsArray.Length; i++)
            {
                int people = int.Parse(Console.ReadLine());
                peopleAsArray[i] = people;
                sumOfPeople += people;
            }

            Console.WriteLine(string.Join(" ", peopleAsArray));
            Console.WriteLine(sumOfPeople);
        }
    }
}
