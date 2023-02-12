using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] twoWord = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            int tottalSum = 0;
           

            string firstWord = twoWord.First();
            string seconWord = twoWord.Last();
            
            char[] firstChar = firstWord.ToCharArray();
            char[] secondChar = seconWord.ToCharArray();

            if (secondChar.Length>firstChar.Length)
            {
                for (int i = 0; i < secondChar.Length; i++)
                {
                    for (int j = i; j < firstChar.Length; j++)
                    {
                        sum = secondChar[j] * firstChar[j];
                        tottalSum += sum;
                        break;
                    }
                }
                for (int i = firstChar.Length; i < secondChar.Length; i++)
                {
                    tottalSum += secondChar[i];
                }
            }
            if (firstChar.Length > secondChar.Length)
            {
                for (int i = 0; i < firstChar.Length; i++)
                {
                    for (int j = i; j < secondChar.Length; j++)
                    {
                        sum = secondChar[j] * firstChar[j];
                        tottalSum += sum;
                        break;
                    }
                }
                for (int i = secondChar.Length; i < firstChar.Length; i++)
                {
                    tottalSum += firstChar[i];
                }
            }
            if (secondChar.Length == firstChar.Length)
            {
                for (int i = 0; i < secondChar.Length; i++)
                {
                    for (int j = i; j < firstChar.Length; j++)
                    {
                        sum = secondChar[j] * firstChar[j];
                        tottalSum += sum;
                        break;
                    }
                }
                
            }
            Console.WriteLine(tottalSum);
        }
    }
}
