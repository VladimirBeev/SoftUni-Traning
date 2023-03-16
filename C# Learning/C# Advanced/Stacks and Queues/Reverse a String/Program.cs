﻿using System;
using System.Collections.Generic;

namespace ReverseaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            foreach (char ch in str)
            {
                stack.Push(ch);
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
