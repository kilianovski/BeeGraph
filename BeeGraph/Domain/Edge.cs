using System.Collections.Generic;

namespace BeeGraph.Domain
{
    public class Edge
    {
        public int Id { get; }
        public string Body { get; }
        public IEnumerable<string> Keys { get; }
        public Node TargetNode { get; }

        public Edge(int id, string body, IEnumerable<string> keys, Node targetNode)
        {
            Id = id;
            Body = body;
            Keys = keys;
            TargetNode = targetNode;
        }
    }
}
