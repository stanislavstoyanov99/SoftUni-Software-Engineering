using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<peakName>[A-Za-z\d@!#\$\?]+)\=(?<length>\d+)\<\<(?<geohashCode>\w+)$";
            var validInformation = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Last note")
            {
                if (validInformation.IsMatch(input))
                {
                    int geohashCodeLenght = int.Parse(validInformation.Match(input).Groups["length"].Value);

                    var nameOfMountain = new StringBuilder();

                    string currentNameOfMountain = validInformation.Match(input).Groups["peakName"].Value;
                    for (int i = 0; i < currentNameOfMountain.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(currentNameOfMountain[i]))
                        {
                            nameOfMountain.Replace(currentNameOfMountain[i], '\0');
                        }
                        else
                        {
                            nameOfMountain.Append(currentNameOfMountain[i]);
                        }
                    }

                    string geohashCode = validInformation.Match(input).Groups["geohashCode"].Value;

                    if (geohashCodeLenght == geohashCode.Length)
                    {
                        Console.WriteLine($"Coordinates found! {nameOfMountain} -> {geohashCode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }

                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
