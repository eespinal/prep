using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ReverseComparer<ItemToSort> : IComparer<ItemToSort>
  {
    IComparer<ItemToSort> original;

    public ReverseComparer(IComparer<ItemToSort> original)
    {
      this.original = original;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return -original.Compare(x, y);
    }
  }
}