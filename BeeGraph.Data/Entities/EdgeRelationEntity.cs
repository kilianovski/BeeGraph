namespace BeeGraph.Data.Entities
{
    public class EdgeRelationEntity
    {
        public int FromNodeId { get; }
        public int EdgeId { get; }
        public string EdgeKey { get; }
        public int ToNodeId { get; }

        public EdgeRelationEntity(int fromNodeId, int edgeId, string edgeKey, int toNodeId)
        {
            FromNodeId = fromNodeId;
            EdgeId = edgeId;
            EdgeKey = edgeKey;
            ToNodeId = toNodeId;
        }
    }
}
