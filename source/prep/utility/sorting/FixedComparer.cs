using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class FixedComparer<PropertyType> : IComparer<PropertyType>
  {
    IList<PropertyType> values;

    public FixedComparer(params PropertyType[] values)
    {
      this.values = new List<PropertyType>(values);
    }

    public int Compare(PropertyType x, PropertyType y)
    {
      return values.IndexOf(x).CompareTo(values.IndexOf(y));
    }
  }
}