﻿using System;

namespace prep.ranges
{
  public interface Range<T> where T : IComparable<T>
  {
    bool contains(T item);
  }
}