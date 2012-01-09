using System;

namespace prep.ranges
{
  public class InclusiveRange<T> : Range<T> where T : IComparable<T>
  {
    public InclusiveRange(T start, T end)
    {
      this.start = start;
      this.end = end;
    }

    T start;
    T end;

    public bool contains(T item)
    {
      return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
    }
  }
}