using System.Data.SqlClient;
using System.Windows;

namespace Tour.Admin.Functions
{
    public partial class DeleteMng : Window
    {
        public DeleteMng()
        {
            InitializeComponent();

            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("SELECT id FROM Managers", db.GetConnection());

                db.OpenConnection();

                Mng.Items.Clear();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mng.Items.Add(reader[0].ToString());
                }
                reader.Close();

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void DeleteMng_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("DELETE FROM Managers WHERE id = " + Mng.SelectedItem, db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Удаление произвдено успешно!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("При удалении произошла ошибка!");
                    return;
                }

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
