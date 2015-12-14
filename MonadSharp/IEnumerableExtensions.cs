using System;
using System.Collections.Generic;
using System.Linq;

namespace MonadSharp
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TResult> FMap<T, TResult>(
            this IEnumerable<T> source, Func<T, TResult> fn)
        {
            return source.Select(fn);
        }

        public static IEnumerable<TResult> Bind<T, TResult>(
            this IEnumerable<T> source, Func<T, IEnumerable<TResult>> fn)
        {
            return source.SelectMany(x => fn(x));
        }

        public static IEnumerable<TResult> Apply<T, TResult>(
            this IEnumerable<T> source, IEnumerable<Func<T, TResult>> fn)
        {
            return fn.SelectMany(f => source.Map(f));
        }

        public static IEnumerable<TResult> Map<T, TResult>(
            this IEnumerable<T> source, Func<T, TResult> mapper)
        {
            return source.Select(mapper);
        }

        public static IEnumerable<T> Choose<T>(this IEnumerable<Maybe<T>> source)
        {
            return source.Where(x => x.IsSome).Map(x => x.Value());
        }

        public static IEnumerable<TResult> MapMaybe<T, TResult>(
            this IEnumerable<T> source, Func<T, Maybe<TResult>> mapper)
        {
            return source.Map(mapper).Choose();
        }

        public static IEnumerable<T> Singleton<T>(this T o)
        {
            yield return o;
        }
    }
}

