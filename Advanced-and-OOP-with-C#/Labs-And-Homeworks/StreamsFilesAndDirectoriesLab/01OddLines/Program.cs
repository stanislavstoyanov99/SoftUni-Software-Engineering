using System;
using System.IO;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"files\input.txt");

            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter(@"files\output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
