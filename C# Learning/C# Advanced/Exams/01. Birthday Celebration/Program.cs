using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main()
        {
            int[] capacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> guests = new Stack<int>(capacity);
            int[] plateSeq = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> plate = new Stack<int>(plateSeq);
            var reverGuses = new Stack<int>(guests);
            int wasteFood = 0;

            while (IsValid(plate, reverGuses))
            {
                int platess = plate.Peek();
                int capacy = reverGuses.Peek();
                int sum = platess - capacy;
                if (IsValid(plate,reverGuses) && plate.Peek()>=reverGuses.Peek())
                {
                    wasteFood += sum;
                    plate.Pop();
                    reverGuses.Pop();
                    
                }
                else if (IsValid(plate, reverGuses)&&plate.Peek()<reverGuses.Peek())
                {
                    plate.Pop();
                    reverGuses.Pop();
                    reverGuses.Push(Math.Abs(sum));
                }
                if (IsValid(plate, reverGuses)&&reverGuses.Peek() <= 0)
                {
                    reverGuses.Pop();
                }

            }
            if (plate.Count == 0)
            {
                var revers = new Stack<int>(reverGuses);
                Console.WriteLine($"Guests: {string.Join(" ", reverGuses)}");
            }
            else if (reverGuses.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plate)}");
            }
            Console.WriteLine($"Wasted grams of food: {wasteFood}");
        }

        private static bool IsValid(Stack<int> plate, Stack<int> reverGuses)
        {
            return plate.Count != 0 && reverGuses.Count != 0;
        }
    }
}
