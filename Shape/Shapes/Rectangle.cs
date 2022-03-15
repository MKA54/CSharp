using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Rectangle : IShape
    {
        public Rectangle(double Width, double Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public double Width
        {
            get;
            set;
        }
        public double Height
        {
            get;
            set;
        }
        public double GetArea()
        {
            return Width * Height;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetPerimeter()
        {
            return (Width + Height) * 2;
        }

        public double GetWidth()
        {
            return Width;
        }

        public override string ToString()
        {
            return string.Format("Прямоугольник с размерами: ширина-{0}, длина-{1}", Width, Height);
        }
    }
}