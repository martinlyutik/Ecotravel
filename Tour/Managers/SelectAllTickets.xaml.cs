using System;
using System.Collections.Generic;
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
using Tour.Classes;

namespace Tour.Managers
{
    public partial class SelectAllTickets : Window
    {
        public SelectAllTickets()
        {
            InitializeComponent();

            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("SELECT ticket.id, " +
                    "City.namme, " +
                    "Vid.namme, " +
                    "Vid_Transp.namme, " +
                    "Typpe.namme, " +
                    "ticket.date_podachi, " +
                    "ticket.date_start, " +
                    "ticket.day_count, " +
                    "ticket.putevka_count, " +
                    "ticket.statuss, " +
                    "Users.id " +
                    "FROM ticket " +
                    "LEFT JOIN City " +
                    "ON ticket.id_city = City.id " +
                    "LEFT JOIN Vid " +
                    "ON ticket.id_vid = Vid.id " +
                    "LEFT JOIN Vid_Transp " +
                    "ON ticket.id_vid_transp = Vid_Transp.id " +
                    "LEFT JOIN Typpe " +
                    "ON ticket.id_typpe = Typpe.id " +
                    "LEFT JOIN Users " +
                    "ON ticket.id_user = Users.id", db.GetConnection());

                db.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tickets.Items.Add("Номер заявки:  " + reader[0].ToString()
                        + "  Город:  " + reader[1].ToString() +
                        "  Вид размещения:  " + reader[2].ToString()
                        + "  Вид ТС:  " + reader[3].ToString()
                        + "  Тип отдыха:  " + reader[4].ToString()
                        + "  Дата подачи:  " + reader[5].ToString()
                        + "  Дата начала:  " + reader[6].ToString()
                        + "  Кол-во дней:  " + reader[7].ToString()
                        + "  Кол-во путевок:  " + reader[8].ToString()
                        + "  Статус:  " + reader[9].ToString()
                        + "  Id Пользователя:  " + reader[10].ToString());
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

        private void DeleteTicket_Click(object sender, RoutedEventArgs e)
        {
            Functions.DeleteTicket del = new Functions.DeleteTicket();
            del.Show();
        }

        private void UpdateTicketStatus_Click(object sender, RoutedEventArgs e)
        {
            Functions.UpdateTicketStatus st = new Functions.UpdateTicketStatus();
            st.Show();
        }        
    }
}
