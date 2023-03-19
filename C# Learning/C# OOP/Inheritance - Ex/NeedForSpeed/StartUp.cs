using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car(90, 100);
            car.Drive(50);
            Console.WriteLine(car.Fuel);
        }
    }
}
