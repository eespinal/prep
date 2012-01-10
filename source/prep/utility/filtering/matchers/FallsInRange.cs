using System;
using prep.utility.filtering.core;
using prep.utility.ranges;
using prep.utility.ranges.core;

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