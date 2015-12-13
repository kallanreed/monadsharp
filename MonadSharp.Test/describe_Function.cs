using System;
using System.Linq;
using NUnit.Framework;

namespace MonadSharp.Test
{
    [TestFixture]
    public class describe_Function
    {
        [Test]
        public void it_should_curry_one()
        {
            Func<int, int> id = x => x;
            var one = id.Curry(1);

            Assert.AreEqual(1, one());
        }

        [Test]
        public void it_should_curry_two()
        {
            Func<int, int, int> add = (x, y) => x + y;
            var add5 = add.Curry(5);
            
            Assert.AreEqual(8, add5(3));
        }

        [Test]
        public void it_should_curry_methods()
        {
            // Sadly this doesn't work because of weird overload resolution in C#
            //var add5 = Add.Curry(5);

            var add5 = ((Func<int, int, int>)Add).Curry(5);

            Assert.AreEqual(8, add5(3));
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}

