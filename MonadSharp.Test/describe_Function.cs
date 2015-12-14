using System;
using System.Linq;
using NUnit.Framework;

namespace MonadSharp.Test
{
    public class describe_Function
    {
        [TestFixture]
        public class Apply : describe_Function
        {
            [Test]
            public void given_fully_applied_function_it_should_return_result()
            {
                Func<int, int> id = x => x;
                Assert.AreEqual(10, id.Apply(10));
            }

            [Test]
            public void it_should_partially_apply_functions()
            {
                Func<int, int, int> add = (x, y) => x + y;
                var add5 = add.Apply(5);
                
                Assert.AreEqual(typeof(Func<int, int>), add5.GetType());
            }

            [Test]
            public void it_should_partially_methods()
            {
                // Sadly this doesn't work because of weird method overload resolution in C#
                //var add5 = Add.Apply(5);
                var add5 = ((Func<int, int, int>)Add).Apply(5);

                Assert.AreEqual(8, add5(3));
            }

            static int Add(int x, int y)
            {
                return x + y;
            }
        }

        [TestFixture]
        public class FMap : describe_Function
        {
            [Test]
            public void it_should_preserve_order_when_composing()
            {
                Func<int, int> sub5 = x => x - 5;
                Func<int, int> mult2 = x => x * 2;

                var sub5_mult2 = sub5.FMap(mult2);
                var mult2_sub5 = mult2.FMap(sub5);

                Assert.AreEqual(35, sub5_mult2(20));
                Assert.AreEqual(30, mult2_sub5(20));
            }
        }

        [TestFixture]
        public class Flip : describe_Function
        {
            [Test]
            public void it_should_flip_argument_order()
            {
                Func<int, int, int> sub =
                    (x, y) => x - y;

                var sub5 = sub.Flip().Apply(5);
                var subFrom5 = sub.Apply(5);

                Assert.AreEqual(15, sub5(20));
                Assert.AreEqual(-15, subFrom5(20));
            }
        }
    }
}

