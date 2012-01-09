using System;
using prep.ranges;

namespace prep.utility
{
  public static class FilteringExtensions
  {
    public static IMatchAn<ItemToFind> equal_to<ItemToFind,PropertyType>(this FilteringExtensionPoint<ItemToFind,PropertyType> extension_point,PropertyType value)
    {
      return equal_to_any(extension_point,value);
    }

    public static IMatchAn<ItemToFind> equal_to_any<ItemToFind,PropertyType>(this FilteringExtensionPoint<ItemToFind,PropertyType> extension_point,params PropertyType[] values)
    {
      return create_using(extension_point,new IsEqualToAny<PropertyType>(values));
    }

    public static IMatchAn<ItemToFind> create_using<ItemToFind,PropertyType>(this FilteringExtensionPoint<ItemToFind,PropertyType> extension_point,IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFind, PropertyType>(extension_point.accessor, criteria);
    }

    public static IMatchAn<ItemToFind> falls_in<ItemToFind,PropertyType>(this FilteringExtensionPoint<ItemToFind,PropertyType> extension_point,Range<PropertyType> range ) where PropertyType : IComparable<PropertyType>
    {
      return
        create_using(extension_point,
          new FallsInRange<PropertyType>(range));
    }

  }
}
