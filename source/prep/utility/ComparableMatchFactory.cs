using System;

namespace prep.utility
{
  public class ComparableMatchFactory<ItemToFind, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> greater_than(PropertyType value)
    {
      return new LambdaMatcher<ItemToFind>(x => accessor(x).CompareTo(value) > 0);
    }
  }
}