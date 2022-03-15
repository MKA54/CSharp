using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Triangle : IShape
    {
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
            set;
        }
        public double Y1
        {
            get;
            set;
        }
        public double X2
        {
            get;
            set;
        }
        public double Y2
        {
            get;
            set;
        }
        public double X3
        {
            get;
            set;
        }
        public double Y3
        {
            get;
            set;
        }
        private static double GetSegmentLength(double X1, double Y1, double X2, double Y2)
        {
            return Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
        }
        public double GetArea()
        {
            var triangleHalfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(triangleHalfPerimeter * (triangleHalfPerimeter - GetSegmentLength(X1, Y1, X2, Y2))
                    * (triangleHalfPerimeter - GetSegmentLength(X2, Y2, X3, Y3)) * (triangleHalfPerimeter - GetSegmentLength(X3, Y3, X1, Y1)));
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetPerimeter()
        {
            return GetSegmentLength(X1, Y1, X2, Y2) + GetSegmentLength(X2, Y2, X3, Y3) + GetSegmentLength(X3, Y3, X1, Y1);
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public override string ToString()
        {
            return string.Format("Треугольник с координатами: х1-{0}, y1-{1}, х2-{2}, y2-{3}, " +
                "х3-{4}, y3-{5},", X1, Y1, X2, Y2, X3, Y3);
        }
    }
}