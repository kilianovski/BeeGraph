using static BeeGraph.Data.Constants.StoredProcedureAliases;

namespace BeeGraph.Data.Constants
{
    public class StoredProcedure
    {
        public static StoredProcedure GetNodes => new StoredProcedure(GetAllNodes);
        public static StoredProcedure InsertNode => new StoredProcedure(CreateNode);

        public static StoredProcedure GetEdges => new StoredProcedure(GetAllEdges);
        public static StoredProcedure InsertEdge => new StoredProcedure(CreateEdge);

        public static StoredProcedure GetEdgeToNodeRelations => new StoredProcedure(StoredProcedureAliases.GetEdgeToNodeRelations);
        public static StoredProcedure CreateEdgeToNodeRelation => new StoredProcedure(InsertEdgeToNodesRelation);

        public static StoredProcedure GetEdgeRelations => Inst("sp_GetEdgeRelations");

        private static StoredProcedure Inst(string alias) => new StoredProcedure(alias);


        public string Name { get; }

        public StoredProcedure(string name)
        {
            Name = name;
        }
    }
}