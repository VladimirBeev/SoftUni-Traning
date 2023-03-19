using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    internal class StartUp
    {
        static void Main()
        {
            int numberCar = int.Parse(Console.ReadLine());
            List<Car> listCar = new List<Car>();
            List<Engine> listEngine = new List<Engine>();
            List<Cargo> listCargo = new List<Cargo>();
            List<Tire[]> listTire = new List<Tire[]>();

            for (int i = 0; i < numberCar; i++)
            {
                string[] commandCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = commandCar[0];
                int engineSpeed = int.Parse(commandCar[1]);
                int enginePower = int.Parse(commandCar[2]);
                int cargoWeight = int.Parse(commandCar[3]);
                string cargoType = commandCar[4];
                double tire1Pressure = double.Parse(commandCar[5]);
                int tire1Age = int.Parse(commandCar[6]);
                double tire2Pressure = double.Parse(commandCar[7]);
                int tire2Age = int.Parse(commandCar[8]);
                double tire3Pressure = double.Parse(commandCar[9]);
                int tire3Age = int.Parse(commandCar[10]);
                double tire4Pressure = double.Parse(commandCar[11]);
                int tire4Age = int.Parse(commandCar[12]);
                Car car = new Car(model);
                car.Model = model;
                listCar.Add(car);
                Engine engineCar = new Engine(engineSpeed, enginePower);
                engineCar.Speed = engineSpeed;
                engineCar.Power = enginePower;
                listEngine.Add(engineCar);
                Cargo cargoCar = new Cargo(cargoType, cargoWeight);
                cargoCar.Weight = cargoWeight;
                cargoCar.Type = cargoType;
                listCargo.Add(cargoCar);
                Tire[] tiresCar = new Tire[4]
                {
                    new Tire(tire1Age,tire1Pressure),
                    new Tire(tire2Age,tire2Pressure),
                    new Tire(tire3Age,tire3Pressure),
                    new Tire(tire4Age,tire4Pressure)
                };
                listTire.Add(tiresCar);

            }
            
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                
            }
            else if (command == "flammable")
            {

            }
        }
    }
}
