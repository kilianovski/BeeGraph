namespace BeeGraph.Data.Constants
{
    public static class StoredProcedureAliases
    {
        public const string GetAllNodes = "sp_GetNodes";
        public const string CreateNode = "sp_InsertNode";

        public const string GetAllEdges = "sp_GetEdges";
        public const string CreateEdge = "sp_InsertEdge";

        public const string GetEdgeToNodeRelations = "sp_GetEdgeToNodesRelations";
        public const string InsertEdgeToNodesRelation = "sp_InsertEdgeToNodesRelation";
    }
}
