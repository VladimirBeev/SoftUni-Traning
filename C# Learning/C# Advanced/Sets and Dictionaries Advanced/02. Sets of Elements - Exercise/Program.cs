using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numInt = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            for (int i = 0; i < numInt[0]; i++)
            {
                int numOfOne = int.Parse(Console.ReadLine());
                setOne.Add(numOfOne);
            }
            for (int i = 0; i < numInt[1]; i++)
            {
                int numOfTwo = int.Parse(Console.ReadLine());
                setTwo.Add(numOfTwo);
            }

            if (setOne.Count >= setTwo.Count)
            {
                foreach (var item in setOne)
                {
                    if (setTwo.Contains(item))
                    {
                        setOne.Add(item);
                    }
                    else
                    {
                        setOne.Remove(item);
                    }
                }
                foreach (var item in setOne)
                {
                    Console.Write($"{item} ");
                }
            }
            else
            {
                foreach (var item in setTwo)
                {
                    if (setOne.Contains(item))
                    {
                        setTwo.Add(item);
                    }
                    else
                    {
                        setTwo.Remove(item);
                    }
                }
                foreach (var item in setTwo)
                {
                    Console.Write($"{item} ");
                }
            }

        }
    }
}
