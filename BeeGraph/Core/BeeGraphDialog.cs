using System.Linq;
using BeeGraph.Domain;
using BeeGraph.Infrastructure;

namespace BeeGraph.Core
{
    public class BeeGraphDialog : IBeeGraphDialog
    {
        private readonly DialogGraph _graph;

        public BeeGraphDialog(DialogGraph graph)
        {
            _graph = graph;
        }

        public Maybe<Node> Talk(string userResponse)
        {
            var resultNode = _graph
                .Edges
                .Find(e => e.Key == userResponse)
                .Apply(e => e.To);

            return resultNode;
        }
    }
}