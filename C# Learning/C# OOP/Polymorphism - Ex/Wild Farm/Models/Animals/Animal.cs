using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Exeption;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        //string Name, double Weight, int FoodEaten
        public string Name { get;}
        public double Weight { get;private set; }
        public int FoodEaten { get; private set; }
        protected abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        protected abstract double WeightMultiplier { get; }
        public abstract string ProduseSound();
        public void Eat(Food food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new FoodNotPreferredExeption(String.Format(ExeptionMessage.FoodNotPreferred, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightMultiplier;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
