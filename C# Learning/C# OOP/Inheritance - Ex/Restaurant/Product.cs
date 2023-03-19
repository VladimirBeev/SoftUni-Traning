using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        public Product(string name , decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        private string _name;
        private decimal _price;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
