namespace prep.utility.filtering.core
{
  public interface IProvideAccessToFiltering<ItemToFilter, PropertyType, out ReturnType>
  {
    ReturnType apply_criteria(IMatchAn<PropertyType> criteria);
  }
}