using System;
using System.Collections.Generic;
using System.Data;
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

namespace Tour.Main
{
    public partial class Catalog : Window
    {
        private Classes.User _user;

        public Catalog(Classes.User user)
        {
            InitializeComponent();

            _user = user;

            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT namme FROM Country", db.GetConnection());

            SqlCommand cmd = new SqlCommand("SELECT namme FROM City", db.GetConnection());

            db.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CountryList.Items.Add(reader[0].ToString());
            }
            reader.Close();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                CityList.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            db.CloseConnection();
        }

        private void CreateTicket_Click(object sender, RoutedEventArgs e)
        {
            Main.TicketTour tick = new Main.TicketTour(_user);
            tick.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Authentification.LogIn log = new Authentification.LogIn();
            log.Show();
        }
    }
}
