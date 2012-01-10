using prep.utility.filtering;
using prep.utility.filtering.core;
using prep.utility.filtering.matchers;

namespace prep.utility
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