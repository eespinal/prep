using System;
using prep.ranges;
using prep.utility.filtering.core;

namespace prep.utility.filtering.matchers
{
  public class FallsInRange<T> : IMatchAn<T> where T : IComparable<T>
  {
    Range<T> range;

    public FallsInRange(Range<T> range)
    {
      this.range = range;
    }

    public bool matches(T item)
    {
      return range.contains(item);
    }
  }
}