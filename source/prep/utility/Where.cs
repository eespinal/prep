namespace prep.utility
{
  public class Where<ItemToFind>
  {
    public static FilteringExtensionPoint<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new FilteringExtensionPoint<ItemToFind, PropertyType>(accessor);
    }
  }
}