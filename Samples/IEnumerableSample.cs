using System;
using System.Collections.Generic;
using System.Linq;

namespace MonadSharp.Samples
{
    public class IEnumerableSample
    {
        public static void FunctorFunctions()
        {
            Func<int, int> add2 = x => x + 2;

            var xs = new[] { 1, 2, 3 };
            var ys = xs.FMap(add2);

            Console.WriteLine("IEnumerable FMap {0}", String.Join(", ", ys));
        }

        public static void ApplicativeFunctions()
        {
            Func<int, int, int> add = (x, y) => x + y;

            var xs = new[] { 1, 2, 3 };
            var fs = xs.Map(x => add.Apply(x));
            var ys = xs.Apply(fs);
            
            Console.WriteLine("IEnumerable<int -> int> applied to IEnumerable<int> {0}", String.Join(", ", ys));
        }

        public static void ComputationExpressions()
        {
            // NOTE: you would probably be better off with Map/Agg for IEnumerable

            Func<int, IEnumerable<string>> repeatIt =
                x => Enumerable.Repeat(x.ToString(), x);
            
            var xs = new[] { 1, 2, 3 };

            var ys = xs
                .Bind(repeatIt)
                .Bind(x => (x + "!").Singleton());

            Console.WriteLine("IEnumerable computation expression {0}", String.Join(", ", ys));
        }
    }
}

