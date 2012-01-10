using System;

namespace prep.utility.ranges.core
{
    public class RangeOf<PropertyType> where PropertyType : IComparable<PropertyType>
    {
        public static RangeBuilder<PropertyType> greater_than(PropertyType start)
        {
            return new RangeBuilder<PropertyType>(start);
        }
    }

  public class InclusiveRangeWithNoLowerBound<T> : Range<T> where T : IComparable<T>
    {
        private readonly ExclusiveWithNoLowerBoundRange<T> _range;
        private readonly T _start;

        public InclusiveRangeWithNoLowerBound(ExclusiveWithNoLowerBoundRange<T> range, T start)
        {
            _range = range;
            _start = start;
            ;
        }

        public bool contains(T item)
        {
            return _range.contains(item) || _start.CompareTo(item) == 0;
        }
    }
}