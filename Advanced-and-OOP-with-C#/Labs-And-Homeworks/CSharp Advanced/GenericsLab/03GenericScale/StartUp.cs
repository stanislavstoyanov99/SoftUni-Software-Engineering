using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstString = "Pesho";
            string secondString = "Gosho";

            EqualityScale<string> checkEquality = new EqualityScale<string>(firstString, secondString);
            Console.WriteLine(checkEquality.AreEqual());
        }
    }
}
