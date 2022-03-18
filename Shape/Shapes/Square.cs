using System;

namespace Shape.Shapes
{
    internal class Square : IShape
    {
        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double SideLength
        {
            get;
        }

        public double GetArea() => SideLength * SideLength;

        public double GetHeight() => SideLength;

        public double GetPerimeter()
        {
            const int sidesCount = 4;
            return SideLength * sidesCount;
        }

        public double GetWidth() => SideLength;

        public override string ToString()
        {
            return string.Format("Квадрат с длиной стороны: {0}", SideLength);
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

            return Math.Abs(square.SideLength - SideLength) <= Constans.Epsilon;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            return prime * hash + SideLength.GetHashCode();
        }
    }
}