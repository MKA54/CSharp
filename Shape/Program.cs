using System;
using Shape.Shapes;

namespace Shape
{
    internal class Program
    {
        static void Main()
        {
            var shapes = new IShape[]{ new Circle(4),
                new Triangle(2,3,-4, 5, -4, 8),
                new Rectangle(3, 5),
                new Circle(6),
                new Square(6),
                new Circle(5),
                new Triangle(4, 5,3,8,6,3),
                new Square(2),
                new Circle(10) };

            PrintShapeWithMaxArea(shapes);
            PrintShapeWithSecondLargestPerimeter(shapes);

            var triangle1 = new Triangle(2, 8, 4, 3, 2, 1);
            var triangle2 = new Triangle(4, 3, 4, 3, 2, 1);
            var triangle3 = new Triangle(2, 8, 4, 3, 2, 1);

            Console.WriteLine("Проверка на равенство HashCode треугольников: {0}",
                triangle1.GetHashCode() == triangle2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals треугольников: {0}",
                triangle1.Equals(triangle2));
            Console.WriteLine("Проверка на равенство HashCode треугольников: {0}",
                triangle1.GetHashCode() == triangle3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals треугольников: {0}",
                triangle1.Equals(triangle3));

            var cirle1 = new Circle(8);
            var cirle2 = new Circle(7);
            var cirle3 = new Circle(8);

            Console.WriteLine("Проверка на равенство HashCode окружностей: {0}",
                cirle1.GetHashCode() == cirle2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals окружностей: {0}", cirle1.Equals(cirle2));
            Console.WriteLine("Проверка на равенство HashCode окружностей: {0}",
                cirle1.GetHashCode() == cirle3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals окружностей: {0}", cirle1.Equals(cirle3));

            var rectangle1 = new Rectangle(2, 8);
            var rectangle2 = new Rectangle(4, 8);
            var rectangle3 = new Rectangle(2, 8);

            Console.WriteLine("Проверка на равенство HashCode прямоугольников: {0}",
                rectangle1.GetHashCode() == rectangle2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals прямоугольников: {0}",
                rectangle1.Equals(rectangle2));
            Console.WriteLine("Проверка на равенство HashCode прямоугольников: {0}",
                rectangle1.GetHashCode() == rectangle3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals прямоугольников: {0}",
                rectangle1.Equals(rectangle3));

            var square1 = new Square(2);
            var square2 = new Square(3);
            var square3 = new Square(2);

            Console.WriteLine("Проверка на равенство HashCode квадратов: {0}",
                square1.GetHashCode() == square2.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals квадратов: {0}",
                square1.Equals(square2));
            Console.WriteLine("Проверка на равенство HashCode квадратов: {0}",
                square1.GetHashCode() == square3.GetHashCode());
            Console.WriteLine("Проверка на равенство Equals квадратов: {0}",
                square1.Equals(square3));
        }

        public static void PrintShapeWithMaxArea(IShape[] shapes)
        {
            Array.Sort(shapes, new AreaComparator());

            var maxElement = shapes.Length - 1;

            Console.WriteLine("Фигура с максимальной площадью - {0}, площадь {1:f2}",
                shapes[maxElement], shapes[maxElement].GetArea());
        }

        public static void PrintShapeWithSecondLargestPerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new PerimeterComparator());
            var SecondElementAroundPerimeter = shapes.Length - 2;

            Console.WriteLine("Фигура со вторым по величине периметром - {0}, периметр {1:f2}",
                shapes[SecondElementAroundPerimeter], shapes[SecondElementAroundPerimeter].GetPerimeter());
        }
    }
}