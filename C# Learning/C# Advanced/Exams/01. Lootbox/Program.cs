using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> list = new List<int>();
            while (firstBox.Count!=0 && secondBox.Count != 0)
            {
                int sum = firstBox.Peek() + secondBox.Peek();
                if (sum % 2 == 0)
                {
                    list.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int secondNum = secondBox.Peek();
                    secondBox.Pop();
                    firstBox.Enqueue(secondNum);
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
                Console.WriteLine("Second lootbox is empty");
            if (list.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {list.Sum()}");
            }
            else
                Console.WriteLine($"Your loot was poor... Value: {list.Sum()}");
        }
    }
}
