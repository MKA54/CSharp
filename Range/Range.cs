using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    internal class Range
    {
        public double from
        {
            get;
            set;
        }
        public double to
        {
            get;
            private set;
        }

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double getLength()
        {
            return from + to;
        }

        public bool isInside(double number)
        {
            return from <= number && to >= number;
        }
    }
}
