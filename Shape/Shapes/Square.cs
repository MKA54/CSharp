using System;

namespace Shape.Shapes
{
    internal class Square : IShape
    {
        public Square(double sideLength)
        {
            Rectangle = new Rectangle(sideLength, sideLength);
        }

        public Rectangle Rectangle { get; set; }

        public double GetArea() => Rectangle.GetArea();

        public double GetHeight() => Rectangle.Height;

        public double GetPerimeter()
        {
            return Rectangle.GetPerimeter();
        }

        public double GetWidth() => Rectangle.Width;

        public override string ToString()
        {
            return string.Format($"Квадрат с длиной стороны: {Rectangle.Width}");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            var square = (Square)obj;

            return Math.Abs(square.Rectangle.Width - Rectangle.Width) <= Constans.Epsilon;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            return prime * hash + Rectangle.Width.GetHashCode();
        }
    }
}