using System.Collections.Generic;

namespace prep.utility
{
  public class EnumerableFilteringExtensionPoint<ItemToFilter,PropertyType> : IProvideAccessToFiltering<ItemToFilter,PropertyType,IEnumerable<ItemToFilter>>
  {
    IProvideAccessToFiltering<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>> real_condition;
    IEnumerable<ItemToFilter> items;
    bool negate;

    public EnumerableFilteringExtensionPoint(IProvideAccessToFiltering<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>> real_condition, IEnumerable<ItemToFilter> items)
    {
      this.real_condition = real_condition;
      this.items = items;
    }

    public IProvideAccessToFiltering<ItemToFilter,PropertyType,IEnumerable<ItemToFilter>> not
    {
      get
      {
        negate = true;
        return this;
      }
    }

    public IEnumerable<ItemToFilter> apply_criteria(IMatchAn<PropertyType> criteria)
    {
      var condition = real_condition.apply_criteria(criteria);
      condition = negate ? condition.not() : condition;
      return items.all_items_matching(condition);
    }
  }
}