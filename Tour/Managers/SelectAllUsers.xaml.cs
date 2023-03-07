using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Tour.Managers
{
    public partial class SelectAllUsers : Window
    {
        public SelectAllUsers()
        {
            InitializeComponent();

            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT id, " +
                "namme, surname, otch, passport, visa, " +
                "email, number FROM Users", db.GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.OpenConnection();

            OutputDb.ItemsSource = table.DefaultView;

            db.CloseConnection();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
