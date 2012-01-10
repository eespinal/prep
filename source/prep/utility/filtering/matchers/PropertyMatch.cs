using prep.utility.filtering.core;

namespace prep.utility.filtering.matchers
{
  public class PropertyMatch<ItemToMatch, PropertyType> : IMatchAn<ItemToMatch>
  {
    PropertyAccessor<ItemToMatch, PropertyType> accessor;
    IMatchAn<PropertyType> real_matcher;

    public PropertyMatch(PropertyAccessor<ItemToMatch, PropertyType> accessor, IMatchAn<PropertyType> real_matcher)
    {
      this.accessor = accessor;
      this.real_matcher = real_matcher;
    }

    public bool matches(ItemToMatch item)
    {
      return real_matcher.matches(accessor(item));
    }
  }
}