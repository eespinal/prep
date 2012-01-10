using System;
using System.Collections;
using System.Collections.Generic;
using prep.utility.sorting;

namespace prep.utility.extensions
{
  public class EnumerableComparedCollection<T> : IComparerBuilder<T,IEnumerable<T>>,IEnumerable<T>
  {
    readonly IEnumerable<T> items;
    readonly ComparerBuilder<T> builder;

    public EnumerableComparedCollection(IEnumerable<T> items, ComparerBuilder<T> builder)
    {
      this.items = items;
      this.builder = builder;
    }

    public IEnumerable<T> then_by<PropertyType>(PropertyAccessor<T, PropertyType> accessor, params PropertyType[] values)
    {
      return items.sort_using(builder.then_by(accessor, values));
    }

    public IEnumerable<T> then_by_descending<PropertyType>(PropertyAccessor<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return items.sort_using(builder.then_by_descending(accessor));
    }

    public IEnumerable<T> then_by<PropertyType>(PropertyAccessor<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return items.sort_using(builder.then_by(accessor));
    }

    public IEnumerator<T> GetEnumerator()
    {
      var itemList = items.to_list();
      itemList.Sort(builder.Compare);
      foreach (var item in itemList)
      {
        yield return item;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}