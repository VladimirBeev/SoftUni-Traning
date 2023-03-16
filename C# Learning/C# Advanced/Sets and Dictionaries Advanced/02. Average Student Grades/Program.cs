using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < numStudents; i++)
            {
                var nameAndGrades = Console.ReadLine().Split();
                string name = nameAndGrades[0];
                decimal grades = decimal.Parse(nameAndGrades[1]);
                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                    
                }
                students[name].Add(grades);
            }
            //foreach (var item in students)
            //{
            //    Console.WriteLine($"{item.Key} -> {string.Join(" ",item.Value):F2} (avg: {item.Value.Average():F2})");
            //}
            foreach (var name in students)
            {
                var average = name.Value.Average();
                Console.Write($"{name.Key} -> ");
                foreach (var grade in name.Value)
                    Console.Write($"{grade:f2} ");
                Console.WriteLine($"(avg: {average:f2})");
            }

        }
    }
}
