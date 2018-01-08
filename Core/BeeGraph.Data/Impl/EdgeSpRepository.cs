using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Config;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Entities;
using BeeGraph.Data.Helpers;
using static BeeGraph.Data.Helpers.SqlUtils;

namespace BeeGraph.Data
{
    public class EdgeSpRepository : IEdgeRepository
    {
        private readonly IStoredProcedureHelper _spHelper;
        private readonly string _connectionString;

        public EdgeSpRepository(IStoredProcedureHelper spHelper, IConnectionStringProvider connectionStringProvider)
        {
            _spHelper = spHelper;
            _connectionString = connectionStringProvider.ConnectionString;
        }

        public int CreateEdge(string key)
        {
            var keyParam = new SqlParameter()
            {
                ParameterName = "@key",
                Value = key
            };

            var result = _spHelper.ExecuteScalar(StoredProcedure.InsertEdge, keyParam);

            return (int) (decimal) result;
        }

        public IEnumerable<EdgeEntity> GetAll()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetEdges, ReadEdge);
        }

        public void Delete(int edgeId)
        {
            var sqlRequest = $"DELETE FROM EdgeToNodes WHERE EdgeId = {edgeId};" +
                             $"DELETE FROM Edge WHERE Id = {edgeId}";

            Connect(_connectionString, connection =>
                {
                    SqlCommand command = new SqlCommand(sqlRequest, connection);
                    command.ExecuteNonQuery();
                    return new object();
                }
            );
        }

        private static EdgeEntity ReadEdge(SqlDataReader reader)
        {
            var id = reader.GetInt32(0);
            var key = reader.GetString(1);
            return new EdgeEntity(){ Id = id, Key = key };
        }
    }
}