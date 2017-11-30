namespace BeeGraph.Data.Config
{
    public class HardcodedConnectionStringProvider : IConnectionStringProvider
    {
        private static string cs = "Server=localhost\\SQLEXPRESS;Database=BeeGraph_Test;Trusted_Connection=True;";

        public string ConnectionString => cs;
    }
}
