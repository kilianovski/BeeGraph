﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BeeGraph.Data.Constants;
using BeeGraph.Data.Entities;
using BeeGraph.Data.Helpers;
using BeeGraph.Infrastructure.Monads;

namespace BeeGraph.Data
{
    public class NodeSpRepository : INodeRepository
    {
        private readonly IStoredProcedureHelper _spHelper;

        public NodeSpRepository(IStoredProcedureHelper spHelper)
        {
            _spHelper = spHelper;
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
