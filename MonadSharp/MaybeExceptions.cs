using System;

namespace MonadSharp
{
    public class MaybeIsNoneException : Exception { }
  
    public class MaybeValueCannotBeNullException : Exception
    {
        public MaybeValueCannotBeNullException()
            : base("Cannot build Maybe.Some<T> with null. Use Maybe.None instead.") { }
    }
}
