using System;

namespace MonadSharp.Samples
{
    public static class MaybeSample
    {
        public static void LifingFunctions()
        {
            Func<int, int> doubleIt = x => x * 2;
            var doubleMaybe = Maybe.Lift(doubleIt);
            var some5 = Maybe.Some(5);

            var doubled = doubleMaybe(some5);

            Console.WriteLine("{0} doubled is {1}",
                some5.Value(), doubled.Value());
        }

        public static void FunctorFunctions()
        {
            var doubled = Maybe.Some(5).FMap(x => x * 2);
            Console.WriteLine("Doubled: {0}", doubled.Value());
        }

        public static void ApplicativeFunctions()
        {
            Func<int, int, int> add = (x, y) => x + y;
            var appliedAdd5 = Maybe.Some(add.Apply(5));
            var some5 = Maybe.Some(5);

            Console.WriteLine("Some(+5) applied to Some(5) = {0}", some5.Apply(appliedAdd5).Value());
        }

        public static void ComputationExpressions()
        {
            Func<int, Maybe<int>> half =
                x => x.IsEven() ? Maybe.Some(x / 2) : Maybe.None<int>();

            Func<int, Maybe<int>> halfThreeTimes = 
                x => Maybe.Some(x)
                    .Bind(half)
                    .Bind(half)
                    .Bind(half);

            Console.WriteLine("20 can be halfed 3 times? {0}", halfThreeTimes(20).IsSome);
            Console.WriteLine("16 can be halfed 3 times? {0}", halfThreeTimes(16).IsSome);
        }
    }
}

