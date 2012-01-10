namespace prep.utility
{
  public interface IProvideAccessToFiltering<ItemToFilter, PropertyType>
  {
    IMatchAn<ItemToFilter> create_matcher(IMatchAn<PropertyType> criteria);
  }
}