using System;
using static BeeGraph.Infrastructure.Maybe;

namespace BeeGraph.Infrastructure
{
    public static class MaybeMonad
    {
        public static Maybe<T> Return<T>(T x) => Just(x);

        public static Maybe<TResult> Bind<T, TResult>(this Maybe<T> m, Func<T, Maybe<TResult>> f) => 
            m.HasValue
                ? f(m.Value)
                : Nothing<TResult>();

        public static Maybe<TResult> Apply<T, TResult>(this Maybe<T> m, Func<T, TResult> f) =>
            m.HasValue
                ? Just(f(m.Value))
                : Nothing<TResult>();
    }
}
