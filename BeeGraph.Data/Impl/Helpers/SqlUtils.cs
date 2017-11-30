using System;
using System.Data.SqlClient;

namespace BeeGraph.Data.Helpers
{
    internal static class SqlUtils
    {
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
