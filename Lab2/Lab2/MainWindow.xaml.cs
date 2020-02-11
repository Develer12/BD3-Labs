﻿using System;
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
        DataTable Contracts = new DataTable();
        DataTable DTPs = new DataTable();
        DataTable Cars = new DataTable();

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
            int Exp = Convert.ToInt32(textBoxExp.Text); ;
            string Level = textBoxLevel.Text;
            if (Company.Length == 0 || Position.Length == 0
                || Level.Length == 0 || Company.Length == 0)
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.change_Vacancy(Company, Position, Exp, Level);
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
        
    }
}
