using System;

namespace prep.utility.sorting
{
  public class Sort<ItemToSort>
  {
    public static ComparerBuilder<ItemToSort> by<PropertyType>(
      PropertyAccessor<ItemToSort, PropertyType> accessor, params PropertyType[] values)
    {
      throw new NotImplementedException();
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(
      PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      throw new NotImplementedException();
    }
  }
}