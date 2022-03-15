using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class Program
    {
        static void Main()
        {
            Shapes.IShape[] Shapes = { new Shapes.Circle(4), new Shapes.Triangle(2,3,-4, 5, -4, 8), new Shapes.Rectangle(3, 5),
                new Shapes.Circle(6), new Shapes.Square(6), new Shapes.Circle(5),new Shapes.Triangle(4, 5,3,8,6,3),
                new Shapes.Square(2), new Shapes.Circle(10) };

            PrintShapeWithMaxArea(Shapes);
            PrintShapeWithSecondLargestPerimeter(Shapes);
        }

        public static void PrintShapeWithMaxArea (Shapes.IShape[] Shapes)
        {
            Array.Sort(Shapes, new AreaComparator());

            var MaxElement = Shapes.Length - 1;

            Console.WriteLine("Фигура с максимальной площадью - {0}, площадь {1:f2}", Shapes[MaxElement] ,Shapes[MaxElement].GetArea());
        }

        public static void PrintShapeWithSecondLargestPerimeter(Shapes.IShape[] Shapes)
        {
            Array.Sort(Shapes, new PerimeterComparator());
            var SecondElementAroundPerimeter = Shapes.Length - 2;

            Console.WriteLine("Фигура со вторым по величине периметром - {0}, периметр {1:f2}", Shapes[SecondElementAroundPerimeter], Shapes[SecondElementAroundPerimeter].GetPerimeter());
        }
    }
}