using System;
using prep.collections;

namespace prep.utility
{
  public class Where<ItemToFind>
  {
    public static AccessedProperty<ItemToFind, PropertyType> has_a<PropertyType>(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new AccessedProperty<ItemToFind, PropertyType>(accessor);
    }
  }

  public class AccessedProperty<ItemToFind, PropertyType>
  {
    private readonly PropertyAccessor<ItemToFind, PropertyType> accessor;

    public AccessedProperty(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> equal_to(PropertyType value)
    {
      return new LambdaMatcher<ItemToFind>(x => accessor(x).Equals(value));
    }
  }
}