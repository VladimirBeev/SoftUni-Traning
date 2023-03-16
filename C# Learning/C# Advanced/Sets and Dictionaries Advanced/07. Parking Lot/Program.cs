using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main()
        {
            HashSet<string> set = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] action = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = action[0];
                string carNumber = action[1];
                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    set.Remove(carNumber);
                }
                command = Console.ReadLine();
            }
            if (set.Any())
            {
                foreach (string number in set)
                {
                    Console.WriteLine(number);
                }
            }
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}
