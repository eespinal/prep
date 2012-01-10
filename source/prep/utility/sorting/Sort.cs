using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class Sort<ItemToSort>
  {
    public static ComparerBuilder<ItemToSort> by<PropertyType>(
      PropertyAccessor<ItemToSort, PropertyType> accessor, params PropertyType[] values)
    {
        return create_using(accessor, new FixedComparer<PropertyType>(values));
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(
      PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
        return create_using(accessor,new ComparableComparer<PropertyType>());
    }

      static ComparerBuilder<ItemToSort> create_using<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor, IComparer<PropertyType> comparer) 
      {
          return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor, comparer));
      }

    public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(
      PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
        return create_using(accessor,new ReverseComparer<PropertyType>(new ComparableComparer<PropertyType>()));
    }
  }
}