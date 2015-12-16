using System;
using System.Linq;
using NUnit.Framework;

namespace MonadSharp.Test
{
    public class describe_IEnumerableExtensions
    {
        [TestFixture]
        public class AsMaybe : describe_IEnumerableExtensions
        {
            [Test]
            public void given_enumerable_with_value_it_should_return_some_value()
            {
                var enum5 = 5.Singleton();
                var some5 = enum5.AsMaybe();

                Assert.AreEqual(5, some5.Value());
            }

            [Test]
            public void given_empty_enumerable_it_should_return_none()
            {
                var emptyIntEnum = Enumerable.Empty<int>();
                var none = emptyIntEnum.AsMaybe();

                Assert.AreEqual(Maybe<int>.None, none);
            }
        }
    }
}

