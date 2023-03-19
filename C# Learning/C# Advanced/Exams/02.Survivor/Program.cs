using System;
using System.Linq;
namespace _02.Survivor
{
    internal class Program
    {
        public static char[][] matrix;
        public static int collectedTokens;
        public static string direction;
        public static int collectedOpponent;
        public static int row;
        public static int col;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n][];
            for (int row = 0; row < n; row++)
            {
                char[] elements = Console.ReadLine().Replace(" ", "").ToCharArray();
                matrix[row] = new char[elements.Length];
                for (int i = 0; i < elements.Length; i++)
                {
                    matrix[row][i] = elements[i];
                }
            }
            string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Gong")
            {
                string action = command[0];
                row = int.Parse(command[1]);
                col = int.Parse(command[2]);
                if (action == "Find")
                {
                    if (IsValid(row,col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                }
                if (action == "Opponent")
                {
                    direction = command[3];
                    if (IsValid(row,col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedOpponent++;
                            matrix[row][col] = '-';
                            if (direction == "up")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Move(-1, 0);
                                }
                                
                            }
                            else if (direction == "down")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Move(1, 0);
                                }
                            }
                            else if (direction == "left")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Move(0, -1);
                                }
                            }
                            else if (direction == "right")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Move(0, 1);
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {collectedOpponent}");
        }

        private static void Move(int roww, int coll)
        {
            if (IsValid(row+roww,col+coll))
            {
                row += roww;
                col += coll;
                if (matrix[row][col] == 'T')
                {
                    collectedOpponent++;
                    matrix[row][col] = '-';
                }
            }
            else
                matrix[row][col] = '-';
        }
        private static bool IsValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }
    }
}
