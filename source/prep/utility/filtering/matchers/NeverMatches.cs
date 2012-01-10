using prep.utility.filtering.core;

namespace prep.utility.filtering.matchers
{
  public class NeverMatches<ItemToFind> : IMatchAn<ItemToFind>
  {
    public bool matches(ItemToFind item)
    {
      return false;
    }
  }
}