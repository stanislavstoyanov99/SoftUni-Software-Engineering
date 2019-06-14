using System;
using System.IO;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"files\input.txt");

            using (reader)
            {
                int counter = 1;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter(@"files\output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
