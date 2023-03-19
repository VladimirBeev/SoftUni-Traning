using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        private static Queue<Subordinate> subordinates;
        static void Main()
        {
            List<Citizens> human = new List<Citizens>();
            List<Rebel> rebels = new List<Rebel>();
            //subordinates = new Queue<Subordinate>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] action = Console.ReadLine().Split(' ');
                if (action.Length > 3)
                {
                    Citizens people = new Citizens(action[0],int.Parse(action[1]),action[2],action[3]);
                    human.Add(people);
                    //subordinates.Enqueue(people);
                }
                else
                {
                    Rebel rebel = new Rebel(action[0], int.Parse(action[1]), action[2]);
                    rebels.Add(rebel);
                    //subordinates.Enqueue(rebel);
                }
            }
            string command = Console.ReadLine();
            var food = 0;
            while (command != "End")
            {

                foreach (var item in human)
                {
                    if (item.Name.Contains(command))
                    {
                        food += item.BuyFood();
                    }
                }
                foreach (var item in rebels)
                {
                    if (item.Name.Contains(command))
                    {
                        food += item.BuyFood();
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(food);
            //string year = Console.ReadLine();
            //Birthday(year);
        }

        private static void Birthday(string year)
        {
            foreach (var sub in subordinates)
            {
                if (!string.IsNullOrEmpty(sub.Birthday))
                {
                    var hunma = sub.Birthday.EndsWith(year);
                    if (hunma)
                    {
                        Console.WriteLine(sub.Birthday);
                    }
                }
            }
        }
    }
}
