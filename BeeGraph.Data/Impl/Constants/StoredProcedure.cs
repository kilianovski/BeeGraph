using static BeeGraph.Data.Constants.StoredProcedureAliases;

namespace BeeGraph.Data.Constants
{
    public class StoredProcedure
    {
        public static StoredProcedure GetNodes => new StoredProcedure(GetAllNodes);
        public static StoredProcedure InsertNode => new StoredProcedure(CreateNode);

        public static StoredProcedure GetEdges => new StoredProcedure(GetAllEdges);
        public static StoredProcedure InsertEdge => new StoredProcedure(CreateEdge);

        public string Name { get; }

        public StoredProcedure(string name)
        {
            Name = name;
        }
    }
}