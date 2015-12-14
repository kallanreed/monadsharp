using System;

namespace MonadSharp.Samples
{
    class SamplesHost
    {
        public static void Main(string[] args)
        {
            // Maybe
            Console.WriteLine("Maybe Samples");
            MaybeSample.LifingFunctions();
            MaybeSample.FunctorFunctions();
            MaybeSample.ApplicativeFunctions();
            MaybeSample.ComputationExpressions();
            Console.WriteLine();

            // IEnumerable
            Console.WriteLine("IEnumerable Samples");
            IEnumerableSample.FunctorFunctions();
            IEnumerableSample.ApplicativeFunctions();
            IEnumerableSample.ComputationExpressions(); 
            Console.WriteLine();
            
            // Conditional Expression
            Console.WriteLine("Conditional Expression Samples");
            ConditionalExpressionSample.SimpleConditionalExpression();
            ConditionalExpressionSample.LazyConditionalEvaluation();
        }
    }
}
