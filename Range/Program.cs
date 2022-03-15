using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    internal class Program
    {
        static void Main()
        {
            var range = new Range(3, 9);

            Console.WriteLine("Длина диапазона: " + range.GetLength);
            Console.WriteLine("Наличие числа в диапазоне: " + range.IsInside(2));
            Console.WriteLine("Наличие числа в диапазоне: " + range.IsInside(7));

            var intersection = range.GetIntersection(new Range(3, 8));
            Console.WriteLine("Пересечение диапазонов:" + intersection);

            Range[] union = range.GetUnion(new Range(1, 4));
            Console.WriteLine("Объединение диапазонов:");
            foreach (Range r in union)
            {
                Console.WriteLine(r.ToString());
            }

            Range[] difference = range.GetDifference(new Range(4, 6));
            Console.WriteLine("Разность 2 интервалов: ");
            foreach (Range r in difference)
            {
                Console.WriteLine(r.ToString()) ;
            }
        }
    }
}