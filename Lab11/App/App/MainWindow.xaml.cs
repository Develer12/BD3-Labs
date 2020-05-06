using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Lite
{
    public partial class MainWindow : Window
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();


        public MainWindow()
        {
            InitializeComponent();
            SetConnection();

            sql_con = new SQLiteConnection("Data Source=DB.db;Version=3;New=False;Compress=True;");

            LoadData();
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=DB.db;Version=3;New=False;Compress=True;");
        }


        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        private void LoadData()
        {
            SetConnection();

            //ExecuteQuery("create table Authors(" +
            //    "id integer primary key AUTOINCREMENT," +
            //    "nickname text unique," +
            //    "mobile_phone text" +
            //    "); ");

            //ExecuteQuery("insert into Authors(nickname, mobile_phone) values " +
            //    "('Mikhail Bulgakov', '375332587856')," +
            //    "('Erich Maria Remarque', '375294457856')," +
            //    "('Oscar Wilde', '375252545856')," +
            //    "('Agatha Christie', '375332599876'); ");

            //ExecuteQuery("create table Books(" +
            //    "id integer primary key AUTOINCREMENT," +
            //    "caption text," +
            //    "publication_year integer," +
            //    "author_id integer," +
            //    "cost money," +
            //    "FOREIGN KEY(author_id) REFERENCES Authors(id)); ");

            //ExecuteQuery("insert into Books(caption, publication_year, author_id, cost) values " +
            //    "('Die Traumbude', 1920, 2, 56.8)," +
            //    "('The White Guard', 1926, 1, 57.4), " +
            //    "('Dorian Gray', 1980, 3, 41.3)," +
            //    "('Der Funke Leben', 1952, 2, 45.6), " +
            //    "('The Pale Horse', 1961, 4, 78.6), " +
            //    "('The Master and Margarita', 1967, 1, 35.7), " +
            //    "('Heart of a Dog', 1968, 1, 45.1); ");

            //ExecuteQuery("create table SoldBooks" +
            //    "(" +
            //    "id integer primary key AUTOINCREMENT," +
            //    "book_id integer," +
            //    "nbook int check(nbook > 0)," +
            //    "order_data date," +
            //    "FOREIGN KEY(book_id) REFERENCES Books(id)); ");

            //ExecuteQuery("insert into SoldBooks(book_id,nbook,order_data) values " +
            //    "(5, 63, '02-05-2018')," +
            //    "(6, 25, '02-05-2019'), " +
            //    "(7, 54, '02-05-2017'), " +
            //    "(3, 890, '02-05-2018'), " +
            //    "(2, 34, '02-05-2018'), " +
            //    "(1, 78, '02-05-2017'), " +
            //    "(4, 15, '02-05-2019'); ");

            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from WORKER;";

            using (var reader = sql_cmd.ExecuteReader())
            {
                List<WORKER> work = new List<WORKER>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        work.Add(new WORKER
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Level = reader.GetInt32(2),
                            Age = reader.GetInt32(3),
                            Job = reader.GetInt32(4)
                        });
                    }
                }
                else
                {
                    MessageBox.Show("WORKER Table is Empty");
                }
                WORKER.ItemsSource = work;
            }

            sql_cmd.CommandText = "select * from VACANCY;";

            using (var reader = sql_cmd.ExecuteReader())
            {
                List<VACANCY> vac = new List<VACANCY>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vac.Add(new VACANCY
                        {
                            Id = reader.GetInt32(0),
                            Company = reader.GetString(1),
                            Position = reader.GetString(2),
                            Salary = reader.GetInt32(3)
                        });
                    }
                }
                else
                {
                    MessageBox.Show("VACANCY Table is Empty");
                }
                VACANCY.ItemsSource = vac;
            }

            sql_cmd.CommandText = "select * from CANDIDATE;";

            using (var reader = sql_cmd.ExecuteReader())
            {
                List<CANDIDATE> can = new List<CANDIDATE>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        can.Add(new CANDIDATE
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Level = reader.GetInt32(2),
                            Age = reader.GetInt32(3),
                            Job = reader.GetInt32(4)
                        });
                    }
                }
                else
                {
                    MessageBox.Show("CANDIDATE Table is Empty");
                }

                CANDIDATE.ItemsSource = can;
            }

            ExecuteQuery("create view if not exists VacVIEW as select Id from VACANCY");

            sql_con.Open();
            sql_cmd.CommandText = "select * from VacVIEW;";

            using (var reader = sql_cmd.ExecuteReader())
            {
                List<VacVIEW> data = new List<VacVIEW>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.Add(new VacVIEW
                        {
                            Id = reader.GetInt32(0)
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Table is Empty");
                }
                VacVIEW.ItemsSource = data;
            }
            sql_con.Close();
        }
    }
}
