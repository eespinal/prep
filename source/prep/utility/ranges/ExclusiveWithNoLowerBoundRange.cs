using System;
using prep.utility.ranges.core;

namespace prep.utility.ranges
{
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
}