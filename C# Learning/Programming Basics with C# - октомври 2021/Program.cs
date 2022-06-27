using System;

namespace Basketball_Equipment
{
    class Basketball_Equipment
    {
        static void Main(string[] args)
        {
            double fee = double.Parse(Console.ReadLine());
            double kecove = fee - (fee * 0.4);
            
            double ekip = kecove - (kecove * 0.2);
           
            double ball = ekip / 4;
         
            double acsess = ball / 5;
          
            Console.WriteLine(kecove + ekip + ball + acsess+ fee);
        }
    }
}
