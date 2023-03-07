using System.Data.SqlClient;
using System.Windows;

namespace Tour.Managers.Functions
{
    public partial class DeleteTicket : Window
    {
        public DeleteTicket()
        {
            InitializeComponent();

            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("SELECT id FROM ticket", db.GetConnection());

                db.OpenConnection();

                Ticket.Items.Clear();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ticket.Items.Add(reader[0].ToString());
                }
                reader.Close();

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }            
        }

        private void DeleteTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("DELETE FROM ticket WHERE id = " + Ticket.SelectedItem, db.GetConnection());

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
