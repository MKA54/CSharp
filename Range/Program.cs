using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Range range = new Range(3, 7);

            Console.WriteLine("Длина диапазона: " + range.getLength());
            Console.WriteLine("Наличие числа в диапазоне: " + range.isInside(2));
            Console.WriteLine("Наличие числа в диапазоне: " + range.isInside(5.5));
        }
    }
}
