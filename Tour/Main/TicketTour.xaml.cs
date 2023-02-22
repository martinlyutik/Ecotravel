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
using System.Text.RegularExpressions;

namespace Tour.Main
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
                if (City.SelectedItem == null || VidRazm.SelectedItem == null
                    || VidTrans.SelectedItem == null 
                    || Typpe.SelectedItem == null 
                    || KolvoDney.SelectedItem == null || DateStart.Text == "")
                {
                    MessageBox.Show("Выберите параметры!");
                    return;
                }                

                Regex R = new Regex("\\s+");
                Match MK = R.Match(KolvoPutevok.Text);

                for (int i = 0; i < KolvoPutevok.Text.Length; i++)
                {
                    if (MK.Success)
                    {
                        MessageBox.Show("Поле не может содержать пробелы!");
                        return;
                    }
                }

                if (KolvoPutevok.Text == "")
                {
                    MessageBox.Show("Поле не может быть пустым!");
                    return;
                }

                for (int i = 0; i < KolvoPutevok.Text.Length; i++)
                {
                    if (KolvoPutevok.Text[i] >= 'А' && KolvoPutevok.Text[i] <= 'Я')
                    {
                        MessageBox.Show("Введите цифры!");
                        return;
                    }

                    if (KolvoPutevok.Text[i] >= 'A' && KolvoPutevok.Text[i] <= 'Z')
                    {
                        MessageBox.Show("Введите цифры!");
                        return;
                    }

                    if (KolvoPutevok.Text[i] >= 'а' && KolvoPutevok.Text[i] <= 'я')
                    {
                        MessageBox.Show("Введите цифры!");
                        return;
                    }

                    if (KolvoPutevok.Text[i] >= 'a' && KolvoPutevok.Text[i] <= 'z')
                    {
                        MessageBox.Show("Введите цифры!");
                        return;
                    }

                    if (Convert.ToInt32(KolvoPutevok.Text) <= 0)
                    {
                        MessageBox.Show("Количесвто путевок не может быть отрицательным!");
                        return;
                    }
                }

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
