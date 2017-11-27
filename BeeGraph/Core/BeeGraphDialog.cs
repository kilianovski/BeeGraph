using System;
using System.Linq;
using BeeGraph.Domain;

namespace BeeGraph.Core
{
    public class BeeGraphDialog : IBeeGraphDialog
    {
        private readonly DialogGraph _graph;
        private int _currentNodeId = 0;

        public BeeGraphDialog(DialogGraph graph)
        {
            _graph = graph;
        }
        public Node Talk(string userResponse)
        {
            var result = _graph.Nodes
                .Single(n => n.Id == _currentNodeId)
                .Edges
                .Single(e => e.Keys.Contains(userResponse))
                .TargetNode;

            _currentNodeId = result.Id;

            return result;
        }
    }
}