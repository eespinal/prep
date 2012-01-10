using System;
using System.Collections.Generic;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items) yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchAn<T> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static EnumerableFilteringExtensionPoint<ItemToFilter,PropertyType> where<ItemToFilter,PropertyType>(this IEnumerable<ItemToFilter> items,PropertyAccessor<ItemToFilter,PropertyType> accessor  ){

      return new EnumerableFilteringExtensionPoint<ItemToFilter, PropertyType>(
        Where<ItemToFilter>.has_a(accessor), items);
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Condition<T> condition)
    {
      foreach (var item in items)
      {
        if (condition(item)) yield return item;
      }
    }
  }
}