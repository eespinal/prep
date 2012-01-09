using System;

namespace prep.utility
{    
  public class ComparableMatchFactory<ItemToFind, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    IMatchFactory<ItemToFind, PropertyType> factory;
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
      factory = new MatchFactory<ItemToFind, PropertyType>(accessor);
    }

    public IMatchAn<ItemToFind> greater_than(PropertyType value)
    {
      return new LambdaMatcher<ItemToFind>(x => accessor(x).CompareTo(value) > 0);
    }
    public IMatchAn<ItemToFind> equal_to(PropertyType value)
    {
        return factory.equal_to(value);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
        return factory.equal_to_any(values);
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
        return factory.not_equal_to(value);
    }
  }
}