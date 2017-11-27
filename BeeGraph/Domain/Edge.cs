using System.Collections.Generic;

namespace BeeGraph.Domain
{
    public class Edge
    {
        public int Id { get; }
        public string Body { get; }
        public HashSet<string> Keys { get; }
        public Node Node { get; }

        public Edge(int id, string body, HashSet<string> keys, Node node)
        {
            Id = id;
            Body = body;
            Keys = keys;
            Node = node;
        }
    }
}
