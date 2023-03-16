using System;
class PascalTriangle
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        long[][] triangle = new long[height][];
        int currentWhidth = 1;
        for (long row = 0; row < height; row++)
        {
            triangle[row] = new long[currentWhidth];
            long[] currentRow = triangle[row];
            currentRow[0] = 1;
            currentRow[currentRow.Length - 1] = 1;
            currentWhidth++;
            if (currentRow.Length > 2)
            {
                for (long i = 1; i < currentRow.Length-1; i++)
                {
                    long[] priveusRow = triangle[row - 1];
                    long privRowSum = priveusRow[i] + priveusRow[i - 1];
                    currentRow[i] = privRowSum;
                }
            }
        }
        foreach (var row in triangle)
        {
            Console.WriteLine(string.Join(" ",row));
        }
    }
}

