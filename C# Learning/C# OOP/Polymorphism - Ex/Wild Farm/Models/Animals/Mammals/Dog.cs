﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFoods 
            => new List<Type> {typeof(Meat)}.AsReadOnly();

        protected override double WeightMultiplier => DogWeightMultiplier;

        public override string ProduseSound()
        {
            return $"Woof!";
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}