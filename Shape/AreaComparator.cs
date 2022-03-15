using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class AreaComparator : IComparer<Shapes.IShape>
    {
        public int Compare(Shapes.IShape S1, Shapes.IShape S2)
        {
            if (S1 is null || S2 is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }

            if ((S1.GetArea() - S2.GetArea()) > double.Epsilon)
            {
                return 1;
            }
            else if ((S2.GetArea()) - S1.GetArea() > double.Epsilon)
            {
                return -1;
            }
            else return 0;
        }
    }
}