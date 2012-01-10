using System.Collections;
using System.Collections.Generic;
using prep.utility.filtering.extension_points;

namespace prep.utility.filtering.core
{
  public class Where<ItemToFind>
  {
    public static FilteringExtensionPoint<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new FilteringExtensionPoint<ItemToFind, PropertyType>(accessor);
    }
  }
}