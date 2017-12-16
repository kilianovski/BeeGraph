using System.Collections.Generic;
using System.Linq;

namespace BeeGraph.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> col, T x) => 
            col.Concat(x.AsEnumerable());

        public static IEnumerable<T> AsEnumerable<T>(this T x)
        {
            yield return x;
        }
    }
}
