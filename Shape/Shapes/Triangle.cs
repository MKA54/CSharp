using System;

namespace Shape.Shapes
{
    internal class Triangle : IShape
    {
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        private double X1
        {
            get;
        }

        private double Y1
        {
            get;
        }

        private double X2
        {
            get;
        }

        private double Y2
        {
            get;
        }

        private double X3
        {
            get;
        }

        private double Y3
        {
            get;
        }

        private static double GetSegmentLength (double x1, double y1, double x2, double y2) =>
            Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

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
            return $"Треугольник с координатами: х1-{X1}, y1-{Y1}, х2-{X2}, y2-{Y2}, " +
                $"х3-{X3}, y3-{Y3}";
        }

        private static bool IsDoubleEquals(double arg1, double arg2) => Math.Abs(arg1 - arg2) <= Constants.Epsilon;

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

            var triangle = (Triangle)obj;

            return IsDoubleEquals(triangle.X1, X1) && IsDoubleEquals(triangle.Y1, Y1)
                && IsDoubleEquals(triangle.X2, X2) && IsDoubleEquals(triangle.Y2, Y2) &&
                IsDoubleEquals(triangle.X3, X3) && IsDoubleEquals(triangle.Y3, Y3);
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            var hash = prime * X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();

            return prime * hash + Y3.GetHashCode();
        }
    }
}