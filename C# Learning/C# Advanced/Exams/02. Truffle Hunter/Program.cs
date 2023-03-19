using System;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];
            for (int row = 0; row < size; row++)
            {
                char[] elementsRow = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = elementsRow[col];
                }
            }
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int boarEat = 0;
            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] comm = command.Split(' ');
                string action = comm[0];
                int row = int.Parse(comm[1]);
                int col = int.Parse(comm[2]);
                if (action == "Collect")
                {
                    if (row>=0 && row < size && col>=0 && col < size)
                    {
                        char truffle = matrix[row, col];
                        char emty = '-';
                        if (truffle == 'B')
                        {
                            blackTruffle++;
                            matrix[row, col] = emty;
                        }
                        if (truffle == 'S')
                        {
                            summerTruffle++;
                            matrix[row, col] = emty;
                        }
                        if (truffle == 'W')
                        {
                            whiteTruffle++;
                            matrix[row, col] = emty;
                        }
                    }
                }
                if (action == "Wild_Boar")
                {
                    string directions = comm[3];
                    while (directions == "up" && row >= 0 && row < size && col >= 0 && col < size)
                    {
                        if (row >= 0 && row < size && col >= 0 && col < size)
                        {
                            char truffle = matrix[row, col];
                            char emty = '-';
                            if (truffle == 'B')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'S')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'W')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                        }
                        row-=2;
                    }
                    while (directions == "down"&& row >= 0 && row < size && col >= 0 && col < size)
                    {
                        if (row >= 0 && row < size && col >= 0 && col < size)
                        {
                            char truffle = matrix[row, col];
                            char emty = '-';
                            if (truffle == 'B')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'S')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'W')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                        }
                        row += 2;
                    }
                    while (directions == "left" && row >= 0 && row < size && col >= 0 && col < size)
                    {
                        if (row >= 0 && row < size && col >= 0 && col < size)
                        {
                            char truffle = matrix[row, col];
                            char emty = '-';
                            if (truffle == 'B')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'S')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'W')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                        }
                        col -= 2;
                    }
                    while (directions == "right" && row >= 0 && row < size && col >= 0 && col < size)
                    {
                        if (row >= 0 && row < size && col >= 0 && col < size)
                        {
                            char truffle = matrix[row, col];
                            char emty = '-';
                            if (truffle == 'B')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'S')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                            if (truffle == 'W')
                            {
                                boarEat++;
                                matrix[row, col] = emty;
                            }
                        }
                        col += 2;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarEat} truffles.");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
