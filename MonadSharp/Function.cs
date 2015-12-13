using System;

namespace MonadSharp
{
    public static class Function
    {
        public static Func<TResult> Curry<T1, TResult>(this Func<T1, TResult> fn, T1 arg1)
        {
            return () => fn(arg1);
        }

        public static Func<T1, TResult> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> fn, T2 arg2)
        {
            return arg1 => fn(arg1, arg2);
        }
    }
}

