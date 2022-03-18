using System;

namespace Shape.Shapes
{
    internal class Circle : IShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get;
        }

        public double GetArea() => Math.PI * Math.Pow(Radius, 2);

        public double GetHeight() => 2 * Radius;

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetWidth() => 2 * Radius;

        public override string ToString()
        {
            return string.Format("Окружность с радиусом: {0}", Radius);
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

            var circle = (Circle)obj;

            return Math.Abs(circle.Radius - Radius) <= Constans.Epsilon;
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            return prime * hash + Radius.GetHashCode();
        }
    }
}