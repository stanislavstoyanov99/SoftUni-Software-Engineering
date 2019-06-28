using System.IO;

namespace _04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = @"files\copyMe.png";
            string outputFile = @"files\outputImage.png";

            using (var streamReadFile = new FileStream(sourceFile, FileMode.Open))
            {
                var binaryReader = new BinaryReader(streamReadFile);

                using (var streamCreateFile = new FileStream(outputFile, FileMode.Create))
                {
                    var binaryWriter = new BinaryWriter(streamCreateFile);

                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        int size = binaryReader.Read(buffer, 0, buffer.Length);

                        if (size <= 0)
                        {
                            break;
                        }

                        binaryWriter.Write(buffer, 0, size);

                        if (size < 4096)
                        {
                            break; // end of file reached
                        }
                    }
                }
            }
        }
    }
}
