using System;

namespace Shape.Shapes
{
    internal class Rectangle : IShape
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Width
        {
            get;
        }

        public double Height
        {
            get;
        }

        public double GetArea() => Width * Height;

        public double GetHeight() => Height;

        public double GetPerimeter()
        {
            return (Width + Height) * 2;
        }

        public double GetWidth() => Width;

        public override string ToString()
        {
            return $"Прямоугольник с размерами: ширина-{Width}, длина-{Height}";
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

            var rectangle = (Rectangle)obj;

            return IsDoubleEquals(rectangle.Width, Width) && IsDoubleEquals(rectangle.Height, Height);
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            var hash = prime * Width.GetHashCode();

            return prime * hash + Height.GetHashCode();
        }
    }
}