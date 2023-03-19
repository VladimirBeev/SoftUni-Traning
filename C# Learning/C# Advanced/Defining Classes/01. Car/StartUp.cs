using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            //var tires = new Tire[4]
            //{
            //    new Tire(1,2.5),
            //    new Tire(1,2.1),
            //    new Tire(2,0.5),
            //    new Tire(2,2.3)
            //};
            //var engine = new Engine(560, 6300);
            //var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> TireDictionary = new Dictionary<int, double>();

            while (command[0] != "No more tires")
            {
                for (int i = 0; i < command.Length; i++)
                {
                    int tireee = int.Parse(command[i]);
                    double press = double.Parse(command[i + 1]);
                    TireDictionary.Add(tireee, press);
                    i++;
                }
            }
            command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
