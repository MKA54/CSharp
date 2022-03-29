using System;

namespace Range
{
    internal class Program
    {
        private static void Main()
        {
            var range = new Range(3, 9);

            Console.WriteLine($"Длина диапазона: {range.Length}");
            Console.WriteLine($"Наличие числа в диапазоне: {range.IsInside(2)}");
            Console.WriteLine($"Наличие числа в диапазоне: {range.IsInside(7)}");

            var intersection = range.GetIntersection(new Range(3, 8));
            Console.WriteLine($"Пересечение диапазонов: {intersection}");

            var union = range.GetUnion(new Range(1, 4));
            Console.WriteLine("Объединение диапазонов:");
            foreach (var r in union)
            {
                Console.WriteLine(r.ToString());
            }

            var difference = range.GetDifference(new Range(4, 6));
            Console.WriteLine("Разность 2 интервалов:");
            foreach (var r in difference)
            {
                Console.WriteLine(r.ToString());
            }
        }
    }
}