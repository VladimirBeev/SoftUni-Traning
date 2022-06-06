using System;

namespace _1._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int rndNum = random.Next(words.Length);
                string currentNum = words[i];
                words[i] = words[rndNum];
                words[rndNum] = currentNum;
                
            }
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            
        }
    }
}
