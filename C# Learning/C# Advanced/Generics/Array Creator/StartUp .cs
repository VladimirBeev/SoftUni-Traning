﻿using System;

namespace GenericArrayCreator
{
    public class Program
    {
        static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
