using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        private static int armory;
        private static int rowSpawn;
        private static int rowArmy;
        private static int colArmy;
        private static int colSpawn;
        private static char[,] matrix;
        private static bool win;
        private static bool outOfArmor;
        static void Main()
        {
            armory = int.Parse(Console.ReadLine());
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
                        rowArmy = row;
                        colArmy = col;
                    }
                }

            }
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (!win || !outOfArmor)
            {
                rowSpawn = int.Parse(command[1]);
                colSpawn = int.Parse(command[2]);
                if (command[0] == "up")
                {
                    matrix[rowSpawn, colSpawn] = 'O';
                    Move(-1, 0);
                    if (win)
                    {
                        break;
                    }
                    else if (outOfArmor)
                    {
                        break;
                    }
                }
                else if (command[0] == "down")
                {
                    matrix[rowSpawn, colSpawn] = 'O';
                    Move(1, 0);
                    if (win)
                    {
                        break;
                    }
                    else if (outOfArmor)
                    {
                        break;
                    }
                }
                else if (command[0] == "left")
                {
                    matrix[rowSpawn, colSpawn] = 'O';
                    Move(0, -1);
                    if (win)
                    {
                        break;
                    }
                    else if (outOfArmor)
                    {
                        break;
                    }
                }
                else if (command[0] == "right")
                {
                    matrix[rowSpawn, colSpawn] = 'O';
                    Move(0, 1);
                    if (win)
                    {
                        break;
                    }
                    else if (outOfArmor)
                    {
                        break;
                    }
                }
                if (!win || !outOfArmor)
                {
                    command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
                
            }
            if (win)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armory}");
            }
            else if (outOfArmor)
            {
                Console.WriteLine($"The army was defeated at {rowArmy};{colArmy}.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        private static void Move(int row, int col)
        {
            matrix[rowArmy, colArmy] = '-';
            armory -= 1;
            rowArmy += row;
            colArmy += col;
            if (armory<=0)
            {
                outOfArmor = true;
                matrix[rowArmy, colArmy] = 'X';
            }
            else if (IsValid(rowArmy, colArmy))
            {
                
                if (matrix[rowArmy, colArmy] == 'M')
                {
                    win = true;
                    matrix[rowArmy, colArmy] = '-';
                }
                else if (matrix[rowArmy, colArmy] == 'O')
                {
                    armory -= 2;
                    if (armory <= 0)
                    {
                        outOfArmor = true;
                        matrix[rowArmy, colArmy] = 'X';
                    }
                    else
                        matrix[rowArmy, colArmy] = 'A';
                }
                else
                {
                    matrix[rowArmy, colArmy] = 'A';
                }
            }
            else
            {
                rowArmy -= row;
                colArmy -= col;
                matrix[rowArmy, colArmy] = 'A';

            }
        }

        private static bool IsValid(int startRow, int startCol)
        {
            return (startRow >= 0 && startRow < matrix.GetLength(0) &&
                    startCol >= 0 && startCol < matrix.GetLength(1));
        }


    }
}
