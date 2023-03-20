using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Cinema
{
    internal class Program
    {
        private static List<string> nonStaticProple;
        private static string[] people;
        private static bool[] locked;

        public static void Main()
        {
            nonStaticProple = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            people = new string[nonStaticProple.Count];
            locked = new bool[nonStaticProple.Count];
            var commands = Console.ReadLine();
            while (commands != "generate")
            {
                var action = commands.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                var name = action[0];
                var place = int.Parse(action[1])-1;
                people[place] = name;
                locked[place] = true;


                nonStaticProple.Remove(name);

                commands = Console.ReadLine();
            }
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index>=nonStaticProple.Count)
            {
                PrintPermutation();
                return;
            }        
            

            Permute(index+1);

            for (int i = index+1; i < nonStaticProple.Count; i++)
            {
                Swap(index, i);
                Permute(index+1);
                Swap(index, i);
            }
        }

        private static void PrintPermutation()
        {
            var peopleindex = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (!locked[i])
                {
                    people[i] = nonStaticProple[peopleindex++];
                }
            }
            Console.WriteLine(string.Join(" ",people));
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticProple[first];
            nonStaticProple[first] = nonStaticProple[second];
            nonStaticProple[second] = temp;
        }
    }
}
