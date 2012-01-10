using System;
using prep.utility.ranges.core;

namespace prep.utility.ranges
{
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