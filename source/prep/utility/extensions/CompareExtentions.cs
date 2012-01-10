using System;
using prep.utility.filtering.core;

namespace prep.utility.extensions
{
    public static class CompareExtentions
    {
        public static IGenericComparer<ItemToSort,PropertyType> descending<ItemToSort,PropertyType> (this IGenericComparer<ItemToSort,PropertyType> comparer) where PropertyType : IComparable<PropertyType>
        {
            return new DescendingComparer<ItemToSort, PropertyType>(comparer.accessor);
        }
    }
}