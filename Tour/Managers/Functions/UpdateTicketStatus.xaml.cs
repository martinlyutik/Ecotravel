using System.Data.SqlClient;
using System.Windows;

namespace Tour.Managers.Functions
{
    public partial class UpdateTicketStatus : Window
    {
        public UpdateTicketStatus()
        {
            InitializeComponent();

            try
            {
                Status.Items.Add("Подано");
                Status.Items.Add("В процессе обработки");
                Status.Items.Add("Обработано");
                Status.Items.Add("Завершено");

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

        private void UpdateTicketStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("UPDATE ticket SET statuss = '" + Status.SelectedItem + "' WHERE id = " + Ticket.SelectedItem, db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Статус был изменен!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Во время операции произошла ошибка!");
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
