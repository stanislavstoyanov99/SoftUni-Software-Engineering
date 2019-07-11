using System.Linq;

using _04Telephony.Exceptions;
using _04Telephony.Interfaces;

namespace _04Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone()
        {

        }

        public string Browse(string siteName)
        {
            if (siteName.Any(c => char.IsDigit(c)))
            {
                throw new InvalidBrowserException();
            }

            return $"Browsing: {siteName}!";
        }

        public string Call(string number)
        {
            if (!number.Any(c => char.IsDigit(c)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}
