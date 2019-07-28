using System;

namespace _01SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                NumberRoot numberRoot = new NumberRoot(number);

                numberRoot.CalculateRoot(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
