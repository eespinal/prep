namespace prep.utility
{
  public class FilteringExtensionPoint<ItemToFilter,PropertyType>
  {
    public PropertyAccessor<ItemToFilter, PropertyType> accessor { get; private set; }

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}