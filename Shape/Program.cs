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
            var Shapes = new Shapes.IShape[]{ new Shapes.Circle(4), 
                new Shapes.Triangle(2,3,-4, 5, -4, 8), 
                new Shapes.Rectangle(3, 5), 
                new Shapes.Circle(6), 
                new Shapes.Square(6), 
                new Shapes.Circle(5),
                new Shapes.Triangle(4, 5,3,8,6,3),
                new Shapes.Square(2), 
                new Shapes.Circle(10) };

            PrintShapeWithMaxArea(Shapes);
            PrintShapeWithSecondLargestPerimeter(Shapes);

            var Triangle1 = new Shapes.Triangle(2, 8, 4, 3, 2, 1);
            var Triangle2 = new Shapes.Triangle(4, 3, 4, 3, 2, 1);
            var Triangle3 = new Shapes.Triangle(2, 8, 4, 3, 2, 1);

            Console.WriteLine("Проверка на равенство HashCode треугольников: {0}", 
                Triangle1.GetHashCode() == Triangle2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals треугольников: {0}", 
                Triangle1.Equals(Triangle2));
            Console.WriteLine("Проверка на равенство HashCode треугольников: {0}", 
                Triangle1.GetHashCode() == Triangle3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals треугольников: {0}", 
                Triangle1.Equals(Triangle3));

            var Cirle1 = new Shapes.Circle(8);
            var Cirle2 = new Shapes.Circle(7);
            var Cirle3 = new Shapes.Circle(8);

            Console.WriteLine("Проверка на равенство HashCode окружностей: {0}", Cirle1.GetHashCode() == Cirle2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals окружностей: {0}", Cirle1.Equals(Cirle2));
            Console.WriteLine("Проверка на равенство HashCode окружностей: {0}", Cirle1.GetHashCode() == Cirle3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals окружностей: {0}", Cirle1.Equals(Cirle3));

            var Rectangle1 = new Shapes.Rectangle(2, 8);
            var Rectangle2 = new Shapes.Rectangle(4, 8);
            var Rectangle3 = new Shapes.Rectangle(2, 8);

            Console.WriteLine("Проверка на равенство HashCode прямоугольников: {0}", 
                Rectangle1.GetHashCode() == Rectangle2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals прямоугольников: {0}", 
                Rectangle1.Equals(Rectangle2));
            Console.WriteLine("Проверка на равенство HashCode прямоугольников: {0}", 
                Rectangle1.GetHashCode() == Rectangle3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals прямоугольников: {0}", 
                Rectangle1.Equals(Rectangle3));

            var Square1 = new Shapes.Square(2);
            var Square2 = new Shapes.Square(3);
            var Square3 = new Shapes.Square(2);

            Console.WriteLine("Проверка на равенство HashCode квадратов: {0}", 
                Square1.GetHashCode() == Square2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals квадратов: {0}", 
                Square1.Equals(Square2));
            Console.WriteLine("Проверка на равенство HashCode квадратов: {0}", 
                Square1.GetHashCode() == Square3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals квадратов: {0}", 
                Square1.Equals(Square3));
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

            Console.WriteLine("Фигура со вторым по величине периметром - {0}, периметр {1:f2}", 
                Shapes[SecondElementAroundPerimeter], Shapes[SecondElementAroundPerimeter].GetPerimeter());
        }
    }
}