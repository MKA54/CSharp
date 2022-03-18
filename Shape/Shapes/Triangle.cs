using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Triangle : IShape
    {
        private const double Epsilon = 1.0e-10;

        public Triangle(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
            this.X3 = X3;
            this.Y3 = Y3;
        }

        public double X1
        {
            get;
        }

        public double Y1
        {
            get;
        }

        public double X2
        {
            get;
        }

        public double Y2
        {
            get;
        }

        public double X3
        {
            get;
        }

        public double Y3
        {
            get;
        }
        private static double GetSegmentLength(double X1, double Y1, double X2, double Y2) => 
            Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));

        public double GetArea()
        {
            var triangleHalfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(triangleHalfPerimeter * (triangleHalfPerimeter - GetSegmentLength(X1, Y1, X2, Y2))
                    * (triangleHalfPerimeter - GetSegmentLength(X2, Y2, X3, Y3)) * 
                    (triangleHalfPerimeter - GetSegmentLength(X3, Y3, X1, Y1)));
        }

        public double GetHeight() => Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);

        public double GetPerimeter() => GetSegmentLength(X1, Y1, X2, Y2) + 
            GetSegmentLength(X2, Y2, X3, Y3) + GetSegmentLength(X3, Y3, X1, Y1);

        public double GetWidth() => Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);

        public override string ToString()
        {
            return string.Format("Треугольник с координатами: х1-{0}, y1-{1}, х2-{2}, y2-{3}, " +
                "х3-{4}, y3-{5},", X1, Y1, X2, Y2, X3, Y3);
        }

        private static bool IsDoubleEquals(double arg1, double arg2) => Math.Abs(arg1 - arg2) <= Epsilon;

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

            Triangle Triangle = (Triangle)Obj;

            return IsDoubleEquals(Triangle.X1, X1)  && IsDoubleEquals(Triangle.Y1, Y1) 
                && IsDoubleEquals(Triangle.X2, X2) && IsDoubleEquals(Triangle.Y2, Y2) &&
                IsDoubleEquals(Triangle.X3, X3) && IsDoubleEquals(Triangle.Y3, Y3);
        }

        public override int GetHashCode()
        {
            var Prime = 37;
            var Hash = 1;

            Hash = Prime * Hash + X1.GetHashCode();
            Hash = Prime * Hash + Y1.GetHashCode();
            Hash = Prime * Hash + X2.GetHashCode();
            Hash = Prime * Hash + Y2.GetHashCode();
            Hash = Prime * Hash + X3.GetHashCode();

            return Prime * Hash + Y3.GetHashCode();
        }
    }
}