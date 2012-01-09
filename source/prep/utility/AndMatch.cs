namespace prep.utility
{
    public class AndMatch<Item> : IMatchAn<Item>
    {
        IMatchAn<Item> left_side;
        IMatchAn<Item> right_side;

        public AndMatch(IMatchAn<Item> left_side, IMatchAn<Item> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(Item item)
        {
            return left_side.matches(item) && right_side.matches(item);
        }
    }
}