using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
  {
    public int Compare(ItemToSort x, ItemToSort y)
    {
      throw new NotImplementedException();
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor,params PropertyType[] values)
    {
      throw new NotImplementedException();
    }
    public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor)
    {
      throw new NotImplementedException();
    }
    public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor)
    {
      throw new NotImplementedException();
    }
  }
}