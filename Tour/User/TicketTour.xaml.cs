using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace Tour.User
{
    public partial class TicketTour : Window
    {

        private Classes.User _user;
        public TicketTour(Classes.User user)
        {
            InitializeComponent();

            _user = user;

            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT namme FROM City", db.GetConnection());
            SqlCommand com = new SqlCommand("SELECT namme FROM Vid", db.GetConnection());
            SqlCommand cmd = new SqlCommand("SELECT namme FROM Vid_Transp", db.GetConnection());
            SqlCommand comd = new SqlCommand("SELECT namme FROM Typpe", db.GetConnection());

            KolvoDney.Items.Add("7");
            KolvoDney.Items.Add("14");
            KolvoDney.Items.Add("21");

            db.OpenConnection();

            City.Items.Clear();
            VidRazm.Items.Clear();
            VidTrans.Items.Clear();
            Typpe.Items.Clear();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                City.Items.Add(reader[0].ToString());
            }
            reader.Close();

            SqlDataReader rd = com.ExecuteReader();

            while (rd.Read())
            {
                VidRazm.Items.Add(rd[0].ToString());
            }
            rd.Close();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                VidTrans.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            SqlDataReader redr = comd.ExecuteReader();

            while (redr.Read())
            {
                Typpe.Items.Add(redr[0].ToString());
            }
            redr.Close();

            db.CloseConnection();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void SaveTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();

                string Now = DateTime.Now.ToString("MM'/'dd'/'yyyy HH:mm");

                SqlCommand command = new SqlCommand("INSERT INTO ticket" +
                    " (id_city, id_vid, id_vid_transp, id_typpe, " +
                    "date_podachi, date_start, day_count, " +
                    "putevka_count, statuss, id_user) VALUES " +
                    "((SELECT id FROM City WHERE namme = '" +
                    City.SelectedItem + "')," +
                    "(SELECT id FROM Vid WHERE namme = '" +
                    VidRazm.SelectedItem + "')," +
                    "(SELECT id FROM Vid_Transp WHERE namme = '" +
                    VidTrans.SelectedItem + "')," +
                    "(SELECT id FROM Typpe WHERE namme = '" +
                    Typpe.SelectedItem + "')," +
                    "'" + Now + "'," +
                    "'" + DateStart.SelectedDate + "'," +
                    "'" + KolvoDney.SelectedItem + "'," +
                    "'" + KolvoPutevok.Text + "'," +
                    "'Подано', " + 
                    "'" + _user.Id + "')", db.GetConnection()); ;

                db.OpenConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Заявка успешно подана в обработку!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка, попробуйте повторить попытку!");
                    return;
                }

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Во время выполнения вашего запроса произошла ошибка! Повторите еще раз!");
            }            
        }
    }
}
