using System;
using prep.utility;

namespace prep.collections
{
  public class Where<ItemToFind>
  {
    public static Func<Movie,ProductionStudio> has_a(Func<Movie, ProductionStudio> func)
    {
      return func;
    }
  }
    public static class Helpers
    {
        public static IMatchAn<Movie> equal_to(this Func<Movie, ProductionStudio> func, ProductionStudio pixar)
        {
            return new LambdaMatcher<Movie>(x=>func(x)==pixar);
        }
        
    }
}