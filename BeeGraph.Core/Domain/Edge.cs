namespace BeeGraph.Core.Domain
{
    public class Edge
    {
        public string Key { get; }
        public Node To { get; }

        public Edge(string key, Node to)
        {
            Key = key;
            To = to;
        }
    }
}
