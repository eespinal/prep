using prep.utility.filtering.core;
using prep.utility.filtering.extensions;
using prep.utility.filtering.matchers;

namespace prep.utility.filtering.extension_points
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