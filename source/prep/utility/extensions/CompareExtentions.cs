using System.Collections.Generic;
using prep.utility.sorting;

namespace prep.utility.extensions
{
  public static class CompareExtentions
  {
    public static IComparer<ItemToSort> descending<ItemToSort>(
      this IComparer<ItemToSort> comparer)
    {
      return new ReverseComparer<ItemToSort>(comparer);
    }

    public static IComparer<ItemToSort> combined_with<ItemToSort>(
      this IComparer<ItemToSort> first_comparer,IComparer<ItemToSort> second_comparer)
    {
        return new CombinedComparer<ItemToSort>(first_comparer, second_comparer);
    }
  }
}