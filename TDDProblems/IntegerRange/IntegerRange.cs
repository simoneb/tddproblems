using System;

namespace TDDProblems.IntegerRange
{
    internal struct IntegerRange
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public IntegerRange(int min, int max) : this()
        {
            Min = min;
            Max = max;
        }

        public bool IsInRange(int i)
        {
            return Min <= i && i <= Max;
        }

        public IntegerRange Intersect(IntegerRange range)
        {
            var intersect = new IntegerRange(Math.Max(Min, range.Min), Math.Min(Max, range.Max));

            if(intersect.Min > intersect.Max)
                throw new InvalidOperationException("Rages do not intersect");

            return intersect;
        }
    }
}