using prep.utility.filtering.core;

namespace prep.utility.filtering.matchers
{
  public class NegatingMatch<ItemToFind> : IMatchAn<ItemToFind>
  {
    IMatchAn<ItemToFind> to_negate;

    public NegatingMatch(IMatchAn<ItemToFind> to_negate)
    {
      this.to_negate = to_negate;
    }

    public bool matches(ItemToFind item)
    {
      return ! to_negate.matches(item);
    }
  }
}