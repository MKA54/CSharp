using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Circle : IShape
    {
        public Circle(double Radius)
        {
            this.Radius = Radius;
        }
        public double Radius
        {
            get;
            set;
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
    }
}