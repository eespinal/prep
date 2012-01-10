using System;
using System.Collections.Generic;
using prep.utility.filtering.core;
using prep.utility.filtering.extension_points;
using prep.utility.sorting;

namespace prep.utility.extensions
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

        public static EnumerableFilteringExtensionPoint<ItemToFilter, PropertyType> where<ItemToFilter, PropertyType>(this IEnumerable<ItemToFilter> items,
                                                                                                                      PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
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

      public static List<T> to_list<T>(this IEnumerable<T> items)
        {
            var list = new List<T>();
            list.AddRange(items);
            return list;
        }

        public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            var list = items.to_list();
            list.Sort(comparer);
            return list.one_at_a_time();
        }

        public static EnumerableComparedCollection<T> order_by_descending<T, PropertyType>(this IEnumerable<T> items, PropertyAccessor<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
          return new EnumerableComparedCollection<T>(items, new ComparerBuilder<T>(Sort<T>.by(accessor).descending()));
        }

        public static EnumerableComparedCollection<T> order_by<T, PropertyType>(this IEnumerable<T> items, PropertyAccessor<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
          return new EnumerableComparedCollection<T>(items, new ComparerBuilder<T>(Sort<T>.by(accessor)));
        }

        public static EnumerableComparedCollection<T> order_by<T, PropertyType>(this IEnumerable<T> items, PropertyAccessor<T, PropertyType> accessor, params PropertyType[] values)
        {
          return new EnumerableComparedCollection<T>(items, new ComparerBuilder<T>(Sort<T>.by(accessor, values)));
        }
    }
}