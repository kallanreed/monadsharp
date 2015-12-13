using System;
using NUnit.Framework;

namespace MonadSharp.Test
{
    public class describe_ConditionalExpression
    {
        [TestFixture]
        public class If : describe_ConditionalExpression
        {
            [Test]
            public void if_condition_true_it_should_return_value()
            {
                var val = 5;
                var x = ConditionalExpression.If(true, val).Value();

                Assert.AreEqual(val, x);
            }

            [Test]
            [ExpectedException(typeof(MaybeIsNoneException))]
            public void if_condition_false_it_should_throw()
            {
                ConditionalExpression.If(false, 10).Value();
            }
        }
    }
}

