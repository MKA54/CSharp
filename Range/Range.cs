using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    internal class Range
    {
        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }
        public double From
        {
            get;
            set;
        }
        public double To
        {
            get;
            private set;
        }
        public double GetLength
        {
            get
            {
                return To - From;
            }
        }

        public bool IsInside(double number)
        {
            return (number - From > double.Epsilon && To - number > double.Epsilon) || (Math.Abs(From - number) <= double.Epsilon) || (Math.Abs(To - number) <= double.Epsilon);
        }

        public Range GetIntersection(Range range)
        {
            if (range.From - To > double.Epsilon || Math.Abs(range.From - To) <= double.Epsilon || From - range.To > double.Epsilon || Math.Abs(From - range.To) <= double.Epsilon)
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

            if (range.From - From > double.Epsilon && To - range.From > double.Epsilon && (range.To - To > double.Epsilon || Math.Abs(range.To - To) <= double.Epsilon))
            {
                return new Range[] { new Range(From, range.From) };
            }

            if ((range.From - From> double.Epsilon || Math.Abs(From - range.From) <= double.Epsilon && To - range.To > double.Epsilon && range.To - From > double.Epsilon))
            {
                return new Range[] { new Range(range.To, To) };
            }

            if ((From - range.From > double.Epsilon || Math.Abs(From - range.From) <= double.Epsilon && (range.To - To > double.Epsilon || Math.Abs(range.To - To) <= double.Epsilon)))
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