using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BeeGraph.Data.Config;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Entities;
using BeeGraph.Data.Helpers;
using BeeGraph.Infrastructure.Monads;
using static BeeGraph.Data.Helpers.SqlUtils;

namespace BeeGraph.Data
{
    public class NodeSpRepository : INodeRepository
    {
        private readonly IStoredProcedureHelper _spHelper;
        private readonly string _connectionString;

        public NodeSpRepository(IStoredProcedureHelper spHelper, IConnectionStringProvider connectionStringProvider)
        {
            _spHelper = spHelper;
            _connectionString = connectionStringProvider.ConnectionString;
        }

        public IEnumerable<NodeEntity> GetAll()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetNodes, ReadNode);
        }

        public Maybe<NodeEntity> Get(int id)
        {
            var idParameter = new SqlParameter("id", id);
            var requestResult = _spHelper.ExecuteReader(StoredProcedure.GetNodeById, ReadNode, idParameter);
            var node = requestResult.SingleOrDefault();
            return node == null
                ? Maybe.Nothing<NodeEntity>()
                : Maybe.Just(node);
        }

        public void Delete(int id)
        {
            var sqlRequest = $"DELETE FROM Dialog WHERE StartNodeId = {id};" +
                             $"DELETE FROM EdgeToNodes WHERE FromNodeId = {id} OR ToNodeId = {id};" +
                             $"DELETE FROM Node WHERE Id = {id}";
            Connect(_connectionString, connection =>
                {
                    SqlCommand command = new SqlCommand(sqlRequest, connection);
                    command.ExecuteNonQuery();
                    return new object();
                }
            );
        }

        private NodeEntity ReadNode(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string body = reader.GetString(1);
            return new NodeEntity(){ Id = id, Body = body};
        }

        public int CreateNode(string body)
        {
            var bodyParam = new SqlParameter
            {
                ParameterName = "@body",
                Value = body
            };

            var result = _spHelper.ExecuteScalar(StoredProcedure.InsertNode, bodyParam);

            return (int)(decimal)result;           
        }
    }
}
