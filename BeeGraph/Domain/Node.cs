using System.Collections.Generic;

namespace BeeGraph.Domain
{
    public class Node
    {
        public Node(int id, string body, HashSet<Edge> edges)
        {
            Edges = edges;
            Body = body;
            Id = id;
        }

        public int Id { get; }
        public string Body { get; }
        public HashSet<Edge> Edges { get; }
    }
}