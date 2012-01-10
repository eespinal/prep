using System;
using System.Collections.Generic;
using prep.utility.extensions;

namespace prep.utility.sorting
{
  public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
  {
      IComparer<ItemToSort> comparer;

      public ComparerBuilder(IComparer<ItemToSort> comparer)
      {
          this.comparer = comparer;
      }

      public int Compare(ItemToSort x, ItemToSort y)
      {
          return comparer.Compare(x, y);
      }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor,params PropertyType[] values)
    {
        comparer = comparer.combined_with(Sort<ItemToSort>.by(accessor, values));
        return this;
    }
    public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
        comparer = comparer.combined_with(Sort<ItemToSort>.by_descending(accessor));
        return this;
    }
    public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
        comparer = comparer.combined_with(Sort<ItemToSort>.by(accessor));
        return this;
    }
  }
}