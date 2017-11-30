using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Helpers;
using BeeGraph.Domain;

namespace BeeGraph.Data
{
    public class EdgeSpRepository : IEdgeRepository
    {
        private readonly IStoredProcedureHelper _spHelper;

        public EdgeSpRepository(IStoredProcedureHelper spHelper)
        {
            _spHelper = spHelper;
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

        public IEnumerable<Edge> GetAll()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetEdges, ReadEdge);
        }

        private static Edge ReadEdge(SqlDataReader reader)
        {
            var id = reader.GetInt32(0);
            var key = reader.GetString(1);
            return new Edge(id, key, null, null); // TODO!!1
        }
    }
}