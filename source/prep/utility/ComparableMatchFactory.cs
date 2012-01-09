using System;

namespace prep.utility
{
    public class ComparableMatchFactory<ItemToFind, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly ICreateMatchers<ItemToFind, PropertyType> factory;
        readonly PropertyAccessor<ItemToFind, PropertyType> accessor;

        public ComparableMatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor,
                                      ICreateMatchers<ItemToFind, PropertyType> original)
        {
            this.accessor = accessor;
            factory = original;
        }

        public IMatchAn<ItemToFind> greater_than(PropertyType value)
        {
            return LambdaMatcher<ItemToFind>.getMeALambdaMatcher(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToFind> equal_to(PropertyType value)
        {
            return factory.equal_to(value);
        }

        public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
        {
            return factory.equal_to_any(values);
        }

        public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
        {
            return factory.not_equal_to(value);
        }

        public IMatchAn<ItemToFind> between(PropertyType start, PropertyType end)
        {
            return greater_or_equal_to(start).and(smaller_or_equal_to(end));
        }

        public IMatchAn<ItemToFind> smaller_or_equal_to(PropertyType end)
        {
            return smaller_than(end).or(equal_to(end));
        }

        public IMatchAn<ItemToFind> greater_or_equal_to(PropertyType start)
        {
            return greater_than(start).or(equal_to(start));
        }

        public IMatchAn<ItemToFind> smaller_than(PropertyType value)
        {
            return LambdaMatcher<ItemToFind>.getMeALambdaMatcher(x => accessor(x).CompareTo(value) < 0);
        }
    }
}