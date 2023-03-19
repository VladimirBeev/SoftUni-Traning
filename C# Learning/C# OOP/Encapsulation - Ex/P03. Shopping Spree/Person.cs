using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string _name;
        private decimal _money;
        private List<Product> _bagOfProducts;
        public Person(string name,decimal money)
        {
            this.Name = name;
            this.Money = money;
            this._bagOfProducts = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products => this._bagOfProducts;
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this._name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this._money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this._money = value;
            }
        }
        public bool AddProduct(Product product)
        {
            if (this.Money - product.Coste < 0 )
            {
                return false;
            }

            this._bagOfProducts.Add(product);
            this.Money -= product.Coste;

            return true;
        }
    }
}
