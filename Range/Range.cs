using System;

namespace Range
{
    internal class Range
    {
        public Range(double from, double to)
        {
            From = Math.Min(from, to);
            To = Math.Max(from, to);
        }

        private double From
        {
            get;
        }

        private double To
        {
            get;
        }

        public double Length => Math.Abs(To - From);

        private static bool IsDoubleEquals(double arg1, double arg2) => Math.Abs(arg1 - arg2) <= Constants.Epsilon;
        private static bool IsFirstDoubleMore(double arg1, double arg2) => arg1 - arg2 > Constants.Epsilon;

        public bool IsInside(double point) => IsFirstDoubleMore(point, From) && IsFirstDoubleMore(To, point)
            || IsDoubleEquals(From, point) || IsDoubleEquals(To, point);

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
                return new[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (IsFirstDoubleMore(range.From, From) && IsFirstDoubleMore(To, range.To))
            {
                return new[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (IsFirstDoubleMore(range.From, From) && IsFirstDoubleMore(To, range.From) && 
                (IsFirstDoubleMore(range.To, To) || IsDoubleEquals(range.To, To)))
            {
                return new[] { new Range(From, range.From) };
            }

            if ((IsFirstDoubleMore(range.From, From) || IsDoubleEquals(From, range.From) 
                && IsFirstDoubleMore(To, range.To) && IsFirstDoubleMore(range.To, From)))
            {
                return new[] { new Range(range.To, To) };
            }

            if ((IsFirstDoubleMore(From, range.From) || IsDoubleEquals(From, range.From) 
                && (IsFirstDoubleMore(range.To, To) || IsDoubleEquals(range.To, To))))
            {
                return Array.Empty<Range>();
            }

            return new[] { new Range(From, To) };
        }

        public override string ToString()
        {
            return $"from: {From}, to: {To}";
        }
    }
}