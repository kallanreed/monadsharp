using System;
using System.Collections.Generic;
using System.Linq;

namespace MonadSharp
{
    // TODO: these functions need to use "Function.Apply"
    // so that Functor and Applicative work

    public static class MaybeExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this Maybe<T> m)
        {
            return m.Singleton().Choose();
        }

        public static Maybe<TResult> FMap<T, TResult>(this Maybe<T> m, Func<T, TResult> fn)
        {
            return m.IsNone ? Maybe.None<TResult>() : Maybe.Some(fn(m.Value()));
        }

        public static Maybe<TResult> Bind<T, TResult>(this Maybe<T> m, Func<T, Maybe<TResult>> fn)
        {
            return m.IsNone ? Maybe.None<TResult>() : fn(m.Value());
        }

        // TODO: needs overload that takes a function as 'this'
        public static Maybe<TResult> Apply<T, TResult>(this Maybe<T> m, Maybe<Func<T, TResult>> fn)
        {
            return m.IsNone || fn.IsNone ? Maybe.None<TResult>() : Maybe.Some(fn.Value()(m.Value()));
        }

        public static T Value<T>(this Maybe<T> m)
        {
            var some = m as Maybe<T>.Some;
            
            if (some == null) throw new MaybeIsNoneException();
            
            return some.Value;
        }

        public static T ValueOrDefault<T>(this Maybe<T> m, T defaultValue = default(T))
        {
            return m.IsNone ? defaultValue : m.Value();
        }
    }
}
