using System;

namespace MonadSharp
{
    public static class MaybeExtensions
    {
        public static T Value<T>(this Maybe<T> source)
        {
            var some = source as Maybe<T>.Some;
            
            if (some == null) throw new MaybeIsNoneException();
            
            return some.Value;
        }
    }
}
