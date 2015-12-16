using System;
using System.Linq;

using NUnit.Framework;

namespace MonadSharp.Test
{
    public class describe_MaybeExtensions
    {
        [TestFixture]
        public class AsEnumerable : describe_MaybeExtensions
        {
            [Test]
            public void given_some_it_should_return_enumerable_with_value()
            {
                var some5 = Maybe.Some(5);
                var enum5 = some5.AsEnumerable();

                Assert.AreEqual(5, enum5.First());
            }

            [Test]
            public void given_none_it_should_return_empth_enumerable()
            {
                var none = Maybe.None<int>();
                var enumNone = none.AsEnumerable();

                Assert.IsFalse(enumNone.Any());
            }
        }
    }
}

