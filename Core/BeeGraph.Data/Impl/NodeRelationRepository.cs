using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Config;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Entities;
using BeeGraph.Data.Helpers;
using static BeeGraph.Data.Helpers.SqlUtils;

namespace BeeGraph.Data
{
    public class NodeRelationRepository : INodeRelationRepository
    {
        private readonly IStoredProcedureHelper _spHelper;
        private readonly string _connectionString;

        public NodeRelationRepository(IStoredProcedureHelper spHelper, IConnectionStringProvider connectionStringProvider)
        {
            _spHelper = spHelper;
            _connectionString = connectionStringProvider.ConnectionString;
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

        public IEnumerable<EdgeRelationEntity> GetAllEdgeRelations()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetEdgeRelations, ReadEdgeRelation);
        }

        public void Delete(int relationId)
        {
            var sqlRequest = $"DELETE FROM EdgeToNodes WHERE Id = {relationId};";

            Connect(_connectionString, connection =>
                {
                    SqlCommand command = new SqlCommand(sqlRequest, connection);
                    command.ExecuteNonQuery();
                    return new object();
                }
            );
        }

        private EdgeRelationEntity ReadEdgeRelation(SqlDataReader reader)
        {
            int relationId = reader.GetInt32(0);
            int fromNodeId = reader.GetInt32(1);
            string fromNodeBody = reader.GetString(2);
            int edgeId = reader.GetInt32(3);
            string edgeKey = reader.GetString(4);
            int toNodeId = reader.GetInt32(5);
            string toNodeBody = reader.GetString(6);

            return new EdgeRelationEntity(relationId, fromNodeId, fromNodeBody, edgeId, edgeKey, toNodeId, toNodeBody);
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