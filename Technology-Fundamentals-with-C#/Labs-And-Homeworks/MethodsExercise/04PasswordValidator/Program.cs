using System;

namespace _04PasswordValidator
{
    class Program
    {
        static bool isValidPassword = true;

        public static void Main(string[] args)
        {
            string password = Console.ReadLine();

            CharactersLength(password);
            LettersAndDigits(password);
            TwoDigits(password);

            if (isValidPassword)
            {
                Console.WriteLine("Password is valid");
            }
        }

        public static void CharactersLength(string password)
        {
            int legthOfPassword = password.Length;

            if (legthOfPassword < 6 || legthOfPassword > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValidPassword = false;
            }
        }

        public static void LettersAndDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                bool isLetterOrDigit = char.IsLetterOrDigit(password[i]); // returns true if there is any letter or digit

                if (!isLetterOrDigit) // if the password has no letters or digits
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    isValidPassword = false;
                    return;
                }
            }
        }

        public static void TwoDigits(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }

            if (counter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValidPassword = false;
            }
        }
    }
}
