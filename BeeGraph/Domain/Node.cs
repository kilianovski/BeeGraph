using System.Collections.Generic;
using System.Collections.Immutable;
using BeeGraph.Infrastructure;

namespace BeeGraph.Domain
{
    public class Node
    {
        public Node(int id, string body, IEnumerable<Edge> edges)
        {
            Edges = edges;
            Body = body;
            Id = id;
        }

        public int Id { get; }
        public string Body { get; }
        public IEnumerable<Edge> Edges { get; private set; }

        public Node WithNewEdge(Edge e)
        {
            Edges = Edges.Append(e);
            return this;
        }
    }
}