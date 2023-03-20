using System;
using System.Linq;

namespace _01._Reverse_Array
{
    public class Program
    {
        static void Main()
        {
            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
           
            Reversed(elements,0);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void Reversed(string[] elements, int index)
        {
            if (index >= elements.Length/2)
            {
                return;
            }
            var temp = elements[index];
            elements[index] = elements[elements.Length-1-index];
            elements[elements.Length-1-index] = temp;
            Reversed(elements, index+1);
        }
    }
}
