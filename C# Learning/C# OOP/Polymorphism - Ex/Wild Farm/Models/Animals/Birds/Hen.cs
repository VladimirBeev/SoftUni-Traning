using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFoods 
            => new List<Type> { typeof(Meat), typeof(Fruit),typeof(Seeds), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightMultiplier => HenWeightMultiplier;

        public override string ProduseSound()
        {
            return $"Cluck";
        }
    }
}
