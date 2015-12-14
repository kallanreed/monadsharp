using System;

namespace MonadSharp
{
    // Note for later: lambdas can accept out params
    // (x, out y) => y = x * 2

    public static class Function
    {
        // Function Application
        public static TResult Apply<T1, TResult>(
            this Func<T1, TResult> fn, T1 arg1)
        {
            return fn(arg1);
        }

        public static Func<T2, TResult> Apply<T1, T2, TResult>(
            this Func<T1, T2, TResult> fn, T1 arg1)
        {
            return (arg2) => fn(arg1, arg2);
        }

        public static Func<T2, T3, TResult> Apply<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> fn, T1 arg1)
        {
            return (arg2, arg3) => fn(arg1, arg2, arg3);
        }

        public static Func<T2, T3, T4, TResult> Apply<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> fn, T1 arg1)
        {
            return (arg2, arg3, arg4) => fn(arg1, arg2, arg3, arg4);
        }

        public static Func<T2, T3, T4, T5, TResult> Apply<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> fn, T1 arg1)
        {
            return (arg2, arg3, arg4, arg5) => fn(arg1, arg2, arg3, arg4, arg5);
        }

        public static Func<T2, T3, T4, T5, T6, TResult> Apply<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T1 arg1)
        {
            return (arg2, arg3, arg4, arg5, arg6) => fn(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        // FMap
        public static Func<T1, TResult> FMap<T1, T2, TResult>(
            this Func<T2, TResult> f, Func<T1, T2> g)
        {
            return x => f(g(x));
        }

        public static Func<T2, T1, TResult> Flip<T1, T2, TResult>(
            this Func<T1, T2, TResult> fn)
        {
            return (x, y) => fn(y, x);
        }
    }
}
