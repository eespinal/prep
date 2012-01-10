using System;
using prep.utility.ranges.core;

namespace prep.utility.ranges
{
  public class RangeBuilder<PropertyType> : Range<PropertyType> where PropertyType : IComparable<PropertyType>
  {
    private readonly PropertyType _start;

    public RangeBuilder(PropertyType start)
    {
      _start = start;
    }

    public bool contains(PropertyType item)
    {
      return item.CompareTo(_start) > 0;
    }

    public InclusiveRange<PropertyType> inclusive()
    {
      return new InclusiveRange<PropertyType>(_start);
    }

    public ExclusiveWithNoLowerBoundRange<PropertyType> with_no_lower_bound()
    {
      return new ExclusiveWithNoLowerBoundRange<PropertyType>(_start);
    }
  }
}