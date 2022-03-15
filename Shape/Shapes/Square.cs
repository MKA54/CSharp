using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal class Square : IShape
    {
        public Square(double SideLength)
        {
            this.SideLength = SideLength;
        }
        public double SideLength
        {
            get;
            set;
        }
        public double GetArea()
        {
            return SideLength * SideLength;
        }
        public double GetHeight()
        {
            return SideLength;
        }
        public double GetPerimeter()
        {
            const int SidesCount = 4;
            return SideLength * SidesCount;

        }
        public double GetWidth()
        {
            return SideLength;
        }

        public override string ToString()
        {
            return string.Format("Квадрат с длиной стороны: {0}", SideLength);
        }
    }
}