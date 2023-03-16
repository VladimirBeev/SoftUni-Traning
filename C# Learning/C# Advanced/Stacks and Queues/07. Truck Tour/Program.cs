using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<Pompa> stack = new Stack<Pompa>();    
            int amount = 0;
            int distace = 0;
            int indexStart = 0;
            for (int i = 0; i < n; i++)
            {
                int[] amountAndDistance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                amount = amountAndDistance[0];
                distace = amountAndDistance[1];
                stack.Push(new Pompa(amount, distace,i)); 
            }
            foreach (Pompa pompa in stack)
            {
                int ama = pompa.amount;
                int dis = pompa.distace;
                if (ama > dis)
                {
                    indexStart = pompa.name;
                    break;
                }
            }
            Console.WriteLine(indexStart);
        }
    }
    class Pompa
    {
        public int name { get; set; }
        public int amount { get; set; }
        public int distace { get; set; }
        public Pompa(int amount, int distace, int i)
        {
            this.name = i;
            this.amount = amount;
            this.distace = distace;
        }
       
    }
}
