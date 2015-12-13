using System;

namespace MonadSharp
{
    public static class ConditionalExpression
    {
        public static Maybe<T> If<T>(Func<bool> condition, Func<T> expression)
        {
            return condition() ? Maybe.Some(expression()) : Maybe.None<T>();
        }

        public static Maybe<T> If<T>(Func<bool> condition, T value)
        {
            return condition() ? Maybe.Some(value) : Maybe.None<T>();
        }

        public static Maybe<T> If<T>(bool condition, Func<T> expression)
        {
            return condition ? Maybe.Some(expression()) : Maybe.None<T>();
        }

        public static Maybe<T> If<T>(bool condition, T value)
        {
            return condition ? Maybe.Some(value) : Maybe.None<T>();
        }
    }
    
    public static class ConditionalExpressionExtensions
    {
        public static Maybe<T> ElseIf<T>(this Maybe<T> x,
            Func<bool> condition, Func<T> expression)
        {
            return x.IsSome ? x : ConditionalExpression.If(condition, expression);
        }

        public static Maybe<T> ElseIf<T>(this Maybe<T> x,
            Func<bool> condition, T value)
        {
            return x.IsSome ? x : ConditionalExpression.If(condition, value);
        }

        public static Maybe<T> ElseIf<T>(this Maybe<T> x,
            bool condition, Func<T> expression)
        {
            return x.IsSome ? x : ConditionalExpression.If(condition, expression);
        }

        public static Maybe<T> ElseIf<T>(this Maybe<T> x,
            bool condition, T value)
        {
            return x.IsSome ? x : ConditionalExpression.If(condition, value);
        }

        public static Maybe<T> Else<T>(this Maybe<T> x, Func<T> expression)
        {
            return x.IsSome ? x : Maybe.Some(expression());
        }

        public static Maybe<T> Else<T>(this Maybe<T> x, T value)
        {
            return x.IsSome ? x : Maybe.Some(value);
        }
    }
}
