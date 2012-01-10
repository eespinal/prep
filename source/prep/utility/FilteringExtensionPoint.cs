namespace prep.utility
{
  public class FilteringExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToFiltering<ItemToFilter, PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFilter> create_matcher(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
    }

    public IProvideAccessToFiltering<ItemToFilter, PropertyType> not
    {
      get
      {
        return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this);
      }
    }
  }
}