using System;
using System.Collections.Generic;

namespace MonadSharp
{
    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value)
        {
            return Maybe<T>.NewSome(value);
        }

        public static Maybe<T> None<T>()
        {
            return Maybe<T>.None;
        }

        public static Func<Maybe<T>, Maybe<TResult>> Lift<T, TResult>(Func<T, TResult> fn)
        {
            return x => x.FMap(fn);
        }

        public static Maybe<T> TryInvoke<T>(Func<T> fn)
        {
            try
            {
                return Maybe.Some(fn());
            }
            catch
            {
                return Maybe.None<T>();
            }
        }
    }

    // Implementation is based off F# ADT IL
    // TODO: IComparable, IEquatable

    public abstract class Maybe<T>
    {
        private static readonly Maybe<T> UniqueNone = new _None();

        public static Maybe<T> None {
            get { return UniqueNone; }
        }

        public bool IsSome {
            get { return this is Some; }
        }

        public bool IsNone {
            get { return this is _None; }
        }

        public sealed override bool Equals(object other)
        {
            var o = other as Maybe<T>;
            return o == null ? false : Equals(o);
        }

        public bool Equals(Maybe<T> other)
        {
            if (other == null)
                return false;

            if (this.IsNone && other.IsNone)
                return true;

            if (this.IsSome && other.IsSome) {
                var thisValue = ((Some)this).Value;
                var otherValue = ((Some)other).Value;

                return EqualityComparer<T>.Default.Equals(thisValue, otherValue);
            }

            return false;
        }

        public sealed override int GetHashCode()
        {
            return IsNone ? base.GetHashCode() :
                EqualityComparer<T>.Default.GetHashCode(((Some)this).Value);
        }

        internal static Maybe<TValue> NewSome<TValue>(TValue value)
        {
            return new Maybe<TValue>.Some(value);
        }

        internal sealed class Some : Maybe<T>
        {
            public T Value { get; private set; }
      
            internal Some(T value)
            {
                if (value == null) throw new MaybeValueCannotBeNullException();

                Value = value;
            }
        }
    
        internal sealed class _None : Maybe<T> { }
    }
}
