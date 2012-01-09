using System;
using prep.utility;

namespace prep.ranges
{
  public class InclusiveRange<T> : Range<T> where T : IComparable<T>
  {
      private readonly T _start;

      public InclusiveRange(T start)
      {
          _start = start;
      }

      public bool contains(T item)
      {
          return item.CompareTo(_start) >= 0;
      }

      public UpToRangeExclusive<T> up_to(T end)
      {
          return new UpToRangeExclusive<T>(this,end);
      }
  }

    public class UpToRangeExclusive<T> : Range<T> where T : IComparable<T>
    {
        private readonly Range<T> _range;
        private readonly T _end;

        public UpToRangeExclusive(Range<T> range, T end)
        {
            _range = range;
            _end = end;
        }

        public bool contains(T item)
        {
            return _range.contains(item) && item.CompareTo(_end) < 0;
        }

        public Range<T> inclusive()
        {
            return new UpToRangeInclusive<T>(this, _end);
        }
    }

    public class UpToRangeInclusive<T> : Range<T> where T : IComparable<T>
    {
        private readonly Range<T> _upToRangeExclusive;
        private readonly T _end;

        public UpToRangeInclusive(Range<T> upToRangeExclusive, T end)
        {
            _upToRangeExclusive = upToRangeExclusive;
            _end = end;
        }

        public bool contains(T item)
        {
            return _upToRangeExclusive.contains(item) || item.CompareTo(_end) == 0;
        }
    }
}