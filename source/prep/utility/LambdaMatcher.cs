namespace prep.utility
{
  public class LambdaMatcher<Item> : IMatchAn<Item>
  {
    Condition<Item> criteria;

    public LambdaMatcher(Condition<Item> criteria)
    {
      this.criteria = criteria;
    }

    public bool matches(Item item)
    {
      return criteria(item);
    }
  }
}