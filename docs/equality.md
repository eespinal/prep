#Rules for equality checking in .Net

1. Is it a class (reference type)
  * Does the type implement IEquatable<T> - use it
  * Does the type override Equals - use it
  * Reference Equality Check 

2. Is it a struct (value type)
  * Does the type override Equals - use it
  * Reflective field by field equality check
