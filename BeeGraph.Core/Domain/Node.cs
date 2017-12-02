using System.Collections.Generic;
using BeeGraph.Infrastructure;

namespace BeeGraph.Core.Domain
{
    public class Node
    {
        public int Id { get; }
        public string Body { get; }
        public IEnumerable<Edge> OutEdges { get; private set; }

        public Node(int id, string body) 
            : this(id, body, System.Linq.Enumerable.Empty<Edge>())
        { }

        public Node(int id, string body, IEnumerable<Edge> outEdges)
        {
            Body = body;
            OutEdges = outEdges;
            Id = id;
        }

        public Node WithNewOutEdge(Edge e) =>
            new Node(Id, Body, OutEdges.Append(e));

        public void AppendEdge(Edge e) =>
            OutEdges = OutEdges.Append(e);
    }
}