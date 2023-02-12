using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tour.Admin.Functions;
using Tour.Authentification;

namespace Tour.Admin
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn log = new LogIn();
            log.Show();
        }

        private void SelectUser_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT * FROM Users", db.GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.OpenConnection();

            OutputDb.ItemsSource = table.DefaultView;

            db.CloseConnection();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser user = new CreateNewUser();
            user.Show();
        }

        private void CreateManager_Click(object sender, RoutedEventArgs e)
        {
            CreateManager mng = new CreateManager();
            mng.Show();
        }

        private void SelectMng_Click(object sender, RoutedEventArgs e)
        {
            SelectAllManagers mng = new SelectAllManagers();
            mng.Show();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Functions.DeleteUser user = new Functions.DeleteUser();
            user.Show();
        }
    }
}
