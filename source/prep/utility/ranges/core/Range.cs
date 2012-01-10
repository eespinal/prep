using System;

namespace prep.utility.ranges.core
{
  public interface Range<T> where T : IComparable<T>
  {
    bool contains(T item);
  }
}