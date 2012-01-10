using System;
using System.Collections.Generic;

namespace prep.utility.filtering.core
{
    public class Sort<ItemToSort>
    {
        public static IGenericComparer<ItemToSort, PropertyType> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new AscendingComparer<ItemToSort, PropertyType>(accessor);
        }
    }

    public interface IGenericComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToSort, PropertyType> accessor { get; }
    }

    public class AscendingComparer<ItemToSort, PropertyType> : IGenericComparer<ItemToSort, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToSort, PropertyType> _accessor;
        public PropertyAccessor<ItemToSort, PropertyType> accessor { get { return _accessor; } }

        public AscendingComparer(PropertyAccessor<ItemToSort, PropertyType> accessor)
        {
            this._accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }

    public class DescendingComparer<ItemToSort, PropertyType> : IGenericComparer<ItemToSort, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToSort, PropertyType> _accessor;
        public PropertyAccessor<ItemToSort, PropertyType> accessor { get { return _accessor; } }


        public DescendingComparer(PropertyAccessor<ItemToSort, PropertyType> accessor)
        {
            _accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return accessor(y).CompareTo(accessor(x));
        }
    }
}