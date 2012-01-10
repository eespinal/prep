using System;
using prep.utility.ranges.core;

namespace prep.utility.ranges
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
}