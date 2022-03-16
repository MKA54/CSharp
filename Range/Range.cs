using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    internal class Range
    {
        private const double Epsilon = 1.0e-10;
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
        private static bool IsFirstDoubleMore(double arg1, double arg2) => arg1 - arg2 > Epsilon;

        public bool IsInside(double point)
        {
            return IsFirstDoubleMore(point, From) && IsFirstDoubleMore(To, point) || 
                IsDoubleEquals(From, point) ||
                IsDoubleEquals(To, point);
        }

        public Range GetIntersection(Range range)
        {
            if (IsFirstDoubleMore(range.From, To) || IsDoubleEquals(range.From, To) ||
                IsFirstDoubleMore(From, range.To) || IsDoubleEquals(From, range.To))
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }
        public Range[] GetUnion(Range range)
        {
            if (IsFirstDoubleMore(range.From, To) || IsFirstDoubleMore(From, range.To))
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (IsFirstDoubleMore(range.From, From) && IsFirstDoubleMore(To, range.To))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (IsFirstDoubleMore(range.From, From) && IsFirstDoubleMore(To, range.From) && (IsFirstDoubleMore(range.To, To) || IsDoubleEquals(range.To, To)))
            {
                return new Range[] { new Range(From, range.From) };
            }

            if ((IsFirstDoubleMore(range.From, From) || IsDoubleEquals(From, range.From) && IsFirstDoubleMore(To, range.To) && IsFirstDoubleMore(range.To, From)))
            {
                return new Range[] { new Range(range.To, To) };
            }

            if ((IsFirstDoubleMore(From, range.From) || IsDoubleEquals(From, range.From) && (IsFirstDoubleMore(range.To, To) || IsDoubleEquals(range.To, To))))
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