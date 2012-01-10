namespace prep.utility
{
  public interface IProvideAccessToFiltering<ItemToFilter, PropertyType, out ReturnType>
  {
    ReturnType apply_criteria(IMatchAn<PropertyType> criteria);
  }
}