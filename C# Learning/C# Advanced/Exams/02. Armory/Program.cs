using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Armory
{
    internal class Program
    {
        private static int startRow;
        private static int startCol;
        private static int count;
        private static int profit;
        private static char[,] matrix;
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                    if (matrix[row, col] == 'A')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (char.IsDigit(matrix[row, col]))
                    {
                        count++;
                    }
                }
            }
            string command = Console.ReadLine();
            while (IsValid(startRow,startCol) && profit <= 65)
            {
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
                if (IsValid(startRow,startCol) && profit <= 65)
                {
                    command = Console.ReadLine();
                }
                
            }
            if (!IsValid(startRow,startCol))
            {
                Console.WriteLine("I do not need more swords!");
            }
            if (profit >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {profit} gold coins.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            matrix[startRow, startCol] = '-';
            startRow += row;
            startCol += col;

            if (IsValid(startRow, startCol))
            {
                if (char.IsDigit(matrix[startRow, startCol]))
                {
                    char digit = matrix[startRow, startCol];
                    int price = int.Parse(digit.ToString());
                    profit += price;
                    matrix[startRow, startCol] = 'A';
                }
                else if (matrix[startRow, startCol] == 'M')
                {
                    matrix[startRow, startCol] = 'A';
                    for (int ro = 0; ro < matrix.GetLength(0); ro++)
                    {
                        for (int co = 0; co < matrix.GetLength(1); co++)
                        {
                            if (matrix[ro, co] == 'M')
                            {
                                matrix[startRow, startCol] = '-';
                                startRow = ro;
                                startCol = co;
                                matrix[ro, co] = 'A';
                            }

                        }
                    }
                }
            }
            else
                return;
        }

        private static bool IsValid(int startRow, int startCol)
        {
            return (startRow >= 0 && startRow < matrix.GetLength(0) &&
                    startCol >= 0 && startCol < matrix.GetLength(1));
        }
    }
}
