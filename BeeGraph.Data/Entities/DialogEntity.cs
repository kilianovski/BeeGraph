namespace BeeGraph.Data.Entities
{
    public class DialogEntity
    {
        public int Id { get; }
        public int StartNodeId { get; }

        public DialogEntity(int id, int startNodeId)
        {
            Id = id;
            StartNodeId = startNodeId;
        }
    }
}
