using System.Data.SqlClient;
using System.Data.SqlTypes;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static int GetCountbyAge(SqlInt32 min, SqlInt32 max)
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