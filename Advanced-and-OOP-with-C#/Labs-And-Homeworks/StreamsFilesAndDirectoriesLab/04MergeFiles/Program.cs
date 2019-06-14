using System.IO;

namespace _04MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter(@"files\output.txt"))
            {
                using (var firstReader = new StreamReader(@"files\firstInput.txt"))
                {
                    using (var secondReader = new StreamReader(@"files\secondInput.txt"))
                    {
                        string lineFirstInput = firstReader.ReadLine();
                        string lineSecondInput = secondReader.ReadLine();

                        while (lineFirstInput != null || lineSecondInput != null)
                        {
                            writer.WriteLine(lineFirstInput);
                            writer.WriteLine(lineSecondInput);

                            lineFirstInput = firstReader.ReadLine();
                            lineSecondInput = secondReader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
