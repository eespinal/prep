namespace prep.utility
{
  public class NegatingFilteringExtensionPoint<ItemToFind,PropertyType> : IProvideAccessToFiltering<ItemToFind,PropertyType>
  {
    IProvideAccessToFiltering<ItemToFind, PropertyType> original;

    public NegatingFilteringExtensionPoint(IProvideAccessToFiltering<ItemToFind, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFind> create_matcher(IMatchAn<PropertyType> criteria)
    {
      return original.create_matcher(criteria).not();
    }
  }
}