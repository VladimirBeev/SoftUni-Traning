using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Count_Symbols___Exercise
{
    internal class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            char[] chars = word.ToCharArray();
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!dictionary.ContainsKey(chars[i]))
                {
                    dictionary.Add(chars[i], 1);
                }
                else
                    dictionary[chars[i]]++;
            }
            foreach (var c in dictionary)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
