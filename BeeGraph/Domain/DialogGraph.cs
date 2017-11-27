using System.Collections.Generic;

namespace BeeGraph.Domain
{
    public class DialogGraph
    {
        public IEnumerable<Node> Nodes { get; }
        public IEnumerable<Edge> Edges { get; }

        public DialogGraph(IEnumerable<Node> nodes, IEnumerable<Edge> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }
    }
}
