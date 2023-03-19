using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string _name;
        private Dough _dough;
        private List<Topping> _toppings;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this._toppings = new List<Topping>();
        }
        public Dough Dough { get; private set; }
        
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this._name = value;
            }

        }
        public int CountTopping => this._toppings.Count;
        public void AddTopping(Topping topping)
        {
            if (this._toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this._toppings.Add(topping);
        }
        public double TotalCalories()
        {
            
            return (this.Dough.DoughtCalories + this._toppings.Sum(x => x.ToppingCalories));
        }
    }
}
