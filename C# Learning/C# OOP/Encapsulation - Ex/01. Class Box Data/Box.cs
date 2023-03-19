using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ClassBoxData
{
    public class Box
    {
        private const int BoxPropertyMinValue = 0;
        private const string ZeroOrNegativArgumentExeption = "{0} cannot be zero or negative.";
        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        private double _length;
        private double _width;
        private double _height;

        public double Length
        {
            get
            {
                return this._length;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativArgumentExeption, nameof(this.Length)));
                }

                this._length = value;
            }
        }
        public double Width
        {
            get
            {
                return this._width;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativArgumentExeption, nameof(this.Width)));
                }

                this._width = value;
            }
        }
        public double Height
        {
            get
            {
                return this._height;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativArgumentExeption, nameof(this.Height)));
                }

                this._height = value;
            }
        }
        public double SurfaceArea()
            => (2 * this._length * this._width) +
                   (2 * this._length * this._height) +
                   (2 * this._width * this._height);
        public double LateralSurfaceArea()
            => (2 * this._length * this._height) + (2 * this._width * this._height);
        public double Volume()
            => this._length * this._width * this._height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
