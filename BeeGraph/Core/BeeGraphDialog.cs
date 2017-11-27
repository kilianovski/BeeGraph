using System;
using System.Linq;
using BeeGraph.Domain;

namespace BeeGraph.Core
{
    public class BeeGraphDialog : IBeeGraphDialog
    {
        private readonly DialogGraph _graph;

        public BeeGraphDialog(DialogGraph graph)
        {
            _graph = graph;
        }
        public Node Talk(int nodeId, string userResponse)
        {
            var result = _graph.Nodes
                .Single(n => n.Id == nodeId)
                .Edges
                .Single(e => e.Keys.Contains(userResponse))
                .Node;

            return result;
        }
    }
}