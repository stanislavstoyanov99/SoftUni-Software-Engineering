using System;
using System.IO;
using System.Linq;

namespace _01EvenLines
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

                string[] symbolsToReplace = new string[] { "-", ",", ".", "!", "?" };

                using (var writer = new StreamWriter(@"files\output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            foreach (var symbol in symbolsToReplace)
                            {
                                if (line.Contains(symbol))
                                {
                                    line = line.Replace(symbol, "@");
                                }
                            }

                            line = string.Join(" ", line.Split(" ").Reverse());
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }

            /* Another way for reversing words
            string sentence = "My name is Archit Patel";
            StringBuilder sb = new StringBuilder();
            string[] split = sentence.Split(' ');

            for (int i = split.Length - 1; i > -1; i--)
            {
                sb.Append(split[i]);
                sb.Append(" ");
            }

            Console.WriteLine(sb);
            */
        }
    }
}
