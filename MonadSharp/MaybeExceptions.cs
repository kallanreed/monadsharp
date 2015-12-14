using System;

namespace MonadSharp
{
    public class MaybeIsNoneException : Exception { }
  
    public class MaybeValueCannotBeNullException : Exception
    {
        public MaybeValueCannotBeNullException()
            : base("Cannot build Maybe<T>.Some with null. Use Maybe<T>.None instead.") { }
    }
}
