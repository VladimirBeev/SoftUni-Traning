using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dividing_Presents
{
    public class Program
    {
        static void Main()
        {
            var presents = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var allSums = FindAllSums(presents);

            var totalSum = presents.Sum();
            var half = totalSum / 2;

            while (true)
            {
                if (allSums.ContainsKey(half))
                {
                    var alanPresents = FindSubset(half,allSums);
                    var bobsum = totalSum - half;
                    Console.WriteLine($"Difference: {bobsum-half}");
                    Console.WriteLine($"Alan:{half} Bob:{bobsum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ",alanPresents)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }
                half -= 1;
            }
          
        }

        private static List<int> FindSubset(int targetSum, Dictionary<int, int> allSums)
        {
            var subset = new List<int>();
            while(targetSum>0)
            {
                var lastNum = allSums[targetSum];
                subset.Add(lastNum);
                targetSum -= lastNum;
            }
            
            return subset;
        }

        private static Dictionary<int, int> FindAllSums(int[] presents)
        {
            var possibleSum = new Dictionary<int, int> { { 0, 0 } };
            foreach (var num in presents)
            {
                var newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSum.Keys)
                {
                    var newSum = sum + num;
                    if (!possibleSum.ContainsKey(newSum))
                    {
                        newSums.Add(newSum, num);
                    }
                }
                foreach (var sum in newSums)
                {
                    possibleSum.Add(sum.Key, sum.Value);
                }
            }
            return possibleSum;
        }
    }
}
