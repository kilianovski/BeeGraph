using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BeeGraph.Data.Constants;

namespace BeeGraph.Data.Helpers
{
    public interface IStoredProcedureHelper
    {
        IEnumerable<TResult> ExecuteReader<TResult>
            (StoredProcedure procedure,
            Func<SqlDataReader, TResult> func,
            params SqlParameter[] sqlParameters);

        object ExecuteScalar
            (StoredProcedure procedure,
            params SqlParameter[] parameters);
    }
}
