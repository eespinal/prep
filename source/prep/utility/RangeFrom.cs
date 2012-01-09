using System;
using prep.ranges;

namespace prep.utility
{
    public class RangeFrom<PropertyType> where PropertyType : IComparable<PropertyType>
    {
        public static ExclusiveRange<PropertyType> beginning_in(PropertyType start)
        {
            return new ExclusiveRange<PropertyType>(start);
        }
    }

    public class ExclusiveRange<PropertyType> : Range<PropertyType> where PropertyType : IComparable<PropertyType>
    {
        private readonly PropertyType _start;

        public ExclusiveRange(PropertyType start)
        {
            _start = start;
        }

        public bool contains(PropertyType item)
        {
            return item.CompareTo(_start) > 0;
        }

        public InclusiveRange<PropertyType> inclusive()
        {
            return new InclusiveRange<PropertyType>(_start);
        }

        public ExclusiveWithNoLowerBoundRange<PropertyType> with_no_lower_bound()
        {
            return new ExclusiveWithNoLowerBoundRange<PropertyType>(_start);
        }
    }

    public class ExclusiveWithNoLowerBoundRange<T> : Range<T> where T : IComparable<T>
    {
        private readonly T _start;

        public ExclusiveWithNoLowerBoundRange(T start)
        {
            _start = start;
        }

        public bool contains(T item)
        {
            return _start.CompareTo(item) > 0;
        }

        public Range<T> inclusive()
        {
            return new InclusiveRangeWithNoLowerBound<T>(this,_start);
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