using System;

namespace MonadSharp.Samples
{
    public static class ConditionalExpressionSample
    {
        public static void SimpleConditionalExpression()
        {
            var rand = new Random();
            var r = rand.Next(10);

            var x = ConditionalExpression
                .If(r % 2 == 0, "Divisible by 2")
                .ElseIf(r % 3 == 0, "Divisible by 3")
                .Else("Not divisible by 2 or 3").Value();

            Console.WriteLine("{0} is {1}", r, x);
        }

        public static void LazyConditionalEvaluation()
        {
            Func<bool> shouldBeRun = () =>
            {
                Console.WriteLine("   Should Be Run!");
                return true;
            };

            Func<bool> shouldNotBeRun = () =>
            {
                Console.WriteLine("!! Should Not Be Run!");
                return true;
            };

            // Eager evaluation
            var eager = ConditionalExpression
                .If(shouldBeRun(), 1)
                .ElseIf(shouldNotBeRun(), 2)
                .Else(3).Value();

            Console.WriteLine("Eager evaluation causes all conditions to " +
                "evaluate even when they shouldn't: eager={0}", eager);
        
            // Lazy evaluation
            var lazy = ConditionalExpression
                .If(shouldBeRun, 1)
                .ElseIf(shouldNotBeRun, 2)
                .Else(3).Value();
            
            Console.WriteLine("Lazy evaluation only evaluates conditions " +
                "if they are needed: lazy={0}", lazy);
        }
    }
}

