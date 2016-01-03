using System;

namespace MonadSharp
{
    public static class ParsingExtensions
    {
        public static Maybe<int> ParseInt(this string s)
        {
            int i;
            return int.TryParse(s, out i) ? Maybe.Some(i) : Maybe.None<int>();
        }
    }
}

