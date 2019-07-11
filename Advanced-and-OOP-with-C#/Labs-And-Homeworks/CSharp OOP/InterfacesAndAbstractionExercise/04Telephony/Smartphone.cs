using System;
using System.Linq;

using _04Telephony.Exceptions;
using _04Telephony.Interfaces;

namespace _04Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        private string mobileNumber;
        private string siteName;

        public string MobileNumber
        {
            get
            {
                return this.mobileNumber;
            }
            set
            {
                if (CheckMobileNumber(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberException);
                }

                this.mobileNumber = value;
            }
        }

        public string SiteName
        {
            get
            {
                return this.siteName;
            }
            set
            {
                if (CheckSiteName(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrowserException);
                }

                this.siteName = value;
            }
        }

        private bool CheckMobileNumber(string value)
        {
            return value.FirstOrDefault(c => !char.IsDigit(c)) != 0;
        }

        private bool CheckSiteName(string value)
        {
            return value.FirstOrDefault(c => char.IsDigit(c)) != 0;
        }

        public string Browse()
        {
            return $"Browsing: {this.SiteName}!";
        }

        public string Call()
        {
            return $"Calling... {this.MobileNumber}";
        }
    }
}
