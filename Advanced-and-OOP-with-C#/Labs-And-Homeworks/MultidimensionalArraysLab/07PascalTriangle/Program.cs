using System;

namespace _07PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];
            int cols = 1;

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = new long[cols];
                jaggedArray[row][0] = 1;
                jaggedArray[row][cols - 1] = 1;

                if (cols > 2)
                {
                    long[] previousRow = jaggedArray[row - 1];

                    for (int col = 1; col < cols - 1; col++)
                    {
                        jaggedArray[row][col] = previousRow[col] + previousRow[col - 1];
                    }
                }

                cols++;
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
