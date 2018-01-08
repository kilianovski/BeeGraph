namespace BeeGraph.Data.Entities
{
    public class EdgeRelationEntity
    {
        public int RelationId { get; }
        public int FromNodeId { get; }
        public string FromNodeBody { get; }
        public int EdgeId { get; }
        public string EdgeKey { get; }
        public int ToNodeId { get; }
        public string ToNodeBody { get; }

        public EdgeRelationEntity(int relationId, int fromNodeId,string fromNodeBody, int edgeId, string edgeKey, int toNodeId, string toNodeBody)
        {
            RelationId = relationId;
            FromNodeId = fromNodeId;
            FromNodeBody = fromNodeBody;
            EdgeId = edgeId;
            EdgeKey = edgeKey;
            ToNodeId = toNodeId;
            ToNodeBody = toNodeBody;
        }
    }
}
