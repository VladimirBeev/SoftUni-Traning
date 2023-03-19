using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main()
        {
            string[] arrMeals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] arrCalories = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<string> meals = new Queue<string>(arrMeals);
            Stack<int> calories = new Stack<int>(arrCalories);
            int numberOfMeals = meals.Count;
            while (meals.Count != 0 && calories.Count != 0)
            {
                if (meals.Peek() == "salad")
                {
                    if (calories.Count > 0)
                    {
                        int currentCalories = calories.Peek() - 350;
                        Calculate(currentCalories,meals,calories);
                    }
                    else
                        break;
                }
                else if (meals.Peek() == "soup")
                {
                    if (calories.Count > 0)
                    {
                        int currentCalories = calories.Peek() - 490;
                        Calculate(currentCalories, meals, calories);
                    }
                    else
                        break;
                }
                else if (meals.Peek() == "pasta")
                {
                    if (calories.Count > 0)
                    {
                        int currentCalories = calories.Peek() - 680;
                        Calculate(currentCalories, meals, calories);
                    }
                    else
                        break;
                }
                else if (meals.Peek() == "steak")
                {
                    if (calories.Count > 0)
                    {
                        int currentCalories = calories.Peek() - 790;
                        Calculate(currentCalories, meals, calories);
                    }
                    else
                        break;
                }
            }
            
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals-meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
        private static void Calculate(int currentCalories, Queue<string> meals, Stack<int> calories)
        {
            if (currentCalories < 0)
            {
                calories.Pop();
                if (calories.Count == 0)
                {
                    meals.Dequeue();
                    return;
                }
                else
                {
                    int dayEnd = calories.Peek() + currentCalories;
                    calories.Pop();
                    calories.Push(dayEnd);
                    meals.Dequeue();
                }
            }
            else
            {
                calories.Pop();
                calories.Push(currentCalories);
                meals.Dequeue();
                return;
            }
        }

    }
}

