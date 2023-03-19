using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (this.Capacity>0)
            {
                this.Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            return this.Data.Remove(this.Data.Find(s => s.Manufacturer == manufacturer && s.Model == model));
            //bool remove = false;
            //foreach (Ski ski in this.Data)
            //{
            //    if (ski.Manufacturer == manufacturer && ski.Model == model)
            //    {
            //        this.Data.Remove(ski);
            //    }
            //}
            //if (remove)
            //{
            //    return  true;
            //}
            //else
            //    return false;
        }
        public Ski GetNewestSki()
        {
            int year = 0;
            foreach (Ski ski in this.Data)
            {
                if (ski.Year > year)
                {
                    year = ski.Year;
                }
            }
            if (year > 0)
            {
                return this.Data.Find(s => s.Year == year);
            }
            else
                return null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return this.Data.Find(s => s.Manufacturer == manufacturer && s.Model == model);
        }
        public int Count => this.Data.Count;
        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:\n{string.Join("\n",this.Data)}";
                    
                
        }
    }
}
