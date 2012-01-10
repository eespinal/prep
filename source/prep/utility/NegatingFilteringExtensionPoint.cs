namespace prep.utility
{
  public class NegatingFilteringExtensionPoint<ItemToFind,PropertyType> : IProvideAccessToFiltering<ItemToFind,PropertyType,IMatchAn<ItemToFind>>
  {
    IProvideAccessToFiltering<ItemToFind, PropertyType,IMatchAn<ItemToFind>> original;

    public NegatingFilteringExtensionPoint(IProvideAccessToFiltering<ItemToFind, PropertyType,IMatchAn<ItemToFind>> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFind> apply_criteria(IMatchAn<PropertyType> criteria)
    {
      return original.apply_criteria(criteria).not();
    }
  }
}