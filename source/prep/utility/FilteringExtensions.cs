using System;
using prep.ranges;

namespace prep.utility
{
  public static class FilteringExtensions
  {
    public static ReturnType equal_to<ItemToFind,PropertyType,ReturnType>(this IProvideAccessToFiltering<ItemToFind,PropertyType,ReturnType> extension_point,PropertyType value)
    {
      return equal_to_any(extension_point,value);
    }

    public static ReturnType equal_to_any<ItemToFind,PropertyType,ReturnType>(this IProvideAccessToFiltering<ItemToFind,PropertyType,ReturnType> extension_point,params PropertyType[] values)
    {
      return create_using(extension_point,new IsEqualToAny<PropertyType>(values));
    }

    public static ReturnType create_using<ItemToFind,PropertyType,ReturnType>(this IProvideAccessToFiltering<ItemToFind,PropertyType,ReturnType> extension_point,IMatchAn<PropertyType> criteria)
    {
        return extension_point.apply_criteria(criteria);
    }

      public static ReturnType that_falls_in<ItemToFind,PropertyType,ReturnType>(this IProvideAccessToFiltering<ItemToFind,PropertyType,ReturnType> extension_point,Range<PropertyType> range ) where PropertyType : IComparable<PropertyType>
    {
      return
        create_using(extension_point,
          new FallsInRange<PropertyType>(range));
    }


  }
}
