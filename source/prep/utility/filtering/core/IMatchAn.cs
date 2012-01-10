namespace prep.utility.filtering.core
{
  public interface IMatchAn<Item>
  {
    bool matches(Item item);
  }
}