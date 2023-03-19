using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; private set; }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }
        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            if (fish.Weight<= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            if (Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            List<Fish> count = this.Fish.Where(f => f.Weight == weight).ToList();
            foreach (Fish item in count)
            {
                Fish.Remove(item);
            }
            return count.Count > 0;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = this.Fish.Find(f => f.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            double maxValue = 0;
            foreach (Fish item in Fish)
            {
                
                if (maxValue<item.Weight)
                {
                    maxValue = item.Weight;
                }
            }
            double max = maxValue;
            Fish fish = this.Fish.Find(f=>f.Weight == max);
            return fish;
        }
        public string Report()
        {
            return $"Into the {this.Material}: " + Environment.NewLine +$"{string.Join(Environment.NewLine,Fish.OrderByDescending(f=>f.Length))}";

        }
    }
}
