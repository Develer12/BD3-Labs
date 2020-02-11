using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lab2
{
    class DB
    {
        SqlConnection conn;
        public void openConnection(string connStr)
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public void add_Vacancy(string Company, string Position, string Level, int Exp, int MinSalary, int MaxSalary, string Status)
        {
              string sql = "insert into VACANCY (Status, Company, Position, Level, Exp, MinSalary, MaxSalary) values ('";
              sql = sql + Status + "','" + Company + "','" + Position + "','" + Level + "','" + Exp + "','" + MinSalary + "','" + MaxSalary + "')";
              SqlCommand command = new SqlCommand(sql, conn);
              command.ExecuteNonQuery();
        }

        public void drop_Vacancy(int id)
        {
                string sql = "delete from VACANCY where Id="+id;
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
        }

        public void change_Vacancy(int id, string Company, string Position, string Level, int Exp, int MinSalary, int MaxSalary, string Status)
        {
            string sql = "update VACANCY set Status='"+Status+ "', Company='" + Company + "', Position='" + Position + "', Level='" + Level + "', Exp='" + Exp + "', MinSalary='" + MinSalary + "', MaxSalary='" + MaxSalary + "' where Id='" + id + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        // ----------------------------------------------------------------------------


    }
}
