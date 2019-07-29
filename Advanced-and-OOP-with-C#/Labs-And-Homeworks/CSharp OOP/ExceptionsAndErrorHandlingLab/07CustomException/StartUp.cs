using _07CustomException.Exceptions;
using System;

namespace _07CustomException
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "gin4o@abv.bg");

                Console.WriteLine("Successfully created object.");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
        }
    }
}
