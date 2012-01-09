namespace prep.utility
{
  public class FilteringExtensionPoint<ItemToFilter,PropertyType>
  {
      private bool is_negated;
      public PropertyAccessor<ItemToFilter, PropertyType> accessor { get; private set; }

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;

    }
      public IMatchAn<ItemToFilter> appropiate_matcher(IMatchAn<ItemToFilter> matcher)
      {
          return is_negated ? new NegatingMatch<ItemToFilter>(matcher) : matcher;
      }

      public IMatchAn<ItemToFilter> Matcher { get; private set; }

      public FilteringExtensionPoint<ItemToFilter, PropertyType> not { 
          get
      {
          this.is_negated = true;
          return this; 
      }
      }
  }
}