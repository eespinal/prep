using prep.utility.filtering.core;
using prep.utility.filtering.matchers;

namespace prep.utility.filtering.extensions
{
  public static class MatchExtensions
  {
    public static IMatchAn<Item> not<Item>(this IMatchAn<Item> to_negate)
    {
      return new NegatingMatch<Item>(to_negate);
    }

    public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
    {
      return new OrMatch<Item>(left, right);
    }

    public static IMatchAn<Item> and<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
    {
        return new AndMatch<Item>(left, right);
    }
  }
}