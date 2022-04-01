using System;

namespace Vector
{
    internal class Program
    {
        private static void Main()
        {
            var vector1 = new Vector(4);
            Console.WriteLine($"Конструктор Vector(n): {vector1}");

            var coordinates = new double[] {3, 5, 3, 5, 2, 1, 6};

            Console.WriteLine($"Размер вектора: {vector1.Size}");

            var vector2 = new Vector(coordinates);
            Console.WriteLine($"Конструктор Vector(double[]): {vector2}");

            var vector3 = new Vector(vector2);
            Console.WriteLine($"Конструктор Vector(Vector): {vector3}");

            var vector4 = new Vector(10, coordinates);
            Console.WriteLine($"Конструктор Vector(n, double[]): {vector4}");

            vector2.Add(vector4);
            Console.WriteLine($"Вектор после сложения: {vector2}");

            var vector5 = new Vector(new double[]
            {
                4, 5, 3, 9, 0, -4, 5, 8, 9, 12, 33, 12
            });

            vector2.Subtract(vector5);
            Console.WriteLine($"Вектор после вычитания: {vector2}");

            vector2.MultiplyByScalar(2);
            Console.WriteLine($"Вектор после умножения на скаляр: {vector2}");

            vector2.Reverse();
            Console.WriteLine($"Вектор после разворота: {vector2}");

            Console.WriteLine("Длина вектора: {0:f2}", vector2.Length());

            const int index = 3;
            Console.WriteLine($"Координата вектора {vector2[index]}, по индексу {index}");

            vector2[index] = 33;
            Console.WriteLine($"Координата вектора {vector2[index]}, по индексу {index}");

            var vector6 = new Vector(new double[]
            {
                5, 0, -4, 3, 6, 9
            });

            var vector7 = new Vector(new double[]
            {
                5, 0, -4, 3, 6, 9, 10
            });

            var vector8 = new Vector(new double[]
            {
                5, 0, 2, 3, 6, 9
            });

            var vector9 = new Vector(new double[]
            {
                5, 0, -4, 3, 6, 9
            });

            var vector10 = new Vector(new double[]
            {
                5, 0, 2, 3, 6, 9
            });

            Console.WriteLine();
            Console.WriteLine("Сравнение векторов по HachCode: {0}",
                vector6.GetHashCode() == vector7.GetHashCode());
            Console.WriteLine("Сравнение векторов по HachCode: {0}",
                vector6.GetHashCode() == vector8.GetHashCode());
            Console.WriteLine("Сравнение векторов по HachCode: {0}",
                vector6.GetHashCode() == vector9.GetHashCode());
            Console.WriteLine("Сравнение векторов по HachCode: {0}",
                vector6.GetHashCode() == vector10.GetHashCode());

            Console.WriteLine();
            Console.WriteLine($"Сравнение векторов по Equals: {vector6.Equals(vector7)}");
            Console.WriteLine($"Сравнение векторов по Equals: {vector6.Equals(vector8)}");
            Console.WriteLine($"Сравнение векторов по Equals: {vector6.Equals(vector9)}");
            Console.WriteLine($"Сравнение векторов по Equals: {vector6.Equals(vector10)}");
            Console.WriteLine();

            var vector11 = Vector.Add(vector7, vector8);
            Console.WriteLine($"Сумма векторов: {vector11}");

            var vector12 = Vector.Substrate(vector11, vector7);
            Console.WriteLine($"Разница векторов: {vector12}");

            var scalarProduct = Vector.GetScalarProduct(vector11, vector8);
            Console.WriteLine($"Скалярный продукт векторов: {scalarProduct}");
        }
    }
}