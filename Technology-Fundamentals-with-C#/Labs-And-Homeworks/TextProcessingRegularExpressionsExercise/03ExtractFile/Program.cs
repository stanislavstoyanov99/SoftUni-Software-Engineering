using System;

namespace _03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split(@"\");
            string file = path[path.Length - 1];
            string[] fileAndExtension = file.Split(".");
            string filename = fileAndExtension[0];
            string extension = fileAndExtension[1];

            Console.WriteLine($"File name: {filename}");
            Console.WriteLine($"File extension: {extension}");

            /*Another way
            string directory = Console.ReadLine();
            int startIndexOfFile = directory.LastIndexOf('\\') + 1;
            string file = directory.Substring(startIndexOfFile);

            int startIndexOfExtension = file.LastIndexOf('.') + 1;
            string nameOfFile = file.Substring(0, startIndexOfExtension - 1);
            string extensionOfFile = file.Substring(startIndexOfExtension);

            Console.WriteLine($"File name: {nameOfFile}");
            Console.WriteLine($"File extension: {extensionOfFile}");
            */
        }
    }
}
