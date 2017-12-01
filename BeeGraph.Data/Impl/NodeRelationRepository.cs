using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Entities;
using BeeGraph.Data.Helpers;

namespace BeeGraph.Data
{
    public class NodeRelationRepository : INodeRelationRepository
    {
        private readonly IStoredProcedureHelper _spHelper;

        public NodeRelationRepository(IStoredProcedureHelper spHelper)
        {
            _spHelper = spHelper;
        }

        public int AddRelation(int edgeId, int fromNodeId, int toNodeId)
        {
            var edgeIdParam = new SqlParameter()
            {
                ParameterName = "@edgeId",
                Value = edgeId
            };

            var fromNodeIdParam = new SqlParameter()
            {
                ParameterName = "@fromNodeId",
                Value = fromNodeId
            };

            var toNodeIdParam = new SqlParameter()
            {
                ParameterName = "@toNodeId",
                Value = toNodeId
            };

            var result = _spHelper.ExecuteScalar(
                StoredProcedure.CreateEdgeToNodeRelation,
                edgeIdParam,
                fromNodeIdParam,
                toNodeIdParam);

            return (int) (decimal) result;
        }

        public IEnumerable<EdgeToNodesRelation> GetAll()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetEdgeToNodeRelations, ReadNode);
        }

        private EdgeToNodesRelation ReadNode(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            int fromNodeId = reader.GetInt32(1);
            int toNodeId = reader.GetInt32(2);
            int edgeId = reader.GetInt32(3);

            return new EdgeToNodesRelation()
            {
                Id = id,
                EdgeId = edgeId,
                FromNodeId = fromNodeId,
                ToNodeId = toNodeId
            };
        }
    }
}