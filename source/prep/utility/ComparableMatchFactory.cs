using System;
using prep.ranges;

namespace prep.utility
{
  public class ComparableMatchFactory<ItemToFind, PropertyType>  : ICreateMatchers<ItemToFind,PropertyType> where PropertyType : IComparable<PropertyType>
  {
    ICreateMatchers<ItemToFind, PropertyType> factory;
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor,
                                  ICreateMatchers<ItemToFind, PropertyType> original)
    {
      this.accessor = accessor;
      factory = original;
    }

    public IMatchAn<ItemToFind> equal_to(PropertyType value)
    {
      return factory.equal_to(value);
    }

    public IMatchAn<ItemToFind> create_using(IMatchAn<PropertyType> criteria)
    {
      return factory.create_using(criteria);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      return factory.equal_to_any(values);
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      return factory.not_equal_to(value);
    }

    public IMatchAn<ItemToFind> between(PropertyType start, PropertyType end)
    {
        return create_using(new FallsInRange<PropertyType>(RangeFrom<PropertyType>.beginning_in(start).inclusive().up_to(end).inclusive()));
    }

    public IMatchAn<ItemToFind> greater_than(PropertyType value)
    {
      return create_using(new FallsInRange<PropertyType>(RangeFrom<PropertyType>.beginning_in(value)));
    }
    
    public IMatchAn<ItemToFind> less_than(PropertyType value)
    {
      return create_using(new FallsInRange<PropertyType>(RangeFrom<PropertyType>.beginning_in(value).with_no_lower_bound().inclusive()));
    }

    public IMatchAn<ItemToFind> create_using(Condition<ItemToFind> criteria)
    {
      return factory.create_using(criteria);
    }
  }
}