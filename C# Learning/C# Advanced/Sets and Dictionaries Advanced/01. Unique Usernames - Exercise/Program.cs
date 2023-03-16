using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Unique_Usernames___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbName = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < numbName; i++)
            {
                string nameOfPeople = Console.ReadLine();
                names.Add(nameOfPeople);
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
