using System;

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
      return new LambdaMatcher<ItemToFind>(x => accessor(x).Equals(value));
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      throw new NotImplementedException();
    }
  }
}