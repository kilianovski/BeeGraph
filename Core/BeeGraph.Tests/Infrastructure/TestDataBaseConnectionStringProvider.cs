using BeeGraph.Data.Config;

namespace BeeGraph.Tests.Infrastructure
{
    public class TestDataBaseConnectionStringProvider : IConnectionStringProvider
    {
        private static string cs = "Server=localhost\\SQLEXPRESS;Database=BeeGraph_Test;Trusted_Connection=True;";

        public string ConnectionString => cs;
    }
}
