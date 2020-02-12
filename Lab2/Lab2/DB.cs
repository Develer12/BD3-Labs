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

        public void add_Candidate(string Fname, string Sname, string Position, string Level, string Sex, int Exp, int Salary, int Age, int Job)
        {
            string sql = "insert into CANDIDATE (FName, SName, Position, Level, Sex, Exp, Salary, Age, Job) values ('";
            sql = sql + Fname + "','" + Sname + "','" + Position + "','" + Level + "','" + Sex + "','" + Exp + "','" + Salary + "','" + Age + "','" + Job + "')";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        public void drop_Candidate(int id)
        {
            string sql = "delete from CANDIDATE where Id=" + id;
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        public void change_Candidate(int id,string Fname, string Sname, string Position, string Level, string Sex, int Exp, int Salary, int Age, int Job)
        {
            string sql = "update CANDIDATE set FName='" + Fname + "', SName='" + Sname + "', Position='" + Position + "', Level='" + Level + "', Exp='" + Exp + "', Sex='" + Sex + "', Salary='" + Salary + "',Job='" + Job + "', Age='" + Age + "' where Id='" + id + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        // ----------------------------------------------------------------------------

        public void add_Worker(string Fname, string Sname, string Position, string Level, string Sex, int Exp, int Salary, int Age, int Job)
        {
            string sql = "insert into WORKER (FName, SName, Position, Level, Sex, Exp, Salary, Age, Job) values ('";
            sql = sql + Fname + "','" + Sname + "','" + Position + "','" + Level + "','" + Sex + "','" + Exp + "','" + Salary + "','" + Age + "','" + Job + "')";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        public void drop_Worker(int id)
        {
            string sql = "delete from WORKER where Id=" + id;
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        public void change_Worker(int id, string Fname, string Sname, string Position, string Level, string Sex, int Exp, int Salary, int Age, int Job)
        {
            string sql = "update WORKER set FName='" + Fname + "', SName='" + Sname + "', Position='" + Position + "', Level='" + Level + "', Exp='" + Exp + "', Sex='" + Sex + "', Salary='" + Salary + "',Job='" + Job + "', Age='" + Age + "' where Id='" + id + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }
    }
}
