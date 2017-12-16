using System;

namespace BeeGraph.Infrastructure.Monads
{
    public static class MaybeMonad
    {
        public static Maybe<T> Return<T>(T x) => Maybe.Just(x);

        public static Maybe<TResult> Bind<T, TResult>(this Maybe<T> m, Func<T, Maybe<TResult>> f) => 
            m.HasValue
                ? f(m.Value)
                : Maybe.Nothing<TResult>();

        public static Maybe<TResult> Map<T, TResult>(this Maybe<T> m, Func<T, TResult> f) =>
            m.HasValue
                ? Maybe.Just(f(m.Value))
                : Maybe.Nothing<TResult>();

        public static TResult Match<T, TResult>(
            this Maybe<T> m,
            Func<T, TResult> ifJust,
            Func<TResult> ifNothing) => 
                m.HasValue
                    ? ifJust(m.Value)
                    : ifNothing();
    }
}
