using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main()
        {
            
            Box<int> input = new Box<int>();
            input.Add(1);
            input.Add(2);
            input.Add(3);
            Console.WriteLine(input.Remove());
            input.Add(4);
            input.Add(5);
            Console.WriteLine(input.Remove());
          
        }
    }
}
