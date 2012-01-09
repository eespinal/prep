namespace prep.utility
{
  public class Where<ItemToFind>
  {
    public static MatchFactory<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new MatchFactory<ItemToFind, PropertyType>(accessor);
    }
  }
}