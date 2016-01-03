using System;
using NUnit.Framework;

namespace MonadSharp.Test
{
    [TestFixture]
    public class describe_Maybe
    {
        [Test]
        public void none_should_equal_none()
        {
            var none = Maybe.None<int>();

            Assert.AreEqual(Maybe.None<int>(), none);
            Assert.AreSame(Maybe.None<int>(), none);
        }

        [Test]
        public void none_of_different_maybe_types_should_not_be_equal()
        {
            var intNone = Maybe.None<int>();
            var stringNone = Maybe.None<string>();
            
            Assert.AreNotEqual(intNone, stringNone);
        }

        [Test]
        [ExpectedException(typeof(MaybeValueCannotBeNullException))]
        public void constructing_some_with_null_should_throw()
        {
            Maybe.Some<string>(null);
        }

        [Test]
        public void some_value_should_not_equal_none()
        {
            var some = Maybe.Some(5);
            var none = Maybe.None<int>();

            Assert.AreNotEqual(some, none);
        }

        [Test]
        public void some_value_should_equal_same_some_value()
        {
            var some = Maybe.Some(5);
            
            Assert.AreEqual(some, some);
        }

        [Test]
        public void some_value_should_equal_another_some_value_of_same_value()
        {
            var value = 5;
            var some = Maybe.Some(value);
            
            Assert.AreEqual(Maybe.Some(value), some);
        }

        [Test]
        public void try_invoke_should_return_some_value()
        {
            var value = 5;
            var some = Maybe.TryInvoke(() => int.Parse(value.ToString()));

            Assert.AreEqual(value, some.Value());
        }

        [Test]
        public void try_invoke_should_return_none_if_expression_throws()
        {
            var none = Maybe.TryInvoke(() => int.Parse("not int"));
            
            Assert.AreEqual(Maybe.None<int>(), none);
        }
    }
}
