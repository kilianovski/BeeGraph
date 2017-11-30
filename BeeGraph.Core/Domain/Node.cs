namespace BeeGraph.Core.Domain
{
    public class Node
    {
        public int Id { get; }
        public string Body { get; }

        public Node(int id, string body)
        {
            Body = body;
            Id = id;
        }
    }
}