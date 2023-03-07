using System.Data.SqlClient;
using System.Windows;

namespace Tour.Admin.Functions
{
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();

            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("SELECT id FROM Users", db.GetConnection());

                db.OpenConnection();

                User.Items.Clear();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User.Items.Add(reader[0].ToString());
                }
                reader.Close();

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE id = " + User.SelectedItem, db.GetConnection());

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
