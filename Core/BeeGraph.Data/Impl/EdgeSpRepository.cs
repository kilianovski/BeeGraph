using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Entities;
using BeeGraph.Data.Helpers;

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

        public IEnumerable<EdgeEntity> GetAll()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetEdges, ReadEdge);
        }

        private static EdgeEntity ReadEdge(SqlDataReader reader)
        {
            var id = reader.GetInt32(0);
            var key = reader.GetString(1);
            return new EdgeEntity(){ Id = id, Key = key };
        }
    }
}