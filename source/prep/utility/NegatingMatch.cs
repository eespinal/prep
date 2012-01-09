namespace prep.utility
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