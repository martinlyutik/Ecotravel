using System.Data.SqlClient;
using System.Windows;

namespace Tour.User
{
    public partial class CheckTicket : Window
    {
        public CheckTicket(Classes.User user)
        {
            InitializeComponent();

            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("SELECT ticket.id, " +
                    "City.namme, " +
                    "ticket.statuss, ticket.date_podachi " +
                    "FROM ticket " +
                    "LEFT JOIN City " +
                    "ON id_city = City.id " +
                    "WHERE ticket.id_user = " + user.Id, 
                    db.GetConnection());

                db.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tickets.Items.Add("Номер заявки:  " + reader[0].ToString()
                        + "  Город:  " + reader[1].ToString() + 
                        "  Статус заявки:  " + reader[2].ToString()
                        + "  Дата подачи:  " + reader[3].ToString());
                }
                reader.Close();

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
