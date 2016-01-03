using System;
using System.Collections.Generic;

namespace MonadSharp
{
    // The Task<T> monad behaves much like Either<L, R>

    public static class Either
    {
        public static Either<L, R> Left<L, R>(L value)
        {
            return Either<L, R>.NewLeft<L, R>(value);
        }
        
        public static Either<L, R> Right<L, R>(R value)
        {
            return Either<L, R>.NewRight<L, R>(value);
        }

        public static Either<Exception, T> TryInvoke<T>(Func<T> fn)
        {
            try
            {
                return Either.Right<Exception, T>(fn());
            }
            catch (Exception ex)
            {
                return Either.Left<Exception, T>(ex);
            }
        }
    }
    
    // Implementation is based off F# ADT IL
    // TODO: IComparable, IEquatable
    
    public abstract class Either<L, R>
    {   
        public bool IsLeft {
            get { return this is Left; }
        }
        
        public bool IsRight {
            get { return this is Right; }
        }
        
        public sealed override bool Equals(object other)
        {
            var o = other as Either<L, R>;
            return o == null ? false : Equals(o);
        }
        
        public bool Equals(Either<L, R> other)
        {
            if (other == null)
                return false;

            if (this.GetType() != other.GetType())
                return false;

            return this.IsLeft
                ? EqualityComparer<L>.Default.Equals(((Left)this).Value, ((Left)other).Value)
                : EqualityComparer<R>.Default.Equals(((Right)this).Value, ((Right)other).Value);
        }
        
        public sealed override int GetHashCode()
        {
            return IsLeft
                ? EqualityComparer<L>.Default.GetHashCode(((Left)this).Value)
                : EqualityComparer<R>.Default.GetHashCode(((Right)this).Value);
        }
        
        internal static Either<TLeft, TRight> NewLeft<TLeft, TRight>(TLeft value)
        {
            return new Either<TLeft, TRight>.Left(value);
        }

        internal static Either<TLeft, TRight> NewRight<TLeft, TRight>(TRight value)
        {
            return new Either<TLeft, TRight>.Right(value);
        }
        
        internal sealed class Left : Either<L, R>
        {
            public L Value { get; private set; }
            
            internal Left(L value)
            {
                Value = value;
            }
        }
     
        internal sealed class Right : Either<L, R>
        {
            public R Value { get; private set; }
            
            internal Right(R value)
            {
                Value = value;
            }
        }
    }
}
