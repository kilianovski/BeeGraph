using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BeeGraph.Data.Config;
using BeeGraph.Data.Constants;
using static BeeGraph.Data.Helpers.SqlUtils;

namespace BeeGraph.Data.Helpers
{
    public class StoredProcedureHelper : IStoredProcedureHelper
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public StoredProcedureHelper(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(
            StoredProcedure procedure,
            Func<SqlDataReader, TResult> func,
            params SqlParameter[] sqlParameters)
        {
            return Connect(_connectionStringProvider.ConnectionString, connection =>
            {
                var command = new SqlCommand(procedure.Name, connection)
                {
                    CommandType = CommandType.StoredProcedure,                 
                };

                command.Parameters.AddRange(sqlParameters);

                var reader = command.ExecuteReader();
                var result = new List<TResult>();

                while (reader.Read())
                    result.Add(func(reader));

                return result;
            });
        }

        public object ExecuteScalar(
            StoredProcedure procedure,
            params SqlParameter[] sqlParameters)
        {
            return Connect(_connectionStringProvider.ConnectionString, connection =>
            {
                var command = new SqlCommand(procedure.Name, connection)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                command.Parameters.AddRange(sqlParameters);

                return command.ExecuteScalar();
            });
        }
    }
}