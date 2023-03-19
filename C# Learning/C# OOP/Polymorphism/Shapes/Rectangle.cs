using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Width { get; protected set; }
        public double Height { get; protected set; }
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculateArea(double width, double height)
        {
            return width * height;
        }

        public override double CalculatePerimeter(double width, double height)
        {
            return 2 * (width * height);
        }
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
