using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double CalculateArea(double radius, double pi)
        {
            return (radius * radius) * pi;
        }

        public override double CalculatePerimeter(double radius, double pi)
        {
            return 2 * radius * pi;
        }
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
