using BeeGraph.Core.Domain;
using BeeGraph.Infrastructure;
using BeeGraph.Infrastructure.Monads;

namespace BeeGraph.Core
{
    public static class Dialog
    {
        public static Maybe<Node> Talk(Node currentNode, string message)
        {
            var node = currentNode
                .OutEdges
                .Find(e => e.Key == message)
                .Map(e => e.To);

            return node;
        }
    }
}
