using System;

namespace Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int Project = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {Project*3} hours to complete {Project} project/s.");

        }
    }
}
