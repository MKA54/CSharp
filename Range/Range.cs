using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    internal class Range
    {
        public const double Epsilon = 1.0e-10;
        public Range(double from, double to)
        {
            From = Math.Min(from, to);
            To = Math.Max(from, to);
        }

        public double From
        {
            get;
        }

        public double To
        {
            get;
        }

        public double Length => Math.Abs(To - From);

        private static bool IsDoubleEquals(double arg1, double arg2) => Math.Abs(arg1 - arg2) <= Epsilon;

        public bool IsInside(double point)
        {
            return point - From > Epsilon && To - point > Epsilon || 
                IsDoubleEquals(From, point) ||
                IsDoubleEquals(To, point);
        }

        public Range GetIntersection(Range range)
        {
            if (range.From - To > double.Epsilon || IsDoubleEquals(range.From, To) || 
                From - range.To > double.Epsilon || IsDoubleEquals(From, range.To))
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }
        public Range[] GetUnion(Range range)
        {
            if (range.From - To > double.Epsilon || From - range.To > double.Epsilon)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if ( range.From - From > double.Epsilon && To - range.To > double.Epsilon)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (range.From - From > double.Epsilon && To - range.From > double.Epsilon && (range.To - To > double.Epsilon || IsDoubleEquals(range.To, To)))
            {
                return new Range[] { new Range(From, range.From) };
            }

            if ((range.From - From> double.Epsilon || IsDoubleEquals(From, range.From) && To - range.To > double.Epsilon && range.To - From > double.Epsilon))
            {
                return new Range[] { new Range(range.To, To) };
            }

            if ((From - range.From > double.Epsilon || IsDoubleEquals(From, range.From) && (range.To - To > double.Epsilon || IsDoubleEquals(range.To, To))))
            {
                return new Range[0];
            }

            return new Range[] { new Range(From, To) };
        }

        public override string ToString()
        {
            return $"from: {From}, to: {To}";
        }
    }
}