using System;

namespace prep.collections
{
  public class Where<ItemToFind>
  {
    public static Func<Movie,ProductionStudio> has_a(Func<Movie, ProductionStudio> func)
    {
      return func;
    }
  }
}