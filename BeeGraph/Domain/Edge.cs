namespace BeeGraph.Domain
{
    public class Edge
    {
        public int Id { get; }
        public string Key { get; }
        public Node From { get; }
        public Node To { get; }

        public Edge(int id, string key, Node @from, Node to)
        {
            Id = id;
            Key = key;
            From = @from;
            To = to;
        }
    }
}
