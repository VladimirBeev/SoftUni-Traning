using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowMatrix = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowMatrix] [];
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[row] = new int[elements.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = elements[col];
                }
            }
            string[] commands = Console.ReadLine().ToLower().Split(' ');
            while (commands[0] !="end")
            {
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int num = int.Parse(commands[3]);
                if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (commands[0] == "add")
                {
                    matrix[row][col] += num; 
                }
                else if (commands[0] == "subtract")
                {
                    matrix[row][col] -= num;
                }
                commands = Console.ReadLine().ToLower().Split(' ');
            }
            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
