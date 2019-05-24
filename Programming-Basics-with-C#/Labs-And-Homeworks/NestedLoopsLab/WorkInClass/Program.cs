using System;
using System.IO;

namespace WorkInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialFolderPath = Console.ReadLine();
            var rootLevelFolders = Directory.GetDirectories(initialFolderPath);

            for (int currDirIndex = 0; currDirIndex < rootLevelFolders.Length; currDirIndex++)
            {
                Console.WriteLine($"---- {rootLevelFolders[currDirIndex]} ----");

                var subFolders = Directory.GetDirectories(rootLevelFolders[currDirIndex]);
                for (int currSubDirIndex = 0; currDirIndex < subFolders.Length; currSubDirIndex++)
                {
                    var fileNames = Directory.GetFiles(subFolders[currSubDirIndex]);
                    for (int fileNameIndex = 0; fileNameIndex < fileNames.Length; fileNameIndex++)
                    {
                        Console.WriteLine(fileNames[fileNameIndex]);
                    }
                }
            }
        }
    }
}
