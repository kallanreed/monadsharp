using System;

namespace MonadSharp
{
    public static class EitherExtensions
    {
        public static L Left<L, R>(this Either<L, R> x)
        {
            var left = x as Either<L, R>.Left;

            if (left == null) throw new EitherIsNotLeft();

            return left.Value;
        }

        public static R Right<L, R>(this Either<L, R> x)
        {
            var right = x as Either<L, R>.Right;
            
            if (right == null) throw new EitherIsNotRight();
            
            return right.Value;
        }

        public static TResult Either<L, R, TResult>(
            this Either<L, R> x,
            Func<L, TResult> fnLeft,
            Func<R, TResult> fnRight)
        {
            return x.IsLeft
                ? fnLeft(x.Left())
                : fnRight(x.Right());
        }
    }
}

