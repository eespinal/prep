namespace prep.utility
{
  public class NeverMatches<ItemToFind> : IMatchAn<ItemToFind>
  {
    public bool matches(ItemToFind item)
    {
      return false;
    }
  }
}