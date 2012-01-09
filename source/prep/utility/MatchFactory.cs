using System;
using System.Collections.Generic;

namespace prep.utility
{
  public class MatchFactory<ItemToFind, PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      return new LambdaMatcher<ItemToFind>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      throw new NotImplementedException();
    }
  }
}