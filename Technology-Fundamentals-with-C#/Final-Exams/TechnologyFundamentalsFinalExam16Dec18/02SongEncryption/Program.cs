using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string validation = @"^([A-Z][a-z\s']+):([A-Z\s]+)$";
            var validInput = new Regex(validation);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                if (validInput.IsMatch(input))
                {
                    int encryptionKey = validInput.Match(input).Groups[1].Length;

                    var encryptedMessage = new StringBuilder();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (char.IsUpper(input[i]))
                        {
                            if (input[i] + encryptionKey > 90)
                            {
                                encryptedMessage.Append((char)(64 + (encryptionKey - (90 - input[i]))));
                            }
                            else
                            {
                                encryptedMessage.Append((char)(input[i] + encryptionKey));
                            }
                        }
                        else if (char.IsLower(input[i]))
                        {
                            if ((input[i] + encryptionKey) > 122)
                            {
                                encryptedMessage.Append((char)(96 + (encryptionKey - (122 - input[i]))));
                            }
                            else
                            {
                                encryptedMessage.Append((char)(input[i] + encryptionKey));
                            }
                        }
                        else if (input[i] == ':')
                        {
                            encryptedMessage.Append('@');
                        }

                        else
                        {
                            encryptedMessage.Append(input[i]);
                        }
                    }

                    Console.WriteLine($"Successful encryption: {encryptedMessage.ToString()}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
