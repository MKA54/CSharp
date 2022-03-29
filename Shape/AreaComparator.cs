using System;
using System.Collections.Generic;
using Shape.Shapes;

namespace Shape
{
    internal class AreaComparator : IComparer<IShape>
    {
        public int Compare(IShape s1, IShape s2)
        {
            if (s1 is null || s2 is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }

            if (s1.GetArea() - s2.GetArea() > Constants.Epsilon)
            {
                return 1;
            }

            if (s2.GetArea() - s1.GetArea() > Constants.Epsilon)
            {
                return -1;
            }

            return 0;
        }
    }
}