using System;

using _04Telephony.Interfaces;

namespace _04Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ");

            foreach (var number in phoneNumbers)
            {
                try
                {
                    ICallable smartphone = new Smartphone() { MobileNumber = number };
                    
                    Console.WriteLine(smartphone.Call());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            string[] webSites = Console.ReadLine().Split(" ");

            foreach (var site in webSites)
            {
                try
                {
                    IBrowseable smartphone = new Smartphone { SiteName = site };

                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
