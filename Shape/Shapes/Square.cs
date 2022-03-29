using System;

namespace Shape.Shapes
{
    internal class Square : IShape
    {
        public Square(double sideLength)
        {
            Rectangle = new Rectangle(sideLength, sideLength);
        }

        private Rectangle Rectangle { get; set; }

        public double GetArea() => Rectangle.GetArea();

        public double GetHeight() => Rectangle.Height;

        public double GetPerimeter()
        {
            return Rectangle.GetPerimeter();
        }

        public double GetWidth() => Rectangle.Width;

        public override string ToString()
        {
            return $"Квадрат с длиной стороны: {Rectangle.Width}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var square = (Square)obj;

            return Math.Abs(square.Rectangle.Width - Rectangle.Width) <= Constants.Epsilon;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            const int hash = 1;

            return prime * hash + GetWidth().GetHashCode();
        }
    }
}