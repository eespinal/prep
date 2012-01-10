using System.Collections.Generic;
using prep.utility.filtering.core;

namespace prep.utility.filtering.matchers
{
  public class IsEqualToAny<T> : IMatchAn<T>
  {
    IList<T> values;

    public IsEqualToAny(params T[ ] values)
    {
      this.values = new List<T>(values);
    }

    public bool matches(T item)
    {
      return values.Contains(item);
    }
  }
}