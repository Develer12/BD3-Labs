using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static int GetCount(SqlDateTime min, SqlDateTime max)
    {
        int rows;
        SqlConnection conn = new SqlConnection("Context Connection=true");
        conn.Open();

        SqlCommand sqlCmd = conn.CreateCommand();

        sqlCmd.CommandText = @"select count(*) from CANDIDATE where Age between @min and @max";
        sqlCmd.Parameters.AddWithValue("@min", min);
        sqlCmd.Parameters.AddWithValue("@max", max);

        rows = (int)sqlCmd.ExecuteScalar();
        conn.Close();

        return rows;
    }
}