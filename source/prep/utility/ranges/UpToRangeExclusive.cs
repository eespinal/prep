using System;
using prep.utility.ranges.core;

namespace prep.utility.ranges
{
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
}