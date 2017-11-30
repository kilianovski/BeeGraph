using System.Collections.Generic;

namespace BeeGraph.Tests.Infrastructure
{
    public static class RandomExtensions
    {
        public static T PickRandomElem<T>(this IList<T> list)
        {
            var r = new System.Random();
            int randomI = r.Next(0, list.Count - 1);
            return list[randomI];
        }
    }
}
