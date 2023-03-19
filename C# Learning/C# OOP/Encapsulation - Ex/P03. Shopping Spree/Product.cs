using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {
        private string _name;
        private decimal _cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Coste = cost;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this._name = value;
            }
        }
        public decimal Coste
        {
            get
            {
                return this._cost;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this._cost = value;
            }
        }
    }
}
