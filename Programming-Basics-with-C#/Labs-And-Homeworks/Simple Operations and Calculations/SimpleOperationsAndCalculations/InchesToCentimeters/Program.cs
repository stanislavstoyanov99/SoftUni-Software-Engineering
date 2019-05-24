using System;

namespace InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            var inches = double.Parse(Console.ReadLine());
            var centimetres = inches * 2.54;
            Console.WriteLine(centimetres);
        }
    }
}
