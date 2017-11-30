using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Helpers;
using BeeGraph.Domain;

namespace BeeGraph.Data
{
    public class NodeSpRepository : INodeRepository
    {
        private readonly IStoredProcedureHelper _spHelper;
        private static string cs = "Server=localhost\\SQLEXPRESS;Database=BeeGraph_Test;Trusted_Connection=True;";

        public NodeSpRepository(IStoredProcedureHelper spHelper)
        {
            _spHelper = spHelper;
        }

        public IEnumerable<Node> GetAll()
        {
            return _spHelper.ExecuteReader(StoredProcedure.GetNodes, ReadNode);
        }

        private Node ReadNode(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string body = reader.GetString(1);
            return new Node(id, body);
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
