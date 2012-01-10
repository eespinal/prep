namespace prep.utility
{
  public class FilteringExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToFiltering<ItemToFilter, PropertyType,IMatchAn<ItemToFilter>>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFilter> apply_criteria(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
    }

    public IProvideAccessToFiltering<ItemToFilter, PropertyType,IMatchAn<ItemToFilter>> not
    {
      get
      {
        return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this);
      }
    }
  }
}