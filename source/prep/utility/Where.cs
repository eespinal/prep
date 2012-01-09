using System;

namespace prep.utility
{
  public class Where<ItemToFind>
  {
    public static ComparableMatchFactory<ItemToFind, PropertyType> has_an<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new ComparableMatchFactory<ItemToFind, PropertyType>(accessor, has_a(accessor));
    }

    public static MatchFactory<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new MatchFactory<ItemToFind, PropertyType>(accessor);
    }
  }
}