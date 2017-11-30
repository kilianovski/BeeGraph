namespace BeeGraph.Data.Constants
{
    public static class StoredProcedureAliases
    {
        public const string GetAllNodes = "sp_GetNodes";
        public const string CreateNode = "sp_InsertNode";
    }

    public class StoredProcedure
    {
        public static StoredProcedure GetNodes => new StoredProcedure(StoredProcedureAliases.GetAllNodes);
        public static StoredProcedure InsertNode => new StoredProcedure(StoredProcedureAliases.CreateNode);

        public string Name { get; }

        public StoredProcedure(string name)
        {
            Name = name;
        }
    }
}
