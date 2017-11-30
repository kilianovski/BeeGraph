using System;
using System.Collections.Generic;
using BeeGraph.Infrastructure.Monads;
using static BeeGraph.Infrastructure.Monads.Maybe;

namespace BeeGraph.Infrastructure
{
    public static class BeefedLinq
    {
        public static Maybe<T> Find<T>(this IEnumerable<T> col, Func<T, bool> pred)
        {
            foreach (var item in col)
                if (pred(item)) return Just(item);
            return Nothing<T>();
        }
    }
}
