﻿using System;

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
            return string.Format($"Прямоугольник с размерами: ширина-{Width}, длина-{Height}");
        }

        private static bool IsDoubleEquals(double arg1, double arg2) => Math.Abs(arg1 - arg2) <= Constans.Epsilon;

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

            var rectangle = (Rectangle)obj;

            return IsDoubleEquals(rectangle.Width, Width) && IsDoubleEquals(rectangle.Height, Height);
        }

        public override int GetHashCode()
        {
            var prime = 37;
            var hash = 1;

            hash = prime * hash + Width.GetHashCode();

            return prime * hash + Height.GetHashCode();
        }
    }
}