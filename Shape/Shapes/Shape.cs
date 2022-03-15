using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Shapes
{
    internal interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }
}