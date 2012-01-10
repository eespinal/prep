using System;
using prep.utility.filtering.core;
using prep.utility.filtering.extension_points;
using prep.utility.ranges;
using prep.utility.ranges.core;

namespace prep.utility.filtering.extensions
{
  public static class DateFilteringExtensions
  {
    public static ReturnType greater_than<ItemToFind, ReturnType>(
      this IProvideAccessToFiltering<ItemToFind, DateTime, ReturnType> extension_point, int year)
    {
      return
        extension_point.create_using(Where<DateTime>.has_a(x => x.Year).that_falls_in(RangeOf<int>.greater_than(year)));
    }
  }
}