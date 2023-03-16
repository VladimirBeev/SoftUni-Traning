using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main()
        {
            HashSet<string> vipGuest = new HashSet<string>();
            HashSet<string> regularGuest = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (Char.IsDigit(command[0]))
                {
                    vipGuest.Add(command);
                }
                else
                    regularGuest.Add(command);
                if (command == "PARTY")
                {
                    while (command != "END")
                    {
                        if (Char.IsDigit(command[0]))
                        {
                            vipGuest.Remove(command);
                        }
                        else
                            regularGuest.Remove(command);
                        command = Console.ReadLine();
                    }
                }
                if (command == "END")
                {
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(vipGuest.Count+regularGuest.Count);
            foreach (var item in vipGuest)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regularGuest)
            {
                Console.WriteLine(item);
            }
        }
    }
}
