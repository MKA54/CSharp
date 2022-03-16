using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Square : IShape
    {
        private const double Epsilon = 1.0e-10;

        public Square(double SideLength)
        {
            this.SideLength = SideLength;
        }

        public double SideLength
        {
            get;
        }

        public double GetArea() => SideLength * SideLength;

        public double GetHeight() => SideLength;

        public double GetPerimeter()
        {
            const int SidesCount = 4;
            return SideLength * SidesCount;

        }

        public double GetWidth() => SideLength;

        public override string ToString()
        {
            return string.Format("Квадрат с длиной стороны: {0}", SideLength);
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

           Square Square = (Square)Obj;

           return Math.Abs(Square.SideLength - SideLength) <= Epsilon;
        }

        public override int GetHashCode()
        {
            var Prime = 37;
            var Hash = 1;

            return Prime * Hash + SideLength.GetHashCode();
        }
    }
}