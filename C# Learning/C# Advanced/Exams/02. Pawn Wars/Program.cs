using System;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static int rowWhite;
        static int colWhite;
        static bool eatWhite;
        static bool lastRnakWhhite;
        static string cordWhite;
        static int rowBlack;
        static int colBlack;
        static bool eatBlack;
        static bool lastRankBlack;
        static string cordBlack;
        static char[,] matrix;

        static void Main()
        {
            matrix = new char[8, 8];
            
            for (int row = 0; row < 8; row++)
            {
                string elements = Console.ReadLine();
                char[] element = elements.ToCharArray();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = element[col];
                    if (matrix[row,col] == 'w')
                    {
                        rowWhite = row;
                        colWhite = col;
                    }
                    if (matrix[row,col]=='b')
                    {
                        rowBlack = row;
                        colBlack = col;
                    }
                }
            }
            while (!eatWhite && !eatBlack && !lastRnakWhhite && !lastRankBlack)
            {
                if (IsVsalid(rowWhite-1,colWhite-1) && matrix[rowWhite - 1, colWhite - 1] == 'b')
                {
                    eatWhite = true;
                    WhiteMove(-1, -1);
                    break;
                }
                else if (IsVsalid(rowWhite - 1, colWhite + 1 )&& matrix[rowWhite-1,colWhite+1] == 'b')
                {
                    eatWhite = true;
                    WhiteMove(-1, 1);
                    break;
                }
                else
                {
                    WhiteMove(-1, 0);
                    int rankWhite = 8;
                    int rowcord = 8 - rowWhite;
                    if (rankWhite == rowcord)
                    {
                        lastRnakWhhite = true;
                        break;
                    }
                }


                if (IsVsalid(rowBlack + 1, colBlack - 1) && matrix[rowBlack + 1, colBlack - 1] == 'w')
                {
                    eatBlack = true;
                    BlackMove(1, -1);
                    break;
                }
                else if (IsVsalid(rowBlack + 1, colBlack + 1) && matrix[rowBlack + 1, colBlack + 1] == 'w')
                {
                    eatBlack = true;
                    BlackMove(1, 1);
                    break;
                }
                else
                {
                    BlackMove(1, 0);
                    int rankBlack = 1;
                    int rowcords = 8 - rowBlack;
                    if (rankBlack == rowcords)
                    {
                        lastRankBlack = true;
                        break;
                    }
                }
            }
            if (eatWhite)
            {
                Console.WriteLine($"Game over! White capture on {cordWhite}.");
            }
            else if (eatBlack)
            {
                Console.WriteLine($"Game over! Black capture on {cordBlack}.");
            }
            else if (lastRnakWhhite)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {cordWhite}.");
            }
            else if (lastRankBlack)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {cordBlack}.");
            }

        }

        private static bool IsVsalid(int row, int col)
        {
            return (row>=0 && row<8 && col>=0 && col<8);
        }

        private static void BlackMove(int row, int col)
        {
            matrix[rowBlack, colBlack] = '-';
            rowBlack += row;
            colBlack += col;
            if (IsVsalid(rowBlack,colBlack))
            {
                int rowcords = 8 - rowBlack;
                char colCord = (char)(97 + colBlack);
                cordBlack = $"{colCord}" + rowcords;
                matrix[rowBlack, colBlack] = 'b';
                
            }
            
        }

        private static void WhiteMove(int row,int col)
        {
            matrix[rowWhite, colWhite] = '-';
            rowWhite += row;
            colWhite += col;
            if (IsVsalid(rowWhite,colWhite))
            {
                int rowcord = 8 - rowWhite;
                char a = (char)(97 + colWhite);
                cordWhite = $"{a}" + rowcord;
                matrix[rowWhite, colWhite] = 'w';
               
            }
            
        }
    }
}
