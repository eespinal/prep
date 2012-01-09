namespace prep.utility
{
  public interface ICreateMatchers<ItemToFind, PropertyType>
  {
    IMatchAn<ItemToFind> equal_to(PropertyType value);
    IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values);
    IMatchAn<ItemToFind> not_equal_to(PropertyType value);
    IMatchAn<ItemToFind> create_using(Condition<ItemToFind> criteria);
    IMatchAn<ItemToFind> create_using(IMatchAn<PropertyType> criteria);
  }
}