using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Config;
using BeeGraph.Data.Entities;
using static BeeGraph.Data.Helpers.SqlUtils;

namespace BeeGraph.Data
{
    public class DialogRepository : IDialogRepository
    {
        private readonly string _connectionString;

        public DialogRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionString = connectionStringProvider.ConnectionString;
        }

        public int AddDialog(int startNodeId)
        {
            string sqlExpression = " INSERT INTO Dialog  (StartNodeId) " +
                                   "  OUTPUT Inserted.Id" +
                                   $" VALUES({startNodeId})";

            return Connect(_connectionString, connection =>
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                var result = command.ExecuteScalar();

                return (int) result;

            });
        }

        public IEnumerable<DialogEntity> GetAll()
        {
            string sqlExpression = "SELECT * from Dialog";

            return Connect(_connectionString, connection =>
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                var reader = command.ExecuteReader();

                var result = new List<DialogEntity>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int startNodeId = reader.GetInt32(1);

                    var entity = new DialogEntity(id, startNodeId);

                    result.Add(entity);
                }

                return result;
            });
        }
    }
}