using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class Program
    {
        static void Main()
        {
            var Vector1 = new Vector(4);
            Console.WriteLine("Конструктор Vector(n): " + Vector1);

            var Coordinates = new double[] {3, 5, 3, 5, 2, 1, 6};

            var Vector2 = new Vector(Coordinates);
            Console.WriteLine("Конструктор Vector(double[]): " + Vector2);

            var Vector3 = new Vector(Vector2);
            Console.WriteLine("Конструктор Vector(Vector): " + Vector3);

            var Vector4 = new Vector(10, Coordinates);
            Console.WriteLine("Конструктор Vector(n, double[]): " + Vector4);

            Vector2.Add(Vector4);
            Console.WriteLine("Вектор после сложения: " + Vector2);

            var Vector5 = new Vector(new double[]
            {
                4, 5, 3, 9 , 0, -4, 5, 8, 9, 12, 33, 12
            });

            Vector2.Subtract(Vector5);
            Console.WriteLine("Вектор после вычитания: " + Vector2);

            Vector2.MultiplyByScalar(2);
            Console.WriteLine("Вектор после умножения на скаляр: " + Vector2);

            Vector2.Reverse();
            Console.WriteLine("Вектор после разворота: " + Vector2);

            Console.WriteLine("Длина вектора: " + Vector2.GetLength());

            var Index = 3;
            Console.WriteLine("Координата вектора {0}, по индексу {1}", 
                Vector2.GetCoordinateByIndex(Index), Index);

            Vector2.SetCoordinateByIndex(Index, 33);
            Console.WriteLine("Координата вектора {0}, по индексу {1}", 
                Vector2.GetCoordinateByIndex(Index), Index);

            var Vector6 = new Vector(new double[]
            {
                5, 0, -4, 3, 6, 9
            });

            var Vector7 = new Vector(new double[]
            {
                5, 0, -4, 3, 6, 9, 10
            });

            var Vector8 = new Vector(new double[]
            {
                5, 0, 2, 3, 6, 9
            });
            
            var Vector9 = new Vector(new double[]
            {
                5, 0, -4, 3, 6, 9
            });

            var Vector10 = new Vector(new double[]
            {
                5, 0, 2, 3, 6, 9
            });

            Console.WriteLine();
            Console.WriteLine("Сравнение векторов по HachCode: {0}", 
                Vector6.GetHashCode() == Vector7.GetHashCode());
            Console.WriteLine("Сравнение векторов по HachCode: {0}", 
                Vector6.GetHashCode() == Vector8.GetHashCode());
            Console.WriteLine("Сравнение векторов по HachCode: {0}", 
                Vector6.GetHashCode() == Vector9.GetHashCode());
            Console.WriteLine("Сравнение векторов по HachCode: {0}", 
                Vector6.GetHashCode() == Vector10.GetHashCode());

            Console.WriteLine();
            Console.WriteLine("Сравнение векторов по Equals: {0}", Vector6.Equals(Vector7));
            Console.WriteLine("Сравнение векторов по Equals: {0}", Vector6.Equals(Vector8));
            Console.WriteLine("Сравнение векторов по Equals: {0}", Vector6.Equals(Vector9));
            Console.WriteLine("Сравнение векторов по Equals: {0}", Vector6.Equals(Vector10));
            Console.WriteLine();

            var Vector11 = Vector.GetSum(Vector7,Vector8);
            Console.WriteLine("Сумма векторов: " + Vector11);

            var Vector12 = Vector.GetDifference(Vector11, Vector7);
            Console.WriteLine("Разница векторов: " + Vector12);

            var ScalarProduct = Vector.GetScalarProduct(Vector11, Vector8);
            Console.WriteLine("Скалярный продукт векторов: " + ScalarProduct);
        }
    }
}