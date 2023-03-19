using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int _width;
        private int _height;
        public Rectangle(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this._width;
            }
            private set
            {
                this._width = value;
            }
        }
        public int Height
        {
            get
            {
                return this._height;
            }
            private set
            {
                this._height = value;
            }
        }

        public void Draw()
        {
            DrawLine(this._width, '*', '*');
            for (int i = 1; i < this._height - 1; ++i)
                DrawLine(this._width, '*', ' ');
            DrawLine(this._width, '*', '*');
        }
        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
                Console.Write(mid);
            Console.WriteLine(end);
        }
    }
    
}
