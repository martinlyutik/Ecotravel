using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace Tour.Admin.Functions
{
    public partial class SelectAllManagers : Window
    {
        public SelectAllManagers()
        {
            InitializeComponent();
        }

        private void SelectMng_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT * FROM Managers", db.GetConnection());

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

        private void DeleteMng_Click(object sender, RoutedEventArgs e)
        {
            DeleteMng mng = new DeleteMng();
            mng.Show();
        }

        private void CreateManager_Click(object sender, RoutedEventArgs e)
        {
            CreateManager mng = new CreateManager();
            mng.Show();
        }
    }
}
