using System.IO;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"files\text.txt");

            using (reader)
            {
                int counterOfLines = 1;
                int counterOfLetters = 0;
                int counterOfMarks = 0;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter(@"files\output.txt"))
                {
                    while (line != null)
                    {
                        foreach (char letter in line)
                        {
                            if (char.IsLetter(letter))
                            {
                                counterOfLetters++;
                            }
                        }

                        foreach (char symbol in line)
                        {
                            if (char.IsPunctuation(symbol))
                            {
                                counterOfMarks++;
                            }
                        }
                        writer.WriteLine($"Line {counterOfLines}:{line} ({counterOfLetters})({counterOfMarks})");

                        counterOfLines++;
                        counterOfLetters = 0;
                        counterOfMarks = 0;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
