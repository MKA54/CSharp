using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Circle : IShape
    {
        private const double Epsilon = 1.0e-10;
        public Circle(double Radius)
        {
            this.Radius = Radius;
        }

        public double Radius
        {
            get;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public override string ToString()
        {
            return string.Format("Окружность с радиусом: {0}", Radius);
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

            Circle Circle = (Circle)Obj;

            return Math.Abs(Circle.Radius - Radius) <= Epsilon;
        }

        public override int GetHashCode()
        {
            var Prime = 37;
            var Hash = 1;

            return Prime * Hash + Radius.GetHashCode();
        }
    }
}