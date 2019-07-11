using System;

using _04Telephony.Exceptions;
using _04Telephony.Interfaces;
using _04Telephony.Models;

namespace _04Telephony.Core
{
    public class Engine
    {
        private ICallable callablePhone;
        private IBrowseable browseablePhone;

        public Engine()
        {
            this.callablePhone = new Smartphone();
            this.browseablePhone = new Smartphone();
        }

        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ");

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(callablePhone.Call(number));
                }
                catch (InvalidNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                }
            }

            string[] webSites = Console.ReadLine().Split(" ");

            foreach (var site in webSites)
            {
                try
                {
                    Console.WriteLine(browseablePhone.Browse(site));
                }
                catch (InvalidBrowserException ibe)
                {
                    Console.WriteLine(ibe.Message);
                }
            }
        }
    }
}
