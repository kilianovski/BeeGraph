namespace BeeGraph.Core.Domain
{
    public class DialogGraph
    {
        public Node StartNode { get; }

        public DialogGraph(Node startNode)
        {
            StartNode = startNode;
        }
    }
}
