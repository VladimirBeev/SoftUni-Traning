using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter(double width, double height);
        public abstract double CalculateArea(double width, double height);
        public virtual string Draw()
        {
            return $"";
        }
    }
}
