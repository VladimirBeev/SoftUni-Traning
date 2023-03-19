using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough 
    {
        private double _CaloryPerGram = 2;
        private double _ModifiersFlour = 0;
        private double _ModifiersBeak = 0;
        private string _flourType;
        private string _bakingtechnique;
        private double _weigh;
        public Dough(string flourType, string baking,double weight)
        {
            this.FlourType = flourType;
            this.Bakingtechnique = baking;
            this.Weigh = weight;
        }
        public double CaloryPerGram
        {
            get
            {
                return _CaloryPerGram;
            }
        }
        public string FlourType
        {
            get
            {
                return this._flourType;
            }
            private set
            {
                if (value.ToLower() == "white")
                {
                    this._ModifiersFlour = 1.5;
                    this._flourType = value;
                }
                else if (value.ToLower() == "wholegrain")
                {
                    this._ModifiersFlour = 1.0;
                    this._flourType = value;
                }
                else
                    throw new Exception("Invalid type of dough.");
            }
        }
        public string Bakingtechnique
        {
            get
            {
                return this._bakingtechnique;
            }
            private set
            {
                if (value.ToLower() == "crispy")
                {
                    this._ModifiersBeak = 0.9;
                    this._bakingtechnique = value;
                }
                else if (value.ToLower() == "chewy")
                {
                    this._ModifiersBeak = 1.1;
                    this._bakingtechnique = value;
                }
                else if (value.ToLower() == "homemade")
                {
                    this._ModifiersBeak = 1.0;
                    this._bakingtechnique = value;
                }
                else
                    throw new Exception("Invalid type of dough.");
            }
        }
        public double Weigh
        {
            get
            {
                return this._weigh;
            }
            private set
            {
                if (value<1 || value>200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this._weigh = value;
            }
        }
        public double DoughtCalories => ((this._CaloryPerGram * this.Weigh) * this._ModifiersFlour * this._ModifiersBeak);
    }
}
