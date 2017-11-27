using System;

namespace BeeGraph.Infrastructure
{
    public static class Maybe
    {
        public static Maybe<T> Just<T>(T value) => new Maybe<T>(value, true);
        public static Maybe<T> Nothing<T>() => new Maybe<T>(default(T), false);
    }

    public class Maybe<T>
    {
        public bool HasValue { get; }
        public T Value { get; }

        internal Maybe(T value, bool hasValue)
        {
            if (hasValue && value == null)
                throw new ArgumentException("Value can not be null, bastard!");

            HasValue = hasValue;
            Value = value;
        }
    }
}
