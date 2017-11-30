using System;
using System.Collections.Generic;
using System.Data;
using BeeGraph.Data.Interfaces;
using BeeGraph.Domain;
using System.Data.SqlClient;

namespace BeeGraph.Data.Impl
{
    public class NodeSpRepository : INodeRepository
    {
        private static string cs = "Server=localhost\\SQLEXPRESS;Database=BeeGraph_Test;Trusted_Connection=True;";

        public IEnumerable<Node> GetAll()
        {
            string spName = "sp_GetNodes";
            return Connect(cs, GetAll);

            IEnumerable<Node> GetAll(SqlConnection connection)
            {
                var command = new SqlCommand(spName, connection);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                var result = new List<Node>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string body = reader.GetString(1);

                    result.Add(new Node(id, body));
                }
                return result;
            }

        }

        public int CreateNode(string body)
        {
            string spName = "sp_InsertNode";

            return Connect(cs, CreateNode);

            int CreateNode(SqlConnection connection)
            {
                var command = new SqlCommand(spName, connection);
                command.CommandType = CommandType.StoredProcedure;

                var bodyParam = new SqlParameter()
                {
                    ParameterName = "@body",
                    Value = body
                };

                command.Parameters.Add(bodyParam);

                var result = command.ExecuteScalar();
                return (int)(decimal)result;
            }
        }
        

        public static TR Connect<TR>(string connString, Func<SqlConnection, TR> f)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                return f(conn);
            }
        }
    }
}
