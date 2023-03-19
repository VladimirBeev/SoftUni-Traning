using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private double _modifier;
        private int _caloriesPerGram = 2;
        private string _toppingType;
        private double _wight;
        public Topping(string toppingType,double wight) 
        {
            this.ToppingType = toppingType;
            this.Wight = wight;
        }

        public int CaloriesPerGram
        {
            get
            {
                return this._caloriesPerGram;
            }
        }
        public string ToppingType
        {
            get
            {
                return this._toppingType;
            }
            private set
            {
                if (value.ToLower() == "meat")
                {
                    this._modifier = 1.2;
                    this._toppingType = value;
                }
                else if (value.ToLower() == "veggies")
                {
                    this._modifier = 0.8;
                    this._toppingType = value;
                }
                else if (value.ToLower() == "cheese")
                {
                    this._modifier = 1.1;
                    this._toppingType = value;
                }
                else if (value.ToLower() == "sauce")
                {
                    this._modifier = 0.9;
                    this._toppingType = value;
                }
                else
                {
                    this._toppingType = value;
                    throw new Exception($"Cannot place {this.ToppingType} on top of your pizza.");
                }
                    
            }
        }
        public double Wight
        {
            get
            {
                return this._wight;
            }
            private set
            {
                if (value<1 || value >50)
                {
                    throw new Exception($"{this.ToppingType} weight should be in the range [1..50].");
                }
                this._wight = value;
            }
        }
        public double ToppingCalories => (this.Wight * (this.CaloriesPerGram * this._modifier));
    }
}
