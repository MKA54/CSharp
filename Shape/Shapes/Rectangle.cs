using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Rectangle : IShape
    {
        private const double Epsilon = 1.0e-10;

        public Rectangle(double Width, double Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public double Width
        {
            get;
        }

        public double Height
        {
            get;
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

        public override bool Equals(object Obj)
        {
            if (ReferenceEquals(Obj, this))
            {
                return true;
            }

            if (ReferenceEquals(Obj, null) || Obj.GetType() != this.GetType())
            {
                return false;
            }

            Rectangle Rectangle = (Rectangle)Obj;

            return Math.Abs(Rectangle.Width - Width) <= Epsilon && Math.Abs(Rectangle.Height - Height) <= Epsilon;
        }

        public override int GetHashCode()
        {
            var Prime = 37;
            var Hash = 1;

            Hash = Prime * Hash + Width.GetHashCode();

            return Prime * Hash + Height.GetHashCode();
        }
    }
}