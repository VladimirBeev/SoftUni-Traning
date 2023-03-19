using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int _radius;
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius
        {
            get
            {
                return this._radius;
            }
            private set
            {
                this._radius = value;
            }
        }

        public void Draw()
        {
            double rIn = this._radius - 0.4;
            double rOut = this._radius + 0.4;
            for (double y = this._radius; y >= -this._radius; --y)
            {
                for (double x = -this._radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        
    }
}
