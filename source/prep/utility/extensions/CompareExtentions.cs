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
  }
}