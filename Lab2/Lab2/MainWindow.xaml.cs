using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string connStr = @"Data Source=DESKTOP-U4BLHC6;Initial Catalog=WHiring;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DataTable Vacancys = new DataTable();
        DataTable Worker = new DataTable();
        DataTable Candidate = new DataTable();

        private void addVacancy_Click(object sender, RoutedEventArgs e)
        {
            string Company = textBoxCompany.Text;
            string Position = textBoxPosition.Text;
            int Exp = Convert.ToInt32(textBoxExp.Text);
            string Level = textBoxLevel.Text;
            int MinSalary = Convert.ToInt32(textBoxMinSalary.Text);
            int MaxSalary = Convert.ToInt32(textBoxMaxSalary.Text);
            string Status = textBoxStatus.Text;

            if (Company.Length == 0 || Position.Length == 0
                || Level.Length == 0 || Company.Length == 0)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.add_Vacancy(Company, Position, Level, Exp, MinSalary, MaxSalary, Status);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
        }

        private void dropVacancy_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);

                DB db = new DB();
                db.openConnection(connStr);
                db.drop_Vacancy(id);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
        }

        private void changeVacancy_Click(object sender, RoutedEventArgs e)
        {
            string Company = textBoxCompany.Text;
            string Position = textBoxPosition.Text;
            int Exp = Convert.ToInt32(textBoxExp.Text);
            int id = Convert.ToInt32(textBoxId.Text);
            string Level = textBoxLevel.Text;
            string Status = textBoxStatus.Text;
            int MinSalary = Convert.ToInt32(textBoxMinSalary.Text); ;
            int MaxSalary = Convert.ToInt32(textBoxMaxSalary.Text); ;

            if (Company.Length == 0 || Position.Length == 0
                || Level.Length == 0 || Company.Length == 0)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.change_Vacancy(id, Company, Position, Level, Exp, MinSalary, MaxSalary, Status);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
        }

        private void allVacancys_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sqlExpression = "SVACANCY";

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sqlExpression, connection);
                    // указываем, что команда представляет хранимую процедуру
                    Vacancys.Clear();
                    // Заполняем Dataset
                    command.Fill(Vacancys);
                    // Отображаем данные
                    usersGrid.ItemsSource = Vacancys.DefaultView;
                    MessageBox.Show("Выполнено !!!");
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }
        //--------------------------------------------------------------------------------------------------------------------

        private void addCandidate_Click(object sender, RoutedEventArgs e)
        {
            string Fname = textBoxCFName.Text;
            string Sname = textBoxCSName.Text;
            string Position = textBoxPosition1.Text;
            int Exp = Convert.ToInt32(textBoxExp1.Text);
            int Age = Convert.ToInt32(textBoxAge1.Text);
            int Job = Convert.ToInt32(textBoxJob1.Text);
            string Sex = textBoxSex1.Text;
            string Level = textBoxLevel1.Text;
            int Salary = Convert.ToInt32(textBoxSalary1.Text);

            if (Fname.Length == 0 || Sname.Length == 0
                || Job<1)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.add_Candidate(Fname, Sname, Position, Level, Sex, Exp, Salary, Age, Job);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
        }

        private void dropCandidate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId1.Text);

            DB db = new DB();
            db.openConnection(connStr);
            db.drop_Candidate(id);
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void changeCandidate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId1.Text);
            string Fname = textBoxCFName.Text;
            string Sname = textBoxCSName.Text;
            string Position = textBoxPosition1.Text;
            int Exp = Convert.ToInt32(textBoxExp1.Text);
            int Age = Convert.ToInt32(textBoxAge1.Text);
            int Job = Convert.ToInt32(textBoxJob1.Text);
            string Sex = textBoxSex1.Text;
            string Level = textBoxLevel1.Text;
            int Salary = Convert.ToInt32(textBoxSalary1.Text);

            if (Fname.Length == 0 || Sname.Length == 0
                || Job < 1)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.change_Candidate(id, Fname, Sname, Position, Level, Sex, Exp, Salary, Age, Job);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        private void addWorker_Click(object sender, RoutedEventArgs e)
        {
            string Fname = textBoxWFName.Text;
            string Sname = textBoxWSName.Text;
            string Position = textBoxPosition2.Text;
            int Exp = Convert.ToInt32(textBoxExp2.Text);
            int Age = Convert.ToInt32(textBoxAge2.Text);
            int Job = Convert.ToInt32(textBoxJob2.Text);
            string Sex = textBoxSex2.Text;
            string Level = textBoxLevel2.Text;
            int Salary = Convert.ToInt32(textBoxSalary2.Text);

            if (Fname.Length == 0 || Sname.Length == 0
                || Job < 1)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.add_Worker(Fname, Sname, Position, Level, Sex, Exp, Salary, Age, Job);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
        }

        private void dropWorker_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId2.Text);

            DB db = new DB();
            db.openConnection(connStr);
            db.drop_Worker(id);
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void changeWorker_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId2.Text);
            string Fname = textBoxWFName.Text;
            string Sname = textBoxWSName.Text;
            string Position = textBoxPosition2.Text;
            int Exp = Convert.ToInt32(textBoxExp2.Text);
            int Age = Convert.ToInt32(textBoxAge2.Text);
            int Job = Convert.ToInt32(textBoxJob2.Text);
            string Sex = textBoxSex2.Text;
            string Level = textBoxLevel2.Text;
            int Salary = Convert.ToInt32(textBoxSalary2.Text);

            if (Fname.Length == 0 || Sname.Length == 0
                || Job < 1)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.change_Worker(id, Fname, Sname, Position, Level, Sex, Exp, Salary, Age, Job);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
        }
    }
}
