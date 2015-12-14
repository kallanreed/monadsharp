using System;

namespace MonadSharp
{
    public static class PrimativeExtensions
    {
        public static bool IsOdd(this int i)
        {
            return (i & 0x1) == 1;
        }

        public static bool IsEven(this int i)
        {
            return !i.IsOdd();
        }
    }
}
