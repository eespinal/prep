namespace prep.utility
{
  public class MatchFactory<ItemToFind, PropertyType> : ICreateMatchers<ItemToFind, PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      return create_using(new IsEqualToAny<PropertyType>(values));
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      return equal_to(value).not();
    }

    public IMatchAn<ItemToFind> create_using(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFind, PropertyType>(accessor, criteria);
    }

    public IMatchAn<ItemToFind> create_using(Condition<ItemToFind> criteria)
    {
      return new LambdaMatcher<ItemToFind>(criteria);
    }
  }
}